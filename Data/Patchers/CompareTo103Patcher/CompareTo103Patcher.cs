using System.Collections.Generic;
using Data.Patchers.Enhancements.Units;

namespace Data.Patchers.CompareTo103Patcher
{
    public class CompareTo103Patcher
    {
        public bool Compare(string filePath)
        {
            var executableFilePath = string.Empty;

            var checkList = new List<DataPatcherUnitBase>
            {
                new CarDesignCalculationUpdate(executableFilePath),
                new CarHandlingPerformanceFix(executableFilePath),
                new DisplayModeFix(executableFilePath),
                new GameCdFix(executableFilePath),
                new PointsSystemF1201020xxUpdate(executableFilePath),
                new RaceSoundsFix(executableFilePath),
                new SampleAppFix(executableFilePath),
                new YellowFlagFix(executableFilePath)
            };

            // File connection
            //ExecutableConnection executableConnection = null;
            //
            //try
            //{
                //executableConnection = new ExecutableConnection();
                //executableConnection.Open(filePath, StreamDirectionType.Read);

                foreach (var item in checkList)
                {
                    if (!item.IsCodeModified())
                    {
                        return false;
                    }

                    //var modifiedInstructions = item.GetModifiedInstructions();
                    //foreach (var task in modifiedInstructions)
                    //{
                    //    var currentInstructions = executableConnection.ReadByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(task.VirtualPosition), task.Instructions.Length);
                    //    if (!currentInstructions.SequenceEqual(task.Instructions))
                    //    {
                    //        return false;
                    //    }
                    //}
                }
            //}
            //finally
            //{
            //    if (executableConnection != null)
            //    {
            //        executableConnection.Close();
            //    }
            //}

            return true;
        }
    }
}
