using System.Collections.Generic;
using System.Linq;
using Common.Enums;
using Core.Helpers;
using Data.FileConnection;
using Data.Patchers.Enhancements.Units;

namespace Data.Patchers.CompareTo103Patcher
{
    public class CompareTo103Patcher
    {
        public bool Compare(string filePath)
        {
            var checkList = new List<DataPatcherUnitBase>
            {
                new CarDesignCalculationUpdate(),
                new CarHandlingPerformanceFix(),
                new DisplayModeFix(),
                new GameCdFix(),
                new PointsSystemF1201020xxUpdate(),
                new RaceSoundsFix(),
                new YellowFlagFix()
            };

            // File connection
            ExecutableConnection executableConnection = null;

            try
            {
                executableConnection = new ExecutableConnection();
                executableConnection.Open(filePath, StreamDirectionType.Read);

                foreach (var item in checkList)
                {
                    var modifiedInstructions = item.GetModifiedInstructions();
                    foreach (var task in modifiedInstructions)
                    {
                        var currentInstructions = executableConnection.ReadByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(task.Position), task.InstructionSet.Length);
                        if (!currentInstructions.SequenceEqual(task.InstructionSet))
                        {
                            return false;
                        }
                    }
                }
            }
            finally
            {
                if (executableConnection != null)
                {
                    executableConnection.Close();
                }
            }

            return true;
        }
    }
}
