using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class PerformanceCurveDataEntity : IntegerIdentityBase, IEntity
    {
        public int Value { get; set; }
    }
}