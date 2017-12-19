using GpwEditor.Infrastructure.DataConnections;

namespace GpwEditor.Application.DataConnections
{
    public class BaseGameDataConnectionValidator : IDataConnectionValidator<BaseGameDataConnection>
    {
        public bool Validate(BaseGameDataConnection dataConnection)
        {
            if (string.IsNullOrWhiteSpace(dataConnection.GameFolderPath)) return false;
            if (string.IsNullOrWhiteSpace(dataConnection.GameExecutableFilePath)) return false;
            if (string.IsNullOrWhiteSpace(dataConnection.EnglishLanguageFilePath)) return false;
            if (string.IsNullOrWhiteSpace(dataConnection.FrenchLanguageFilePath)) return false;
            if (string.IsNullOrWhiteSpace(dataConnection.GermanLanguageFilePath)) return false;
            if (string.IsNullOrWhiteSpace(dataConnection.EnglishCommentaryFilePath)) return false;
            if (string.IsNullOrWhiteSpace(dataConnection.FrenchCommentaryFilePath)) return false;
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (string.IsNullOrWhiteSpace(dataConnection.GermanCommentaryFilePath)) return false;
            return true;
        }
    }
}