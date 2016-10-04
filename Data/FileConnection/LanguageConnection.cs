using Common.Enums;
using Common.FileConnection;
using Core.Extensions;
using System;
using System.Collections.Generic;
using Core.Collections.Language;
using Core.Entities.Language;

namespace Data.FileConnection
{
    public class LanguageConnection : TextFileConnectionBase
    {
        public IdentityCollection Load()
        {
            if (GetStreamDirection() != StreamDirectionType.Read)
            {
                throw new Exception("Stream direction must be read.");
            }

            // Read strings from file
            string line;
            var stringList = new List<string>();
            while ((line = ReadLine()) != null)
            {
                stringList.Add(line);
            }

            // Return string list as identity collection 
            return ConvertStringListToStringTable(stringList);
        }

        public void Save(IdentityCollection stringTable)
        {
            if (GetStreamDirection() != StreamDirectionType.Write)
            {
                throw new Exception("Stream direction must be write.");
            }

            // Generate string list from identity collection
            var stringList = ConvertIdentityCollectionToStringList(stringTable);

            // Write strings to file
            foreach (var line in stringList)
            {
                WriteLine(line);
            }
        }

        private static IdentityCollection ConvertStringListToStringTable(IEnumerable<string> stringList)
        {
            var i = 0;
            var result = new IdentityCollection();

            try
            {
                foreach (var line in stringList)
                {
                    var key = i.BuildStringTableId();

                    // If line contains "SID000000"
                    if (line.ToUpper().Contains(key))
                    {
                        // Extract string from between quotes
                        var value = (line.Split(new[] { '"' }, 3))[1];

                        var identity = new Identity
                        {
                            Id = i,
                            LocalResourceId = 0,
                            ResourceId = key,
                            ResourceText = value
                        };

                        result.Add(identity);
                    }

                    else
                    {
                        // Ignore line if it does not contain "SID000000"
                        continue;
                    }

                    i++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to import all values from string table.", ex);
            }

            return result;
        }

        private static IEnumerable<string> ConvertIdentityCollectionToStringList(IdentityCollection stringTable)
        {
            var result = new List<string>();

            try
            {
                // Build and add string to string table
                foreach (var item in stringTable)
                {
                    result.Add(item.ResourceId + " \"" + item.ResourceText + "\"");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to export all values to string table.", ex);
            }

            return result;
        }
    }
}
