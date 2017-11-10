using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Common.Editor.Infrastructure.New;
using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Resources
{
    public class LanguageResourceService : ITextFileResource
    {
        // TODO: remove?
        //private const int FirstLineId = 0;
        //private const int LastLineId = 7172;

        public LanguageType LanguageType { get; }
        public List<LanguageResource> ResourceList;

        public LanguageResourceService(LanguageType languageType)
        {
            LanguageType = languageType;
            ResourceList = new List<LanguageResource>();
        }

        public void LoadFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Argument is null or whitespace", nameof(filePath));

            try
            {
                using (var fileStream = File.OpenRead(filePath))
                {
                    using (var streamReader = new StreamReader(fileStream, Encoding.Default))
                    {
                        var id = 0;

                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            var key = BuildResourceId(id);

                            // If line does not contain key, continue
                            if (!IsValueInText(line, key)) continue;

                            // Extract string from between quotes
                            var value = line.Split(new[] { '"' }, 3)[1];

                            var languageResource = new LanguageResource()
                            {
                                Id = id,
                                Key = key,
                                Value = value
                            };
                            ResourceList.Add(languageResource);

                            id++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to import all values from language resource.", ex);
            }
        }

        public void SaveToFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Argument is null or whitespace", nameof(filePath));

            try
            {
                using (var fileStream = File.OpenWrite(filePath))
                {
                    using (var streamWriter = new StreamWriter(fileStream, Encoding.Default))
                    {
                        foreach (var keyValuePair in ResourceList)
                        {
                            streamWriter.WriteLine($"{keyValuePair.Key} \"{keyValuePair.Value}\"");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to export all values to language resource.", ex);
            }
        }

        public string Read(int id)
        {
            return ResourceList.Single(x => x.Id == id).Value;
        }

        public void Write(int id, string value)
        {
            ResourceList.Single(x => x.Id == id).Value = value;
        }

        private static string BuildResourceId(int id)
        {
            return "SID" + id.ToString("D6");
        }

        private static bool IsValueInText(string text, string value)
        {
            // https://stackoverflow.com/a/15464440
            return Thread.CurrentThread.CurrentCulture.CompareInfo.IndexOf(text, value, CompareOptions.IgnoreCase) >= 0;
        }
    }
}