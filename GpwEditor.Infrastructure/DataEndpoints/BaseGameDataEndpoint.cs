using System;
using Common.Editor.Data.DataEndpoints;
using Common.Editor.Data.FileResources;
using GpwEditor.Infrastructure.Catalogues.Commentary;
using GpwEditor.Infrastructure.Catalogues.Language;
using GpwEditor.Infrastructure.DataConnections;
using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.DataEndpoints
{
    public class BaseGameDataEndpoint : IDataEndpoint<BaseGameDataConnection>
    {
        public IFileResource GameExecutableResource { get; }
        public LanguageCatalogue EnglishLanguageCatalogue { get; }
        public LanguageCatalogue FrenchLanguageCatalogue { get; }
        public LanguageCatalogue GermanLanguageCatalogue { get; }
        public EnglishCommentaryCatalogue EnglishCommentaryCatalogue { get; }
        public FrenchCommentaryCatalogue FrenchCommentaryCatalogue { get; }
        public GermanCommentaryCatalogue GermanCommentaryCatalogue { get; }

        public BaseGameDataEndpoint(
            IFileResource gameExecutableResource,
            LanguageCatalogue englishLanguageCatalogue,
            LanguageCatalogue frenchLanguageCatalogue,
            LanguageCatalogue germanLanguageCatalogue,
            EnglishCommentaryCatalogue englishCommentaryCatalogue,
            FrenchCommentaryCatalogue frenchCommentaryCatalogue,
            GermanCommentaryCatalogue germanCommentaryCatalogue)
        {
            GameExecutableResource = gameExecutableResource ?? throw new ArgumentNullException(nameof(gameExecutableResource));
            EnglishLanguageCatalogue = englishLanguageCatalogue ?? throw new ArgumentNullException(nameof(englishLanguageCatalogue));
            FrenchLanguageCatalogue = frenchLanguageCatalogue ?? throw new ArgumentNullException(nameof(frenchLanguageCatalogue));
            GermanLanguageCatalogue = germanLanguageCatalogue ?? throw new ArgumentNullException(nameof(germanLanguageCatalogue));
            EnglishCommentaryCatalogue = englishCommentaryCatalogue ?? throw new ArgumentNullException(nameof(englishCommentaryCatalogue));
            FrenchCommentaryCatalogue = frenchCommentaryCatalogue ?? throw new ArgumentNullException(nameof(frenchCommentaryCatalogue));
            GermanCommentaryCatalogue = germanCommentaryCatalogue ?? throw new ArgumentNullException(nameof(germanCommentaryCatalogue));

            EnglishLanguageCatalogue.LanguageType = LanguageType.English;
            FrenchLanguageCatalogue.LanguageType = LanguageType.French;
            GermanLanguageCatalogue.LanguageType = LanguageType.German;
        }

        public void Import(BaseGameDataConnection dataConnection)
        {
            if (dataConnection == null) throw new ArgumentNullException(nameof(dataConnection));

            GameExecutableResource.Import(dataConnection.GameExecutableFilePath);
            EnglishLanguageCatalogue.Import(dataConnection.EnglishLanguageFilePath);
            FrenchLanguageCatalogue.Import(dataConnection.FrenchLanguageFilePath);
            GermanLanguageCatalogue.Import(dataConnection.GermanLanguageFilePath);
            EnglishCommentaryCatalogue.Import(dataConnection.EnglishCommentaryFilePath);
            FrenchCommentaryCatalogue.Import(dataConnection.FrenchCommentaryFilePath);
            GermanCommentaryCatalogue.Import(dataConnection.GermanCommentaryFilePath);
        }

        public void Export(BaseGameDataConnection dataConnection)
        {
            if (dataConnection == null) throw new ArgumentNullException(nameof(dataConnection));

            GameExecutableResource.Export(dataConnection.GameExecutableFilePath);
            EnglishLanguageCatalogue.Export(dataConnection.EnglishLanguageFilePath);
            FrenchLanguageCatalogue.Export(dataConnection.FrenchLanguageFilePath);
            GermanLanguageCatalogue.Export(dataConnection.GermanLanguageFilePath);
            EnglishCommentaryCatalogue.Export(dataConnection.EnglishCommentaryFilePath);
            FrenchCommentaryCatalogue.Export(dataConnection.FrenchCommentaryFilePath);
            GermanCommentaryCatalogue.Export(dataConnection.GermanCommentaryFilePath);
        }
    }
}