using Data.Entities.Language;
using System.ComponentModel.DataAnnotations;
using Common.Extensions;
using Data.Collections.Language;
using Data.FileConnection;
using Data.Helpers;
using Mapping = Data.ValueMapping.Executable.Team;

namespace Data.Entities.Executable.Team
{
    public class F1Driver : IIdentity, IDataConnection
    {
        private readonly Mapping.F1Driver _valueMapping;

        [Display(Name = "Id", Description = "The id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "The id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "The resource id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Driver Name", Description = "The name of the driver, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name = "Salary", Description = "The salary paid to the driver. Pay drivers will have a negative salary amount (e.g. -3500000).")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Salary { get; set; }
        [Display(Name = "Race Bonus", Description = "The race bonus awarded to the driver.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int RaceBonus { get; set; }
        [Display(Name = "Championship Bonus", Description = "The championship bonus awarded to the driver.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int ChampionshipBonus { get; set; }
        [Display(Name = "Pay Driver Rating", Description = "The funding rating of the pay driver.")]
        [Range(0, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int PayRating { get; set; }
        [Display(Name = "Pay Driver Salary", Description = "The absolute value of the salary paid by the pay driver (for pay drivers only, e.g. 3500000).")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int PositiveSalary { get; set; }
        [Display(Name = "Last Year's Championship Position", Description = "The finishing position of the driver in last year's drivers' championship (e.g. 1997 when playing the 1998 season).")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int LastChampionshipPosition { get; set; }
        [Display(Name = "Driver Role", Description = "The role of the driver in the team, as agreed in the driver's contract.")]
        [Range(1, 4, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int DriverRole { get; set; }
        [Display(Name = "Car Number A", Description = "The car number used by the driver for the season.")]
        [Range(0, 23, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int CarNumberA { get; set; }
        [Display(Name = "Car Number B", Description = "The car number used by the driver for the season.")]
        [Range(0, 23, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int CarNumberB { get; set; }
        [Display(Name = "Age", Description = "The age of the driver at the start of the year.")]
        [Range(0, 99, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Age { get; set; }
        [Display(Name = "Nationality", Description = "The nationality of the driver.")]
        [Range(1, 14, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Nationality { get; set; }
        [Display(Name = "Commentary Index", Description = "The index of the commentary sound/text of the driver.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int CommentaryIndex { get; set; }

        [Display(Name = "Championships", Description = "The number of championships the driver has won.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int CareerChampionships { get; set; }
        [Display(Name = "Races", Description = "The number of races the driver has entered/started.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int CareerRaces { get; set; }
        [Display(Name = "Wins", Description = "The number of wins scored by the driver.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int CareerWins { get; set; }
        [Display(Name = "Points", Description = "The number of points scored by the driver.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int CareerPoints { get; set; }
        [Display(Name = "Fastest Laps", Description = "The number of fastest laps claimed by the driver.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int CareerFastestLaps { get; set; }
        [Display(Name = "Points Finishes", Description = "The number of points finishes scored by the driver.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int CareerPointsFinishes { get; set; }
        [Display(Name = "Pole Positions", Description = "The number of pole positions claimed by the driver.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int CareerPolePositions { get; set; }

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

        public F1Driver(Mapping.F1Driver valueMapping, int id)
        {
            _valueMapping = valueMapping;

            Id = id;
            LocalResourceId = Mapping.F1Driver.GetLocalResourceId(Id);
            ResourceId = _valueMapping.Name.BuildResourceId();
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, ResourceId, ResourceText);
            executableConnection.WriteInteger(_valueMapping.Salary, Salary);
            executableConnection.WriteInteger(_valueMapping.RaceBonus, RaceBonus);
            executableConnection.WriteInteger(_valueMapping.ChampionshipBonus, ChampionshipBonus);
            executableConnection.WriteInteger(_valueMapping.PayRating, PayRating);
            executableConnection.WriteInteger(_valueMapping.PositiveSalary, PositiveSalary);
            executableConnection.WriteInteger(_valueMapping.LastChampionshipPosition, LastChampionshipPosition);
            executableConnection.WriteInteger(_valueMapping.DriverRole, DriverRole);
            executableConnection.WriteInteger(_valueMapping.CarNumberA, CarNumberA);
            executableConnection.WriteInteger(_valueMapping.Age, Age);
            executableConnection.WriteInteger(_valueMapping.Nationality, Nationality);
            executableConnection.WriteInteger(_valueMapping.CommentaryIndex, CommentaryIndex);
            executableConnection.WriteInteger(_valueMapping.CareerChampionships, CareerChampionships);
            executableConnection.WriteInteger(_valueMapping.CareerRaces, CareerRaces);
            executableConnection.WriteInteger(_valueMapping.CareerWins, CareerWins);
            executableConnection.WriteInteger(_valueMapping.CareerPoints, CareerPoints);
            executableConnection.WriteInteger(_valueMapping.CareerFastestLaps, CareerFastestLaps);
            executableConnection.WriteInteger(_valueMapping.CareerPointsFinishes, CareerPointsFinishes);
            executableConnection.WriteInteger(_valueMapping.CareerPolePositions, CareerPolePositions);
            executableConnection.WriteInteger(_valueMapping.Speed, Speed);
            executableConnection.WriteInteger(_valueMapping.Skill, Skill);
            executableConnection.WriteInteger(_valueMapping.Overtaking, Overtaking);
            executableConnection.WriteInteger(_valueMapping.WetWeather, WetWeather);
            executableConnection.WriteInteger(_valueMapping.Concentration, Concentration);
            executableConnection.WriteInteger(_valueMapping.Experience, Experience);
            executableConnection.WriteInteger(_valueMapping.Stamina, Stamina);
            executableConnection.WriteInteger(_valueMapping.Morale, Morale.ConvertToTwentyToHundredStepTwenty());

            // Only write value if driver is driver 1 or 2, and not T.
            var driverId = LocalResourceId % 8;
            if (driverId == 6 || driverId == 7) // 1 and 2
            {
                executableConnection.WriteInteger(_valueMapping.CarNumberB, CarNumberB);
            }
        }

        public void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceText = ResourceHelper.GetResourceText(identityCollection, ResourceId);
            Salary = executableConnection.ReadInteger(_valueMapping.Salary);
            RaceBonus = executableConnection.ReadInteger(_valueMapping.RaceBonus);
            ChampionshipBonus = executableConnection.ReadInteger(_valueMapping.ChampionshipBonus);
            PayRating = executableConnection.ReadInteger(_valueMapping.PayRating);
            PositiveSalary = executableConnection.ReadInteger(_valueMapping.PositiveSalary);
            LastChampionshipPosition = executableConnection.ReadInteger(_valueMapping.LastChampionshipPosition);
            DriverRole = executableConnection.ReadInteger(_valueMapping.DriverRole);
            CarNumberA = executableConnection.ReadInteger(_valueMapping.CarNumberA);
            Age = executableConnection.ReadInteger(_valueMapping.Age);
            Nationality = executableConnection.ReadInteger(_valueMapping.Nationality);
            CommentaryIndex = executableConnection.ReadInteger(_valueMapping.CommentaryIndex);
            CareerChampionships = executableConnection.ReadInteger(_valueMapping.CareerChampionships);
            CareerRaces = executableConnection.ReadInteger(_valueMapping.CareerRaces);
            CareerWins = executableConnection.ReadInteger(_valueMapping.CareerWins);
            CareerPoints = executableConnection.ReadInteger(_valueMapping.CareerPoints);
            CareerFastestLaps = executableConnection.ReadInteger(_valueMapping.CareerFastestLaps);
            CareerPointsFinishes = executableConnection.ReadInteger(_valueMapping.CareerPointsFinishes);
            CareerPolePositions = executableConnection.ReadInteger(_valueMapping.CareerPolePositions);
            Speed = executableConnection.ReadInteger(_valueMapping.Speed);
            Skill = executableConnection.ReadInteger(_valueMapping.Skill);
            Overtaking = executableConnection.ReadInteger(_valueMapping.Overtaking);
            WetWeather = executableConnection.ReadInteger(_valueMapping.WetWeather);
            Concentration = executableConnection.ReadInteger(_valueMapping.Concentration);
            Experience = executableConnection.ReadInteger(_valueMapping.Experience);
            Stamina = executableConnection.ReadInteger(_valueMapping.Stamina);
            Morale = executableConnection.ReadInteger(_valueMapping.Morale).ConvertToOneToFiveStepOne();

            // Only read value if driver is driver 1 or 2, and not T.
            var driverId = LocalResourceId % 8;
            if (driverId == 6 || driverId == 7) // 1 and 2
            {
                CarNumberB = executableConnection.ReadInteger(_valueMapping.CarNumberB);
            }
        }
    }
}