using System.Collections.Generic;
using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class SponsorModel : IntegerIdentityBase, IEntity
    {
        public string Name { get; set; }
        public int SponsorId { get; set; }
        public int SponsorTypeId { get; set; }
        public int EntityType { get; set; }
        public int EntityResource { get; set; }
        public int EntityData { get; set; }

        public int CashRating { get; set; }
        public bool CashRatingRandom { get; set; }
        public int RadRating { get; set; }
        public bool RadRatingRandom { get; set; }
        public bool Inactive { get; set; }

        public int Fuel { get; set; }
        public int Heat { get; set; }
        public int Power { get; set; }
        public int Reliability { get; set; }
        public int Response { get; set; }
        public int Rigidity { get; set; }
        public int Weight { get; set; }

        public int DryHardGrip { get; set; }
        public int DryHardResilience { get; set; }
        public int DryHardStiffness { get; set; }
        public int DryHardTemperature { get; set; }
        public int DrySoftGrip { get; set; }
        public int DrySoftResilience { get; set; }
        public int DrySoftStiffness { get; set; }
        public int DrySoftTemperature { get; set; }
        public int IntermediateGrip { get; set; }
        public int IntermediateResilience { get; set; }
        public int IntermediateStiffness { get; set; }
        public int IntermediateTemperature { get; set; }
        public int WetWeatherGrip { get; set; }
        public int WetWeatherResilience { get; set; }
        public int WetWeatherStiffness { get; set; }
        public int WetWeatherTemperature { get; set; }

        public int Performance { get; set; }
        public int Tolerance { get; set; }
    }
}