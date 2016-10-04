namespace Data.Entities.Language
{
    public interface IIdentity
    {
        int Id { get; set; }
        int LocalResourceId { get; set; }
        string ResourceId { get; set; }
        string ResourceText { get; set; }
    }

    public class Identity : IIdentity
    {
        public int Id { get; set; }
        public int LocalResourceId { get; set; }
        public string ResourceId { get; set; }
        public string ResourceText { get; set; }
    }
}
