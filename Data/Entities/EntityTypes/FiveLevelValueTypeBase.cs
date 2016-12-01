using System.ComponentModel.DataAnnotations;
using Data.FileConnection;
using Data.ValueMapping.MappingTypes;

namespace Data.Entities.EntityTypes
{
    public class FiveLevelValueTypeBase : IFiveLevelValueType, IDataConnection
    {
        private readonly IFiveLevelMappingType _valueMapping;

        [Display(Name = "Name", Description = "")]
        public string Name { get; set; }
        [Display(Name = "⬛ ⬜ ⬜ ⬜ ⬜", Description = "")]
        public int Level1 { get; set; }
        [Display(Name = "⬛ ⬛ ⬜ ⬜ ⬜", Description = "")]
        public int Level2 { get; set; }
        [Display(Name = "⬛ ⬛ ⬛ ⬜ ⬜", Description = "")]
        public int Level3 { get; set; }
        [Display(Name = "⬛ ⬛ ⬛ ⬛ ⬜", Description = "")]
        public int Level4 { get; set; }
        [Display(Name = "⬛ ⬛ ⬛ ⬛ ⬛", Description = "")]
        public int Level5 { get; set; }

        protected FiveLevelValueTypeBase(string name, IFiveLevelMappingType valueMapping)
        {
            Name = name;
            _valueMapping = valueMapping;
        }

        public int[] GetLevels()
        {
            return new[] { Level1, Level2, Level3, Level4, Level5 };
        }

        public void SetLevels(int[] levels)
        {
            Level1 = levels[0];
            Level2 = levels[1];
            Level3 = levels[2];
            Level4 = levels[3];
            Level5 = levels[4];
        }

        public virtual void ImportData(ExecutableConnection executableConnection, LanguageConnection languageConnection)
        {
            //Name = languageConnection.Get(_valueMapping.Name);
            Level1 = executableConnection.ReadInteger(_valueMapping.Level1);
            Level2 = executableConnection.ReadInteger(_valueMapping.Level2);
            Level3 = executableConnection.ReadInteger(_valueMapping.Level3);
            Level4 = executableConnection.ReadInteger(_valueMapping.Level4);
            Level5 = executableConnection.ReadInteger(_valueMapping.Level5);
        }

        public void ExportData(ExecutableConnection executableConnection, LanguageConnection languageConnection)
        {
            //languageConnection.Set(_valueMapping.Name, Name);
            executableConnection.WriteInteger(_valueMapping.Level1, Level1);
            executableConnection.WriteInteger(_valueMapping.Level2, Level2);
            executableConnection.WriteInteger(_valueMapping.Level3, Level3);
            executableConnection.WriteInteger(_valueMapping.Level4, Level4);
            executableConnection.WriteInteger(_valueMapping.Level5, Level5);
        }
    }
}
