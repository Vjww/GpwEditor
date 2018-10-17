using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Domain.Entities
{
    public class SponsorshipTyreEntity : IntegerIdentityBase, IEntity
    {
        public string Name { get; set; }
        public int CashRating { get; set; }
        public bool CashRatingRandom { get; set; }
        public int RadRating { get; set; }
        public bool RadRatingRandom { get; set; }
        public bool Inactive { get; set; }

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

        // TODO: Remove temporary entity/sponsor fields below, as are used in aid of module development
        public int EntityType { get; set; }
        public int EntityResource { get; set; }
        public int EntityData { get; set; }
        public int SponsorId { get; set; }
        public int SponsorType { get; set; }
    }
}