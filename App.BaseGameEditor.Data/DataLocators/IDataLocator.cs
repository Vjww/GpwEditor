using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataLocators
{
    public interface IDataLocator : IIntegerIdentity
    {
        void Initialise(int id);
    }
}