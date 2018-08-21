using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CommentaryPrefixDriverDataEntityExportService : IDataEntityExportService<CommentaryPrefixDriverDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<CommentaryPrefixDriverDataLocator> _dataLocatorFactory;

        public CommentaryPrefixDriverDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<CommentaryPrefixDriverDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(CommentaryPrefixDriverDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is CommentaryPrefixDriverDataEntity commentaryPrefixDriverDataEntity)) throw new ArgumentNullException(nameof(commentaryPrefixDriverDataEntity));

            var dataLocator = _dataLocatorFactory.Create(commentaryPrefixDriverDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItemP1 = _dataEndpoint.EnglishCommentaryCatalogue.Read(dataLocator.CommentaryIndexP1);
            var frenchCatalogueItemP1 = _dataEndpoint.FrenchCommentaryCatalogue.Read(dataLocator.CommentaryIndexP1);
            var germanCatalogueItemP1 = _dataEndpoint.GermanCommentaryCatalogue.Read(dataLocator.CommentaryIndexP1);

            englishCatalogueItemP1.FileNamePrefix = commentaryPrefixDriverDataEntity.FileNamePrefix;
            frenchCatalogueItemP1.FileNamePrefix = commentaryPrefixDriverDataEntity.FileNamePrefix;
            germanCatalogueItemP1.FileNamePrefix = commentaryPrefixDriverDataEntity.FileNamePrefix;

            _dataEndpoint.EnglishCommentaryCatalogue.Write(dataLocator.CommentaryIndexP1, englishCatalogueItemP1);
            _dataEndpoint.FrenchCommentaryCatalogue.Write(dataLocator.CommentaryIndexP1, frenchCatalogueItemP1);
            _dataEndpoint.GermanCommentaryCatalogue.Write(dataLocator.CommentaryIndexP1, germanCatalogueItemP1);

            var englishCatalogueItemP2 = _dataEndpoint.EnglishCommentaryCatalogue.Read(dataLocator.CommentaryIndexP2);
            var frenchCatalogueItemP2 = _dataEndpoint.FrenchCommentaryCatalogue.Read(dataLocator.CommentaryIndexP2);
            var germanCatalogueItemP2 = _dataEndpoint.GermanCommentaryCatalogue.Read(dataLocator.CommentaryIndexP2);

            englishCatalogueItemP2.FileNamePrefix = commentaryPrefixDriverDataEntity.FileNamePrefix;
            frenchCatalogueItemP2.FileNamePrefix = commentaryPrefixDriverDataEntity.FileNamePrefix;
            germanCatalogueItemP2.FileNamePrefix = commentaryPrefixDriverDataEntity.FileNamePrefix;

            _dataEndpoint.EnglishCommentaryCatalogue.Write(dataLocator.CommentaryIndexP2, englishCatalogueItemP2);
            _dataEndpoint.FrenchCommentaryCatalogue.Write(dataLocator.CommentaryIndexP2, frenchCatalogueItemP2);
            _dataEndpoint.GermanCommentaryCatalogue.Write(dataLocator.CommentaryIndexP2, germanCatalogueItemP2);

            var englishCatalogueItemP3 = _dataEndpoint.EnglishCommentaryCatalogue.Read(dataLocator.CommentaryIndexP3);
            var frenchCatalogueItemP3 = _dataEndpoint.FrenchCommentaryCatalogue.Read(dataLocator.CommentaryIndexP3);
            var germanCatalogueItemP3 = _dataEndpoint.GermanCommentaryCatalogue.Read(dataLocator.CommentaryIndexP3);

            englishCatalogueItemP3.FileNamePrefix = commentaryPrefixDriverDataEntity.FileNamePrefix;
            frenchCatalogueItemP3.FileNamePrefix = commentaryPrefixDriverDataEntity.FileNamePrefix;
            germanCatalogueItemP3.FileNamePrefix = commentaryPrefixDriverDataEntity.FileNamePrefix;

            _dataEndpoint.EnglishCommentaryCatalogue.Write(dataLocator.CommentaryIndexP3, englishCatalogueItemP3);
            _dataEndpoint.FrenchCommentaryCatalogue.Write(dataLocator.CommentaryIndexP3, frenchCatalogueItemP3);
            _dataEndpoint.GermanCommentaryCatalogue.Write(dataLocator.CommentaryIndexP3, germanCatalogueItemP3);

            var englishCatalogueItemOut = _dataEndpoint.EnglishCommentaryCatalogue.Read(dataLocator.CommentaryIndexOut);
            var frenchCatalogueItemOut = _dataEndpoint.FrenchCommentaryCatalogue.Read(dataLocator.CommentaryIndexOut);
            var germanCatalogueItemOut = _dataEndpoint.GermanCommentaryCatalogue.Read(dataLocator.CommentaryIndexOut);

            englishCatalogueItemOut.FileNamePrefix = commentaryPrefixDriverDataEntity.FileNamePrefix;
            frenchCatalogueItemOut.FileNamePrefix = commentaryPrefixDriverDataEntity.FileNamePrefix;
            germanCatalogueItemOut.FileNamePrefix = commentaryPrefixDriverDataEntity.FileNamePrefix;

            _dataEndpoint.EnglishCommentaryCatalogue.Write(dataLocator.CommentaryIndexOut, englishCatalogueItemOut);
            _dataEndpoint.FrenchCommentaryCatalogue.Write(dataLocator.CommentaryIndexOut, frenchCatalogueItemOut);
            _dataEndpoint.GermanCommentaryCatalogue.Write(dataLocator.CommentaryIndexOut, germanCatalogueItemOut);

            var englishCatalogueItemPits = _dataEndpoint.EnglishCommentaryCatalogue.Read(dataLocator.CommentaryIndexPits);
            var frenchCatalogueItemPits = _dataEndpoint.FrenchCommentaryCatalogue.Read(dataLocator.CommentaryIndexPits);
            var germanCatalogueItemPits = _dataEndpoint.GermanCommentaryCatalogue.Read(dataLocator.CommentaryIndexPits);

            englishCatalogueItemPits.FileNamePrefix = commentaryPrefixDriverDataEntity.FileNamePrefix;
            frenchCatalogueItemPits.FileNamePrefix = commentaryPrefixDriverDataEntity.FileNamePrefix;
            germanCatalogueItemPits.FileNamePrefix = commentaryPrefixDriverDataEntity.FileNamePrefix;

            _dataEndpoint.EnglishCommentaryCatalogue.Write(dataLocator.CommentaryIndexPits, englishCatalogueItemPits);
            _dataEndpoint.FrenchCommentaryCatalogue.Write(dataLocator.CommentaryIndexPits, frenchCatalogueItemPits);
            _dataEndpoint.GermanCommentaryCatalogue.Write(dataLocator.CommentaryIndexPits, germanCatalogueItemPits);
        }
    }
}