using App.Core.Identities;

namespace App.Core.Factories
{
    public interface IIntegerIdentityFactory<out TIntegerIdentity>
        where TIntegerIdentity : class, IIntegerIdentity
    {
        TIntegerIdentity Create(int id);
    }
}