using App.Core.Identities;

namespace App.BaseGameEditor.Infrastructure.Objects
{
    public class CarNumbersObject : IntegerIdentityBase
    {
        public int CarNumberDriver1 { get; set; }
        public int CarNumberDriver2 { get; set; }
    }
}