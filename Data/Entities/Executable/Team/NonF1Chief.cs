using Data.Entities.Language;
using System.ComponentModel.DataAnnotations;
using Common.Extensions;
using Data.Collections.Language;
using Data.FileConnection;
using Data.Helpers;
using ChiefMapping = Data.ValueMapping.Executable.Team;

namespace Data.Entities.Executable.Team
{
    public class NonF1Chief : INonF1Chief, IIdentity, IDataConnection
    {
        private readonly ChiefMapping.NonF1Chief _valueMapping;

        [Display(Name = "Id", Description = "The id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "The id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "The resource id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Chief Name", Description = "The name of the chief, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name = "Salary", Description = "The salary paid to the chief.")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Salary { get; set; }
        [Display(Name = "Race Bonus", Description = "The race bonus awarded to the chief (excluding Commercial Managers).")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int RaceBonus { get; set; }
        [Display(Name = "Championship Bonus", Description = "The championship bonus awarded to the chief (excluding Commercial Managers).")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int ChampionshipBonus { get; set; }
        [Display(Name = "Royalty", Description = "The royalty percentage paid to the chief (Commercial Managers only).")]
        [Range(0, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Royalty { get; set; }
        [Display(Name = "Age", Description = "The age of the chief at the start of the year.")]
        [Range(0, 99, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Age { get; set; }
        [Display(Name = "Ability", Description = "The ability rating of the chief.")]
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Ability { get; set; }

        public NonF1Chief(ChiefMapping.NonF1Chief valueMapping, int id)
        {
            _valueMapping = valueMapping;

            Id = id;
            LocalResourceId = ChiefMapping.NonF1Chief.GetLocalResourceId(Id);
            ResourceId = _valueMapping.Name.BuildResourceId();
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, ResourceId, ResourceText);
            executableConnection.WriteInteger(_valueMapping.Salary, Salary);
            executableConnection.WriteInteger(_valueMapping.RaceBonus, RaceBonus);
            executableConnection.WriteInteger(_valueMapping.ChampionshipBonus, ChampionshipBonus);
            executableConnection.WriteInteger(_valueMapping.Royalty, Royalty);
            executableConnection.WriteInteger(_valueMapping.Age, Age);
            executableConnection.WriteInteger(_valueMapping.Ability, Ability);
        }

        public void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceText = ResourceHelper.GetResourceText(identityCollection, ResourceId);
            Salary = executableConnection.ReadInteger(_valueMapping.Salary);
            RaceBonus = executableConnection.ReadInteger(_valueMapping.RaceBonus);
            ChampionshipBonus = executableConnection.ReadInteger(_valueMapping.ChampionshipBonus);
            Royalty = executableConnection.ReadInteger(_valueMapping.Royalty);
            Age = executableConnection.ReadInteger(_valueMapping.Age);
            Ability = executableConnection.ReadInteger(_valueMapping.Ability);
        }
    }
}
