using Common.Enums;
using Common.FileConnection;
using System;
using System.Collections.Generic;
using System.IO;
using Common.Extensions;
using Data.Collections.Language;
using Data.Entities.Language;

namespace Data.FileConnection
{
    public class LanguageResourceConnection : TextFileConnectionBase
    {
        public const int FirstLineId = 0;
        public const int LastLineId = 7172;

        public LanguageResourceConnection(string filePath) : base(filePath)
        {
        }

        public IdentityCollection Load()
        {
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
            // Generate string list from identity collection
            var stringList = ConvertIdentityCollectionToStringList(stringTable);

            // Write strings to file
            foreach (var line in stringList)
            {
                WriteLine(line);
            }
        }

        protected override string ReadLine()
        {
            if (!IsRead())
            {
                SwitchStreamDirection();
            }

            return base.ReadLine();
        }

        protected override void WriteLine(string line)
        {
            if (!IsWrite())
            {
                SwitchStreamDirection();
            }

            base.WriteLine(line);
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

        private static IdentityCollection ConvertStringListToStringTable(IEnumerable<string> stringList)
        {
            var i = 0;
            var result = new IdentityCollection();

            try
            {
                foreach (var line in stringList)
                {
                    var key = i.BuildResourceId();

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

        private bool IsRead()
        {
            return StreamDirection == StreamDirectionType.Read;
        }

        private bool IsWrite()
        {
            return StreamDirection == StreamDirectionType.Write;
        }

        private void SwitchStreamDirection()
        {
            // Switch read to write
            if (IsRead())
            {
                Close();
                Open(StreamDirectionType.Write, FileMode.Truncate);
                return;
            }

            // Switch write to read
            if (IsWrite())
            {
                Close();
                Open(StreamDirectionType.Read);
                return;
            }

            throw new Exception("Unable to switch stream direction, as stream direction not defined.");
        }
    }
}