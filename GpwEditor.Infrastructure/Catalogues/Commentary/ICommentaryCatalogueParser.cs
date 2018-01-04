using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Catalogues.Commentary
{
    public interface ICommentaryCatalogueParser
    {
        string BuildFileName(CommentaryCatalogueItem catalogueItem);
        string BuildTranscript(CommentaryCatalogueItem catalogueItem);
        string ExtractFileName(string text);
        string ExtractFileNamePrefix(string fileName, CommentaryType commentaryType);
        string ExtractFileNameSuffix(CommentaryType commentaryType);
        string ExtractTranscript(string text);
        string ExtractTranscriptPrefix(string transcript, CommentaryType commentaryType);
        string ExtractTranscriptSuffix(CommentaryType commentaryType);
        CommentaryType GetCommentaryType(int id);
        string GetLeftAngleBracket();
        string GetRightAngleBracket();
        int IndexOfValueInText(string text, string value);
        bool IsValueInText(string text, string value);
        void Validate(string text, int lineNumber, out string validationMessage);
    }
}