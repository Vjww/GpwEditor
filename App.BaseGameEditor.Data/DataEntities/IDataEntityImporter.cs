namespace App.BaseGameEditor.Data.DataEntities
{
    public interface IDataEntityImporter
    {
        IDataEntity Import(int id);
    }
}