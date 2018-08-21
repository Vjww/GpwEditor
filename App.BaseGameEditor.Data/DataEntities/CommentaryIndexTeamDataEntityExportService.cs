using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CommentaryIndexTeamDataEntityExportService : IDataEntityExportService<CommentaryIndexTeamDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<CommentaryIndexTeamDataLocator> _dataLocatorFactory;

        public CommentaryIndexTeamDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<CommentaryIndexTeamDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(CommentaryIndexTeamDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is CommentaryIndexTeamDataEntity commentaryIndexTeamDataEntity)) throw new ArgumentNullException(nameof(commentaryIndexTeamDataEntity));

            var dataLocator = _dataLocatorFactory.Create(commentaryIndexTeamDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItem = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            var frenchCatalogueItem = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            var germanCatalogueItem = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);

            englishCatalogueItem.Value = commentaryIndexTeamDataEntity.Name.English;
            frenchCatalogueItem.Value = commentaryIndexTeamDataEntity.Name.French;
            germanCatalogueItem.Value = commentaryIndexTeamDataEntity.Name.German;

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, englishCatalogueItem);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, frenchCatalogueItem);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, germanCatalogueItem);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.CommentaryIndex, commentaryIndexTeamDataEntity.CommentaryIndex);
        }
    }
}