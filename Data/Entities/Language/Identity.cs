namespace Data.Entities.Language
{
    public class Identity : IIdentity
    {
        public int Id { get; set; }
        public int LocalResourceId { get; set; }
        public string ResourceId { get; set; }
        public string ResourceText { get; set; }
    }
}
