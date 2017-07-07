using Data.Collections.Language;
using Data.FileConnection;
using Mapping = Data.ValueMapping.Executable.Race;

namespace Data.Entities.Executable.Race
{
    public class PerformanceCurve : IDataConnection
    {
        public int[] Values { get; set; }

        public PerformanceCurve()
        {
            Values = new int[120];
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            var valueMapping = new Mapping.PerformanceCurve();
            for (var i = 0; i < Values.Length; i++)
            {
                executableConnection.WriteInteger(valueMapping.Values[i], Values[i]);
            }
        }

        public void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            var valueMapping = new Mapping.PerformanceCurve();
            for (var i = 0; i < Values.Length; i++)
            {
                Values[i] = executableConnection.ReadInteger(valueMapping.Values[i]);
            }
        }
    }
}