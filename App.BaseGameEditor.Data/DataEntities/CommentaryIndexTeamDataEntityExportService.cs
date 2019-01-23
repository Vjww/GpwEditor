using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.DataEntities;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CommentaryIndexTeamDataEntityExportService : DataEntityExportServiceBase, IDataEntityExportService<CommentaryIndexTeamDataEntity>
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

            ExportLanguageCatalogueValue(_dataEndpoint, commentaryIndexTeamDataEntity.Name, dataLocator.Name);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.CommentaryIndex, commentaryIndexTeamDataEntity.CommentaryIndex);
        }
    }
}