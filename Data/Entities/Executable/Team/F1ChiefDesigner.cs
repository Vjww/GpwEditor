using Data.Entities.Language;
using System.ComponentModel.DataAnnotations;
using Common.Extensions;
using Data.Collections.Language;
using Data.FileConnection;
using Data.Helpers;
using Mapping = Data.ValueMapping.Executable.Team;

namespace Data.Entities.Executable.Team
{
    public class F1ChiefDesigner : IIdentity, IDataConnection
    {
        private readonly Mapping.F1ChiefDesigner _valueMapping;

        [Display(Name = "Id", Description = "The id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "The id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "The resource id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Chief Name", Description = "The name of the chief, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name = "Ability", Description = "The ability rating of the chief.")]
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Ability { get; set; }
        [Display(Name = "Age", Description = "The age of the chief at the start of the year.")]
        [Range(0, 99, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Age { get; set; }
        [Display(Name = "Salary", Description = "The salary paid to the chief.")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Salary { get; set; }
        [Display(Name = "Race Bonus", Description = "The race bonus awarded to the chief.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int RaceBonus { get; set; }
        [Display(Name = "Championship Bonus", Description = "The championship bonus awarded to the chief.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int ChampionshipBonus { get; set; }
        [Display(Name = "Driver Loyalty", Description = "The driver the chief has loyalty towards.")]
        [Range(6, 139, ErrorMessage = "Value for {0} must be between {1} and {2}.")] // TODO check for specific values?
        public int DriverLoyalty { get; set; }
        [Display(Name = "Morale", Description = "The morale level of the chief.")]
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Morale { get; set; }

        public F1ChiefDesigner(Mapping.F1ChiefDesigner valueMapping, int id)
        {
            _valueMapping = valueMapping;

            Id = id;
            LocalResourceId = Mapping.F1ChiefDesigner.GetLocalResourceId(Id);
            ResourceId = _valueMapping.Name.BuildResourceId();
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, ResourceId, ResourceText);
            executableConnection.WriteInteger(_valueMapping.Age, Age);
            executableConnection.WriteInteger(_valueMapping.Ability, Ability);
            executableConnection.WriteInteger(_valueMapping.Salary, Salary);
            executableConnection.WriteInteger(_valueMapping.RaceBonus, RaceBonus);
            executableConnection.WriteInteger(_valueMapping.ChampionshipBonus, ChampionshipBonus);
            executableConnection.WriteInteger(_valueMapping.DriverLoyalty, DriverLoyalty);
            executableConnection.WriteInteger(_valueMapping.Morale, Morale.ConvertToTwentyToHundredStepTwenty());
        }

        public void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceText = ResourceHelper.GetResourceText(identityCollection, ResourceId);
            Age = executableConnection.ReadInteger(_valueMapping.Age);
            Ability = executableConnection.ReadInteger(_valueMapping.Ability);
            Salary = executableConnection.ReadInteger(_valueMapping.Salary);
            RaceBonus = executableConnection.ReadInteger(_valueMapping.RaceBonus);
            ChampionshipBonus = executableConnection.ReadInteger(_valueMapping.ChampionshipBonus);
            DriverLoyalty = executableConnection.ReadInteger(_valueMapping.DriverLoyalty);
            Morale = executableConnection.ReadInteger(_valueMapping.Morale).ConvertToOneToFiveStepOne();
        }
    }
}