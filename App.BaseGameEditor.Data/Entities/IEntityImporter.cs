namespace App.BaseGameEditor.Data.Entities
{
    public interface IEntityImporter
    {
        IEntity Import(int id);
    }
}