using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Common;
using GpwEditor.Properties;

namespace GpwEditor.Views
{
    public partial class ReconstructFunctionForm : EditorForm
    {
        private class InstructionDefinition
        {
            public int Address { get; set; }
            public byte[] Instructions { get; set; }
            public int ReferencedAddress { get; set; }
        }

        public ReconstructFunctionForm(int cutFromAddress, int cutToAddress, int relocationFunctionAddress)
        {
            InitializeComponent();

            CutFromAddressTextBox.Text = cutFromAddress.ToString("X8");
            CutToAddressTextBox.Text = cutToAddress.ToString("X8");
            RelocationFunctionAddressTextBox.Text = relocationFunctionAddress.ToString("X8");

            InputTextBox.MaxLength = int.MaxValue;
            ReconstructedFunctionOutputTextBox.MaxLength = int.MaxValue;
            RelocatedFunctionOutputTextBox.MaxLength = int.MaxValue;
        }

        private void ReconstructFunctionForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.icon1;
            Text = $"{Settings.Default.ApplicationName} - Reconstruct Function";
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            List<byte[]> reconstructedFunctionDefinition;
            List<byte[]> relocatedFunctionDefinition;

            var functionDefinition = BuildFunctionDefinitionFromIdaDisassemblyOutput(InputTextBox.Lines);
            ReconstructFunctionDefinition(functionDefinition,
                int.Parse(CutFromAddressTextBox.Text, NumberStyles.HexNumber),
                int.Parse(CutToAddressTextBox.Text, NumberStyles.HexNumber),
                int.Parse(RelocationFunctionAddressTextBox.Text, NumberStyles.HexNumber),
                out reconstructedFunctionDefinition, out relocatedFunctionDefinition);

            ReconstructedFunctionOutputTextBox.Lines =
                reconstructedFunctionDefinition.Select(i => FormatBytesToString(i, RawOutputCheckBox.Checked)).ToArray();
            RelocatedFunctionOutputTextBox.Lines =
                relocatedFunctionDefinition.Select(i => FormatBytesToString(i, RawOutputCheckBox.Checked)).ToArray();
        }

        private IEnumerable<InstructionDefinition> BuildFunctionDefinitionFromIdaDisassemblyOutput(string[] lines)
        {
            if (lines == null) throw new ArgumentNullException(nameof(lines));

            var instructionDefinitions = new List<InstructionDefinition>();

            var lineCounter = 0;
            var minimumLineLength = 14;
            var minimumLineLengthWithInstructions = 50;
            var lineStartsWith = ".text:";

            foreach (var line in lines)
            {
                lineCounter++;
                if (line.Length < minimumLineLength)
                {
                    throw new Exception($"Line {lineCounter} is too short. Must be {minimumLineLength} characters long.");
                }

                if (!line.StartsWith(lineStartsWith))
                {
                    throw new Exception($"Line {lineCounter} is invalid. Line must start with \"{lineStartsWith}\".");
                }

                if (line.Length == minimumLineLength)
                {
                    // No instructions so skip line
                    continue;
                }

                if (line.Length < minimumLineLengthWithInstructions)
                {
                    throw new Exception(
                        $"Line {lineCounter} is invalid. Line is shorter than {minimumLineLengthWithInstructions} characters.");
                }

                // Get instructions
                var instructions = line.Substring(14, 35).Trim(); // "00 01 02 03 04 05 06 07..."
                if (string.IsNullOrWhiteSpace(instructions))
                {
                    // No instructions so skip line
                    continue;
                }

                // Get address
                var address = int.Parse(line.Substring(6, 8).Trim(), NumberStyles.HexNumber); // "01234567"

                // Get referenced address
                var referencedAddress = 0;

                // CALL = E8
                if (instructions.StartsWith("E8"))
                {
                    var referencedAddressString = line.Substring(75); // "sub_01234567"
                    if (!referencedAddressString.StartsWith("sub_"))
                    {
                        throw new Exception($"Line {lineCounter} is invalid. Referenced position must start with \"sub_\".");
                    }

                    referencedAddress = int.Parse(referencedAddressString.Substring(4).Trim(), NumberStyles.HexNumber); // "01234567"
                }
                else
                {
                    //  JMP = E9
                    //  JNZ = 0F 85
                    //   JL = 0F 8C
                    //  JGE = 0F 8D
                    //  JLE = 0F 8E
                    //   JG = 0F 8F
                    if (instructions.StartsWith("E9") ||
                        instructions.StartsWith("0F 85") ||
                        instructions.StartsWith("0F 8C") ||
                        instructions.StartsWith("0F 8D") ||
                        instructions.StartsWith("0F 8E") ||
                        instructions.StartsWith("0F 8F")
                        )
                    {
                        var referencedAddressString = line.Substring(75); // "loc_01234567"
                        if (!referencedAddressString.StartsWith("loc_"))
                        {
                            throw new Exception($"Line {lineCounter} is invalid. Referenced address must start with \"loc_\".");
                        }

                        referencedAddress = int.Parse(referencedAddressString.Substring(4).Trim(), NumberStyles.HexNumber); // "01234567"
                    }

                    else
                    {
                        // Detect any undefined referenced addresses
                        if (line.Length > 75)
                        {
                            var referencedAddressString = line.Substring(75); // "xxx_01234567"
                            if (referencedAddressString.StartsWith("sub_") ||
                                referencedAddressString.StartsWith("loc_"))
                            {
                                throw new Exception(
                                    $"Line {lineCounter} is invalid. Instructions appear to reference another address. Check opcode inclusion.");
                            }
                        }
                    }
                }

                // Add extracted details to list
                instructionDefinitions.Add(new InstructionDefinition
                {
                    Address = address,
                    Instructions = HexConversion.GetStringToBytes(instructions),
                    ReferencedAddress = referencedAddress
                });
            }
            return instructionDefinitions;
        }

        private static void ReconstructFunctionDefinition(IEnumerable<InstructionDefinition> functionDefinition,
            int cutFromAddress, int cutToAddress, int relocationFunctionAddress,
            out List<byte[]> reconstructedFunctionDefinition,
            out List<byte[]> relocationFunctionDefinition)
        {
            // Create instructions to insert the relocation function
            var relocationFunctionInstructions = new byte[] { 0xE8, 0x00, 0x00, 0x00, 0x00 };
            var recalculatedRelativeOffset = CalculateRelativeAddress(cutFromAddress, relocationFunctionAddress, 5);
            var relocationFunctionAddressBytes = BitConverter.GetBytes(recalculatedRelativeOffset);
            for (var j = 1; j < 5; j++)
            {
                relocationFunctionInstructions[j] = relocationFunctionAddressBytes[j - 1];
            }

            // Divide function into three parts for further processing
            var beforeCutFunctionDefinition = new List<InstructionDefinition>();
            var insideCutFunctionDefinition = new List<InstructionDefinition>();
            var afterCutFunctionDefinition = new List<InstructionDefinition>();

            foreach (var instructionDefinition in functionDefinition)
            {
                if (instructionDefinition.Address < cutFromAddress)
                {
                    beforeCutFunctionDefinition.Add(instructionDefinition);
                }
                else if (instructionDefinition.Address >= cutFromAddress && instructionDefinition.Address < cutToAddress)
                {
                    insideCutFunctionDefinition.Add(instructionDefinition);
                }
                else
                {
                    afterCutFunctionDefinition.Add(instructionDefinition);
                }
            }

            // Transform the part after the cut
            foreach (var instructionDefinition in afterCutFunctionDefinition)
            {
                var addressAdjustment = cutToAddress - cutFromAddress - relocationFunctionInstructions.Length;
                var transformedAddress = instructionDefinition.Address - addressAdjustment;
                var transformedInstructions = instructionDefinition.Instructions;
                int transformedReferenceAddress;

                if (instructionDefinition.Instructions.Length == 5)
                {
                    if ((instructionDefinition.Instructions[0] == 0xE8) || // CALL
                        (instructionDefinition.Instructions[0] == 0xE9)) // JMP
                    {
                        if (instructionDefinition.Instructions[0] == 0xE8)
                        {
                            // Referenced address does not change for CALL opcode
                            transformedReferenceAddress = instructionDefinition.ReferencedAddress;
                        }
                        else
                        {
                            // Referenced address changes for JMP opcode
                            transformedReferenceAddress = instructionDefinition.ReferencedAddress - addressAdjustment;
                        }

                        var bytes = BitConverter.GetBytes(CalculateRelativeAddress(transformedAddress, transformedReferenceAddress, 5));
                        for (var i = 1; i < 5; i++)
                        {
                            transformedInstructions[i] = bytes[i - 1];
                        }

                        // Update with transformations
                        instructionDefinition.Address = transformedAddress;
                        instructionDefinition.Instructions = transformedInstructions;
                        instructionDefinition.ReferencedAddress = transformedReferenceAddress;
                    }
                }

                else if (instructionDefinition.Instructions.Length == 6)
                {
                    if (instructionDefinition.Instructions[0] == 0x0F)
                    {
                        if ((instructionDefinition.Instructions[1] == 0x85) || // JNZ
                            (instructionDefinition.Instructions[1] == 0x8C) || // JL
                            (instructionDefinition.Instructions[1] == 0x8D) || // JGE
                            (instructionDefinition.Instructions[1] == 0x8E) || // JLE
                            (instructionDefinition.Instructions[1] == 0x8F)) // JG
                        {
                            // Referenced address changes for defined opcodes
                            transformedReferenceAddress = instructionDefinition.ReferencedAddress - addressAdjustment;

                            var bytes = BitConverter.GetBytes(CalculateRelativeAddress(transformedAddress, transformedReferenceAddress, 6));
                            for (var i = 2; i < 6; i++)
                            {
                                transformedInstructions[i] = bytes[i - 2];
                            }

                            // Update with transformations
                            instructionDefinition.Address = transformedAddress;
                            instructionDefinition.Instructions = transformedInstructions;
                            instructionDefinition.ReferencedAddress = transformedReferenceAddress;
                        }
                    }
                }
            }

            // Reconstruct the function
            reconstructedFunctionDefinition = new List<byte[]>();
            foreach (var instructionDefinition in beforeCutFunctionDefinition)
            {
                reconstructedFunctionDefinition.Add(instructionDefinition.Instructions);
            }
            reconstructedFunctionDefinition.Add(relocationFunctionInstructions);
            foreach (var instructionDefinition in afterCutFunctionDefinition)
            {
                reconstructedFunctionDefinition.Add(instructionDefinition.Instructions);
            }

            // Construct relocation function
            relocationFunctionDefinition = new List<byte[]>();
            relocationFunctionDefinition.Add(new byte[] { 0x55 });
            relocationFunctionDefinition.Add(new byte[] { 0x8B, 0xEC });
            relocationFunctionDefinition.Add(new byte[] { 0x53 });
            relocationFunctionDefinition.Add(new byte[] { 0x56 });
            relocationFunctionDefinition.Add(new byte[] { 0x57 });
            foreach (var instructionDefinition in insideCutFunctionDefinition)
            {
                relocationFunctionDefinition.Add(instructionDefinition.Instructions);
            }
            relocationFunctionDefinition.Add(new byte[] { 0x5F });
            relocationFunctionDefinition.Add(new byte[] { 0x5E });
            relocationFunctionDefinition.Add(new byte[] { 0x5B });
            relocationFunctionDefinition.Add(new byte[] { 0xC9 });
            relocationFunctionDefinition.Add(new byte[] { 0xC3 });
        }

        private static int CalculateRelativeAddress(int address, int referencedAddress, int opcodeLength)
        {
            return referencedAddress - (address + opcodeLength);
        }

        private static string FormatBytesToString(byte[] bytes, bool isRawOutputRequired)
        {
            var byteString = BitConverter.ToString(bytes);

            return isRawOutputRequired ? byteString.Replace("-", " ") : "0x" + byteString.Replace("-", ", 0x") + ",";
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void OutputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
    }
}