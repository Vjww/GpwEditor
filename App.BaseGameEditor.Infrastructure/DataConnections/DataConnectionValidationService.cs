using System.Collections.Generic;
using App.BaseGameEditor.Data.DataConnections;

namespace App.BaseGameEditor.Infrastructure.DataConnections
{
    public class DataConnectionValidationService : IDataConnectionValidationService<DataConnection>
    {
        public IEnumerable<string> Validate(DataConnection dataConnection)
        {
            var validationFailedMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(dataConnection.GameFolderPath))
                validationFailedMessages.Add($"Value {nameof(dataConnection.GameFolderPath)} cannot be null or whitespace.");
            if (string.IsNullOrWhiteSpace(dataConnection.GameExecutableFilePath))
                validationFailedMessages.Add($"Value {nameof(dataConnection.GameExecutableFilePath)} cannot be null or whitespace.");
            if (string.IsNullOrWhiteSpace(dataConnection.EnglishLanguageFilePath))
                validationFailedMessages.Add($"Value {nameof(dataConnection.EnglishLanguageFilePath)} cannot be null or whitespace.");
            if (string.IsNullOrWhiteSpace(dataConnection.FrenchLanguageFilePath))
                validationFailedMessages.Add($"Value {nameof(dataConnection.FrenchLanguageFilePath)} cannot be null or whitespace.");
            if (string.IsNullOrWhiteSpace(dataConnection.GermanLanguageFilePath))
                validationFailedMessages.Add($"Value {nameof(dataConnection.GermanLanguageFilePath)} cannot be null or whitespace.");
            if (string.IsNullOrWhiteSpace(dataConnection.EnglishCommentaryFilePath))
                validationFailedMessages.Add($"Value {nameof(dataConnection.EnglishCommentaryFilePath)} cannot be null or whitespace.");
            if (string.IsNullOrWhiteSpace(dataConnection.FrenchCommentaryFilePath))
                validationFailedMessages.Add($"Value {nameof(dataConnection.FrenchCommentaryFilePath)} cannot be null or whitespace.");
            if (string.IsNullOrWhiteSpace(dataConnection.GermanCommentaryFilePath))
                validationFailedMessages.Add($"Value {nameof(dataConnection.GermanCommentaryFilePath)} cannot be null or whitespace.");

            return validationFailedMessages;
        }
    }
}