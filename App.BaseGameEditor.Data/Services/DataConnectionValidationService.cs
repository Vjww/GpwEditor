using System.Collections.Generic;
using App.BaseGameEditor.Data.DataConnections;

namespace App.BaseGameEditor.Data.Services
{
    public class DataConnectionValidationService
    {
        public IEnumerable<string> Validate(DataConnection dataConnection)
        {
            var messages = new List<string>();

            if (string.IsNullOrWhiteSpace(dataConnection.GameFolderPath))
                messages.Add($"Value {nameof(dataConnection.GameFolderPath)} cannot be null or whitespace.");
            if (string.IsNullOrWhiteSpace(dataConnection.GameExecutableFilePath))
                messages.Add($"Value {nameof(dataConnection.GameExecutableFilePath)} cannot be null or whitespace.");
            if (string.IsNullOrWhiteSpace(dataConnection.EnglishLanguageFilePath))
                messages.Add($"Value {nameof(dataConnection.EnglishLanguageFilePath)} cannot be null or whitespace.");
            if (string.IsNullOrWhiteSpace(dataConnection.FrenchLanguageFilePath))
                messages.Add($"Value {nameof(dataConnection.FrenchLanguageFilePath)} cannot be null or whitespace.");
            if (string.IsNullOrWhiteSpace(dataConnection.GermanLanguageFilePath))
                messages.Add($"Value {nameof(dataConnection.GermanLanguageFilePath)} cannot be null or whitespace.");
            if (string.IsNullOrWhiteSpace(dataConnection.EnglishCommentaryFilePath))
                messages.Add($"Value {nameof(dataConnection.EnglishCommentaryFilePath)} cannot be null or whitespace.");
            if (string.IsNullOrWhiteSpace(dataConnection.FrenchCommentaryFilePath))
                messages.Add($"Value {nameof(dataConnection.FrenchCommentaryFilePath)} cannot be null or whitespace.");
            if (string.IsNullOrWhiteSpace(dataConnection.GermanCommentaryFilePath))
                messages.Add($"Value {nameof(dataConnection.GermanCommentaryFilePath)} cannot be null or whitespace.");

            return messages;
        }
    }
}