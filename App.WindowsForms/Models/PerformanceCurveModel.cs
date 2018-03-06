using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class PerformanceCurveModel : IntegerIdentityBase, IEntity
    {
        public int Value { get; set; }
    }
}