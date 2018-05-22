using System.Collections.Generic;
using App.BaseGameEditor.Application.Patchers.Enhancements.Units;

namespace App.BaseGameEditor.Application.Patchers.CompareTo103Patcher
{
    public class CompareTo103Patcher
    {
        public bool Compare(string filePath)
        {
            var executableFilePath = string.Empty;

            var checkList = new List<DataPatcherUnitBase>
            {
                new CarDesignCalculationUpdate(),
                new CarHandlingPerformanceFix(),
                new DisplayModeFix(),
                new GameCdFix(),
                new PointsSystemF1201020xxUpdate(),
                new RaceSoundsFix(),
                new SampleAppFix(),
                new YellowFlagFix()
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
                    if (!item.IsCodeModified(executableFilePath))
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
