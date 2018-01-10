using System;
using App.BaseGameEditor.Data.DataConnections;
using App.BaseGameEditor.Data.Enums;
using App.Shared.Data.Catalogues.Commentary;
using App.Shared.Data.Catalogues.Language;
using App.Shared.Data.Enums;
using App.Shared.Data.Factories.Catalogues.Commentary;
using App.Shared.Data.Factories.Catalogues.Languages;
using Common.Editor.Data.DataEndpoints;
using Common.Editor.Data.FileResources;

namespace App.BaseGameEditor.Data.DataEndpoints
{
    public class BaseGameDataEndpoint : IDataEndpoint<BaseGameDataConnection>
    {
        public IFileResource GameExecutableFileResource { get; }
        public ILanguageCatalogue EnglishLanguageCatalogue { get; }
        public ILanguageCatalogue FrenchLanguageCatalogue { get; }
        public ILanguageCatalogue GermanLanguageCatalogue { get; }
        public ICommentaryCatalogue EnglishCommentaryCatalogue { get; }
        public ICommentaryCatalogue FrenchCommentaryCatalogue { get; }
        public ICommentaryCatalogue GermanCommentaryCatalogue { get; }

        public BaseGameDataEndpoint(
            IFileResource gameExecutableFileResource,
            ILanguageCatalogueFactory languageCatalogueFactory,
            ICommentaryCatalogueFactory commentaryCatalogueFactory)
        {
            GameExecutableFileResource = gameExecutableFileResource ?? throw new ArgumentNullException(nameof(gameExecutableFileResource));
            if (languageCatalogueFactory == null) throw new ArgumentNullException(nameof(languageCatalogueFactory));
            if (commentaryCatalogueFactory == null) throw new ArgumentNullException(nameof(commentaryCatalogueFactory));

            EnglishLanguageCatalogue = languageCatalogueFactory.Create(LanguageType.English);
            FrenchLanguageCatalogue = languageCatalogueFactory.Create(LanguageType.French);
            GermanLanguageCatalogue = languageCatalogueFactory.Create(LanguageType.German);
            EnglishCommentaryCatalogue = commentaryCatalogueFactory.Create(LanguageType.English);
            FrenchCommentaryCatalogue = commentaryCatalogueFactory.Create(LanguageType.French);
            GermanCommentaryCatalogue = commentaryCatalogueFactory.Create(LanguageType.German);
        }

        public void Import(BaseGameDataConnection dataConnection)
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

        public void Export(BaseGameDataConnection dataConnection)
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