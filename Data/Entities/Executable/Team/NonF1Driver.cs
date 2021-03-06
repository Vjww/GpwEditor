﻿using Data.Entities.Language;
using System.ComponentModel.DataAnnotations;
using Common.Extensions;
using Data.Collections.Language;
using Data.FileConnection;
using Data.Helpers;
using Mapping = Data.ValueMapping.Executable.Team;

namespace Data.Entities.Executable.Team
{
    public class NonF1Driver : IIdentity, IDataConnection
    {
        private readonly Mapping.NonF1Driver _valueMapping;

        [Display(Name = "Id", Description = "The id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "The id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "The resource id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Driver Name", Description = "The name of the driver, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name = "Salary", Description = "The salary paid to the driver.")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Salary { get; set; }
        [Display(Name = "Race Bonus", Description = "The race bonus awarded to the driver.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int RaceBonus { get; set; }
        [Display(Name = "Championship Bonus", Description = "The championship bonus awarded to the driver.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int ChampionshipBonus { get; set; }
        [Display(Name = "Age", Description = "The age of the driver at the start of the year.")]
        [Range(0, 99, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Age { get; set; }
        [Display(Name = "Nationality", Description = "The nationality of the driver.")]
        [Range(1, 14, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Nationality { get; set; }
        [Display(Name = "Unknown", Description = "The unknown_value of the driver.")] // TODO identify
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")] // TODO range
        public int Unknown { get; set; }
        [Display(Name = "Commentary Index", Description = "The index of the commentary sound/text of the driver.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int CommentaryIndex { get; set; }

        [Display(Name = "Speed", Description = "The speed rating of the driver.")]
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Speed { get; set; }
        [Display(Name = "Skill", Description = "The skill rating of the driver.")]
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Skill { get; set; }
        [Display(Name = "Overtaking", Description = "The overtaking rating of the driver.")]
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Overtaking { get; set; }
        [Display(Name = "Wet Weather", Description = "The wet weather rating of the driver.")]
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int WetWeather { get; set; }
        [Display(Name = "Concentration", Description = "The concentration rating of the driver.")]
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Concentration { get; set; }
        [Display(Name = "Experience", Description = "The experience rating of the driver.")]
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Experience { get; set; }
        [Display(Name = "Stamina", Description = "The stamina rating of the driver.")]
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Stamina { get; set; }
        [Display(Name = "Morale", Description = "The morale level of the driver.")]
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Morale { get; set; }

        public NonF1Driver(Mapping.NonF1Driver valueMapping, int id)
        {
            _valueMapping = valueMapping;

            Id = id;
            LocalResourceId = Mapping.NonF1Driver.GetLocalResourceId(Id);
            ResourceId = _valueMapping.Name.BuildResourceId();
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, ResourceId, ResourceText);
            executableConnection.WriteInteger(_valueMapping.Salary, Salary);
            executableConnection.WriteInteger(_valueMapping.RaceBonus, RaceBonus);
            executableConnection.WriteInteger(_valueMapping.ChampionshipBonus, ChampionshipBonus);
            executableConnection.WriteInteger(_valueMapping.Age, Age);
            executableConnection.WriteInteger(_valueMapping.Nationality, Nationality);
            executableConnection.WriteInteger(_valueMapping.Unknown, Unknown);
            executableConnection.WriteInteger(_valueMapping.CommentaryIndex, CommentaryIndex);
            executableConnection.WriteInteger(_valueMapping.Speed, Speed);
            executableConnection.WriteInteger(_valueMapping.Skill, Skill);
            executableConnection.WriteInteger(_valueMapping.Overtaking, Overtaking);
            executableConnection.WriteInteger(_valueMapping.WetWeather, WetWeather);
            executableConnection.WriteInteger(_valueMapping.Concentration, Concentration);
            executableConnection.WriteInteger(_valueMapping.Experience, Experience);
            executableConnection.WriteInteger(_valueMapping.Stamina, Stamina);
            executableConnection.WriteInteger(_valueMapping.Morale, Morale);
        }

        public void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceText = ResourceHelper.GetResourceText(identityCollection, ResourceId);
            Salary = executableConnection.ReadInteger(_valueMapping.Salary);
            RaceBonus = executableConnection.ReadInteger(_valueMapping.RaceBonus);
            ChampionshipBonus = executableConnection.ReadInteger(_valueMapping.ChampionshipBonus);
            Age = executableConnection.ReadInteger(_valueMapping.Age);
            Nationality = executableConnection.ReadInteger(_valueMapping.Nationality);
            Unknown = executableConnection.ReadInteger(_valueMapping.Unknown);
            CommentaryIndex = executableConnection.ReadInteger(_valueMapping.CommentaryIndex);
            Speed = executableConnection.ReadInteger(_valueMapping.Speed);
            Skill = executableConnection.ReadInteger(_valueMapping.Skill);
            Overtaking = executableConnection.ReadInteger(_valueMapping.Overtaking);
            WetWeather = executableConnection.ReadInteger(_valueMapping.WetWeather);
            Concentration = executableConnection.ReadInteger(_valueMapping.Concentration);
            Experience = executableConnection.ReadInteger(_valueMapping.Experience);
            Stamina = executableConnection.ReadInteger(_valueMapping.Stamina);
            Morale = executableConnection.ReadInteger(_valueMapping.Morale);
        }
    }
}