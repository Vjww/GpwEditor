namespace GpwEditor.Infrastructure.Services
{
    public class CommentaryResource
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileNamePrefix { get; set; }
        public string FileNameSuffix { get; set; }
        public string Transcript { get; set; }
        public string TranscriptPrefix { get; set; }
        public string TranscriptSuffix { get; set; }
        public CommentaryType CommentaryType { get; set; }
    }
}