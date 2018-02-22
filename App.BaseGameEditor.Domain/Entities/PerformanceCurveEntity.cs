using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Domain.Entities
{
    public class PerformanceCurveEntity : IntegerIdentityBase, IEntity
    {
        public int Value { get; set; }
    }
}