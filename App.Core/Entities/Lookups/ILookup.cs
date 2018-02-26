using App.Core.Identities;

namespace App.Core.Entities.Lookups
{
    public interface ILookup : IIntegerIdentity
    {
        int Value { get; set; }
        string Description { get; set; }
    }
}