using System;
using Common.Editor.Data.DataEndpoints;
using Common.Editor.Data.FileResources;
using GpwEditor.Infrastructure.Catalogues;
using GpwEditor.Infrastructure.Catalogues.Commentary;
using GpwEditor.Infrastructure.Catalogues.Language;
using GpwEditor.Infrastructure.DataConnections;
using GpwEditor.Infrastructure.Factories;

namespace GpwEditor.Infrastructure.DataEndpoints
{
    public class BaseGameDataEndpoint : IDataEndpoint<BaseGameDataConnection>
    {
        public IFileResource GameExecutableResource { get; }
        public ILanguageCatalogue EnglishLanguageCatalogue { get; }
        public ILanguageCatalogue FrenchLanguageCatalogue { get; }
        public ILanguageCatalogue GermanLanguageCatalogue { get; }
        public ICommentaryCatalogue EnglishCommentaryCatalogue { get; }
        public ICommentaryCatalogue FrenchCommentaryCatalogue { get; }
        public ICommentaryCatalogue GermanCommentaryCatalogue { get; }

        public BaseGameDataEndpoint(
            IFileResource gameExecutableResource,
            ILanguageCatalogueFactory languageCatalogueFactory,
            ICommentaryCatalogueFactory commentaryCatalogueFactory)
        {
            GameExecutableResource = gameExecutableResource ?? throw new ArgumentNullException(nameof(gameExecutableResource));
            if (languageCatalogueFactory == null) throw new ArgumentNullException(nameof(languageCatalogueFactory));
            if (commentaryCatalogueFactory == null) throw new ArgumentNullException(nameof(commentaryCatalogueFactory));

            EnglishLanguageCatalogue = languageCatalogueFactory.Create(LanguageEnum.English);
            FrenchLanguageCatalogue = languageCatalogueFactory.Create(LanguageEnum.French);
            GermanLanguageCatalogue = languageCatalogueFactory.Create(LanguageEnum.German);
            EnglishCommentaryCatalogue = commentaryCatalogueFactory.Create(LanguageEnum.English);
            FrenchCommentaryCatalogue = commentaryCatalogueFactory.Create(LanguageEnum.French);
            GermanCommentaryCatalogue = commentaryCatalogueFactory.Create(LanguageEnum.German);
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