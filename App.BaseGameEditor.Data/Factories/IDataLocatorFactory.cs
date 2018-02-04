using App.BaseGameEditor.Data.DataLocators;

namespace App.BaseGameEditor.Data.Factories
{
    public interface IDataLocatorFactory<out TDataLocator>
        where TDataLocator : class, IDataLocator
    {
        TDataLocator Create();
    }
}