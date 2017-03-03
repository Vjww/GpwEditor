namespace Data.Entities.Language
{
    public interface IIdentity
    {
        int Id { get; set; }
        int LocalResourceId { get; set; }
        string ResourceId { get; set; }
        string ResourceText { get; set; }
    }
}
