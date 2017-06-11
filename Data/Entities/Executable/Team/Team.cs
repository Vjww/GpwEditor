using Common.Extensions;
using Data.Collections.Language;
using Data.Entities.Language;
using Data.FileConnection;
using Data.Helpers;
using System.ComponentModel.DataAnnotations;
using Mapping = Data.ValueMapping.Executable.Team;

namespace Data.Entities.Executable.Team
{
    public class Team : IIdentity, IDataConnection
    {
        private readonly Mapping.Team _valueMapping;

        [Display(Name = "Id", Description = "The id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "The id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "The resource id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Team Name", Description = "The name of the team, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name="Last Year's Championship Position", Description="The finishing position of the team in last year's constructors' championship (e.g. 1997 when playing the 1998 season).")]
        [Range(1, 11, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int LastPosition { get; set; }
        [Display(Name = "Last Year's Championship Points", Description = "The number of points scored by the team in last year's constructors' championship (e.g. 1997 when playing the 1998 season).")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int LastPoints { get; set; }
        [Display(Name = "Debut Grand Prix", Description = "The Grand Prix where the team made their debut.")]
        [Range(1, 19, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int FirstGpTrack { get; set; }
        [Display(Name = "Debut Year", Description = "The year when the team made their Grand Prix debut.")]
        [Range(1900, 2100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int FirstGpYear { get; set; }
        [Display(Name = "Wins", Description = "The number of wins scored by the team.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Wins { get; set; }
        [Display(Name = "This Year's Budget", Description = "An estimation of the team's budget for this year's championship (e.g. 1998 when playing the 1998 season).")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int YearlyBudget { get; set; }
        [Display(Name = "Unknown", Description = "An unknown value with an unknown usage.")]
        [Range(0, 0, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Unknown { get; set; }
        [Display(Name = "Nationality", Description = "The index of the country where the team's factory is located and represents the country map to display in the game.")]
        [Range(0, 3, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int CountryMapId { get; set; }
        [Display(Name = "Location X", Description = "The X co-ordinate of the pointer where the team's factory is located on the country map in the game.")]
        [Range(0, 800, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int LocationPointerX { get; set; } // TODO confirm range
        [Display(Name = "Location Y", Description = "The Y co-ordinate of the pointer where the team's factory is located on the country map in the game.")]
        [Range(0, 600, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int LocationPointerY { get; set; } // TODO confirm range
        [Display(Name = "This Year's Tyre Supplier", Description = "The tyre manufacturer supplying the team for this year's championship (e.g. 1998 when playing the 1998 season). Unknown usage but suspect this may be used to determine the tyre sidewalls to display.")]
        [Range(8, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int TyreSupplierId { get; set; }

        public Team(Mapping.Team valueMapping, int id)
        {
            _valueMapping = valueMapping;

            Id = id;
            LocalResourceId = Mapping.Team.GetLocalResourceId(Id);
            ResourceId = _valueMapping.Name.BuildResourceId();
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, ResourceId, ResourceText);
            executableConnection.WriteInteger(_valueMapping.LastPosition, LastPosition);
            executableConnection.WriteInteger(_valueMapping.LastPoints, LastPoints);
            executableConnection.WriteInteger(_valueMapping.FirstGpTrack, FirstGpTrack);
            executableConnection.WriteInteger(_valueMapping.FirstGpYear, FirstGpYear);
            executableConnection.WriteInteger(_valueMapping.Wins, Wins);
            executableConnection.WriteInteger(_valueMapping.YearlyBudget, YearlyBudget);
            executableConnection.WriteInteger(_valueMapping.Unknown, Unknown);
            executableConnection.WriteInteger(_valueMapping.CountryMapId, CountryMapId);
            executableConnection.WriteInteger(_valueMapping.LocationPointerX, LocationPointerX);
            executableConnection.WriteInteger(_valueMapping.LocationPointerY, LocationPointerY);
            executableConnection.WriteInteger(_valueMapping.TyreSupplierId, TyreSupplierId);
        }

        public void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceText = ResourceHelper.GetResourceText(identityCollection, ResourceId);
            LastPosition = executableConnection.ReadInteger(_valueMapping.LastPosition);
            LastPoints = executableConnection.ReadInteger(_valueMapping.LastPoints);
            FirstGpTrack = executableConnection.ReadInteger(_valueMapping.FirstGpTrack);
            FirstGpYear = executableConnection.ReadInteger(_valueMapping.FirstGpYear);
            Wins = executableConnection.ReadInteger(_valueMapping.Wins);
            YearlyBudget = executableConnection.ReadInteger(_valueMapping.YearlyBudget);
            Unknown = executableConnection.ReadInteger(_valueMapping.Unknown);
            CountryMapId = executableConnection.ReadInteger(_valueMapping.CountryMapId);
            LocationPointerX = executableConnection.ReadInteger(_valueMapping.LocationPointerX);
            LocationPointerY = executableConnection.ReadInteger(_valueMapping.LocationPointerY);
            TyreSupplierId = executableConnection.ReadInteger(_valueMapping.TyreSupplierId);
        }
    }
}