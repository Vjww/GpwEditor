using System;
using App.BaseGameEditor.Data.Catalogues.Commentary;
using App.BaseGameEditor.Data.Catalogues.Language;
using App.BaseGameEditor.Data.DataConnections;
using App.BaseGameEditor.Data.FileResources;

namespace App.BaseGameEditor.Data.DataEndpoints
{
    public class DataEndpoint
    {
        public FileResource GameExecutableFileResource { get; }
        public EnglishLanguageCatalogue EnglishLanguageCatalogue { get; }
        public FrenchLanguageCatalogue FrenchLanguageCatalogue { get; }
        public GermanLanguageCatalogue GermanLanguageCatalogue { get; }
        public EnglishCommentaryCatalogue EnglishCommentaryCatalogue { get; }
        public FrenchCommentaryCatalogue FrenchCommentaryCatalogue { get; }
        public GermanCommentaryCatalogue GermanCommentaryCatalogue { get; }

        public DataEndpoint(
            FileResource gameExecutableFileResource,
            EnglishLanguageCatalogue englishLanguageCatalogue,
            FrenchLanguageCatalogue frenchLanguageCatalogue,
            GermanLanguageCatalogue germanLanguageCatalogue,
            EnglishCommentaryCatalogue englishCommentaryCatalogue,
            FrenchCommentaryCatalogue frenchCommentaryCatalogue,
            GermanCommentaryCatalogue germanCommentaryCatalogue)
        {
            EnglishLanguageCatalogue = englishLanguageCatalogue ?? throw new ArgumentNullException(nameof(englishLanguageCatalogue));
            FrenchLanguageCatalogue = frenchLanguageCatalogue ?? throw new ArgumentNullException(nameof(frenchLanguageCatalogue));
            GermanLanguageCatalogue = germanLanguageCatalogue ?? throw new ArgumentNullException(nameof(germanLanguageCatalogue));
            EnglishCommentaryCatalogue = englishCommentaryCatalogue ?? throw new ArgumentNullException(nameof(englishCommentaryCatalogue));
            FrenchCommentaryCatalogue = frenchCommentaryCatalogue ?? throw new ArgumentNullException(nameof(frenchCommentaryCatalogue));
            GermanCommentaryCatalogue = germanCommentaryCatalogue ?? throw new ArgumentNullException(nameof(germanCommentaryCatalogue));
            GameExecutableFileResource = gameExecutableFileResource ?? throw new ArgumentNullException(nameof(gameExecutableFileResource));
        }

        public void Import(DataConnection dataConnection)
        {
            if (dataConnection == null) throw new ArgumentNullException(nameof(dataConnection));

            GameExecutableFileResource.Import(dataConnection.GameExecutableFilePath);
            EnglishLanguageCatalogue.Import(dataConnection.EnglishLanguageFilePath);
            FrenchLanguageCatalogue.Import(dataConnection.FrenchLanguageFilePath);
            GermanLanguageCatalogue.Import(dataConnection.GermanLanguageFilePath);
            EnglishCommentaryCatalogue.Import(dataConnection.EnglishCommentaryFilePath);
            FrenchCommentaryCatalogue.Import(dataConnection.FrenchCommentaryFilePath);
            GermanCommentaryCatalogue.Import(dataConnection.GermanCommentaryFilePath);
        }

        public void Export(DataConnection dataConnection)
        {
            if (dataConnection == null) throw new ArgumentNullException(nameof(dataConnection));

            GameExecutableFileResource.Export(dataConnection.GameExecutableFilePath);
            EnglishLanguageCatalogue.Export(dataConnection.EnglishLanguageFilePath);
            FrenchLanguageCatalogue.Export(dataConnection.FrenchLanguageFilePath);
            GermanLanguageCatalogue.Export(dataConnection.GermanLanguageFilePath);
            EnglishCommentaryCatalogue.Export(dataConnection.EnglishCommentaryFilePath);
            FrenchCommentaryCatalogue.Export(dataConnection.FrenchCommentaryFilePath);
            GermanCommentaryCatalogue.Export(dataConnection.GermanCommentaryFilePath);
        }
    }
}