using System;
using Common.Editor.Infrastructure.Catalogues;
using Common.Editor.Infrastructure.DataContexts;
using Common.Editor.Infrastructure.FileResources;
using GpwEditor.Infrastructure.Catalogues;
using GpwEditor.Infrastructure.DataConnections;

namespace GpwEditor.Infrastructure.DataContexts
{
    public class BaseGameDataContext : IDataContext<BaseGameDataConnection>
    {
        private readonly IFileResourceExporter _fileResourceExporter;
        private readonly IFileResourceImporter _fileResourceImporter;
        private readonly ICatalogueExporter<ICatalogueItem> _catalogueExporter;
        private readonly ICatalogueImporter<ICatalogueItem> _catalogueImporter;

        public IFileResource GameExecutableResource { get; private set; }
        public LanguageCatalogue EnglishLanguageCatalogue { get; private set; }
        public LanguageCatalogue FrenchLanguageCatalogue { get; private set; }
        public LanguageCatalogue GermanLanguageCatalogue { get; private set; }
        public CommentaryCatalogue EnglishCommentaryCatalogue { get; private set; }
        public CommentaryCatalogue FrenchCommentaryCatalogue { get; private set; }
        public CommentaryCatalogue GermanCommentaryCatalogue { get; private set; }

        public BaseGameDataContext(
            IFileResourceExporter fileResourceExporter,
            IFileResourceImporter fileResourceImporter,
            ICatalogueExporter<ICatalogueItem> catalogueExporter,
            ICatalogueImporter<ICatalogueItem> catalogueImporter,
            IFileResource gameExecutableResource,
            LanguageCatalogue englishLanguageCatalogue,
            LanguageCatalogue frenchLanguageCatalogue,
            LanguageCatalogue germanLanguageCatalogue,
            CommentaryCatalogue englishCommentaryCatalogue,
            CommentaryCatalogue frenchCommentaryCatalogue,
            CommentaryCatalogue germanCommentaryCatalogue)
        {
            _fileResourceExporter = fileResourceExporter ?? throw new ArgumentNullException(nameof(fileResourceExporter));
            _fileResourceImporter = fileResourceImporter ?? throw new ArgumentNullException(nameof(fileResourceImporter));
            _catalogueImporter = catalogueImporter ?? throw new ArgumentNullException(nameof(catalogueImporter));
            _catalogueExporter = catalogueExporter ?? throw new ArgumentNullException(nameof(catalogueExporter));
            GameExecutableResource = gameExecutableResource ?? throw new ArgumentNullException(nameof(gameExecutableResource));
            EnglishLanguageCatalogue = englishLanguageCatalogue ?? throw new ArgumentNullException(nameof(englishLanguageCatalogue));
            FrenchLanguageCatalogue = frenchLanguageCatalogue ?? throw new ArgumentNullException(nameof(frenchLanguageCatalogue));
            GermanLanguageCatalogue = germanLanguageCatalogue ?? throw new ArgumentNullException(nameof(germanLanguageCatalogue));
            EnglishCommentaryCatalogue = englishCommentaryCatalogue ?? throw new ArgumentNullException(nameof(englishCommentaryCatalogue));
            FrenchCommentaryCatalogue = frenchCommentaryCatalogue ?? throw new ArgumentNullException(nameof(frenchCommentaryCatalogue));
            GermanCommentaryCatalogue = germanCommentaryCatalogue ?? throw new ArgumentNullException(nameof(germanCommentaryCatalogue));
        }

        public void Import(BaseGameDataConnection connection)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));

            GameExecutableResource = _fileResourceImporter.Import(connection.GameExecutableFilePath);
            EnglishLanguageCatalogue = _catalogueImporter.Import(connection.EnglishLanguageFilePath) as LanguageCatalogue;
            FrenchLanguageCatalogue = _catalogueImporter.Import(connection.FrenchLanguageFilePath) as LanguageCatalogue;
            GermanLanguageCatalogue = _catalogueImporter.Import(connection.GermanLanguageFilePath) as LanguageCatalogue;
            EnglishCommentaryCatalogue = _catalogueImporter.Import(connection.EnglishCommentaryFilePath) as CommentaryCatalogue;
            FrenchCommentaryCatalogue = _catalogueImporter.Import(connection.FrenchCommentaryFilePath) as CommentaryCatalogue;
            GermanCommentaryCatalogue = _catalogueImporter.Import(connection.GermanCommentaryFilePath) as CommentaryCatalogue;
        }

        public void Export(BaseGameDataConnection connection)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));

            _fileResourceExporter.Export(GameExecutableResource, connection.GameExecutableFilePath);
            _catalogueExporter.Export(EnglishLanguageCatalogue, connection.EnglishLanguageFilePath);
            _catalogueExporter.Export(FrenchLanguageCatalogue, connection.FrenchLanguageFilePath);
            _catalogueExporter.Export(GermanLanguageCatalogue, connection.GermanLanguageFilePath);
            _catalogueExporter.Export(EnglishCommentaryCatalogue, connection.EnglishCommentaryFilePath);
            _catalogueExporter.Export(FrenchCommentaryCatalogue, connection.FrenchCommentaryFilePath);
            _catalogueExporter.Export(GermanCommentaryCatalogue, connection.GermanCommentaryFilePath);
        }
    }
}