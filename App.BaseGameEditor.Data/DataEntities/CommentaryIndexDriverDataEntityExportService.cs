using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.DataEntities;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CommentaryIndexDriverDataEntityExportService : DataEntityExportServiceBase, IDataEntityExportService<CommentaryIndexDriverDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<CommentaryIndexDriverDataLocator> _dataLocatorFactory;

        public CommentaryIndexDriverDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<CommentaryIndexDriverDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(CommentaryIndexDriverDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is CommentaryIndexDriverDataEntity commentaryIndexDriverDataEntity)) throw new ArgumentNullException(nameof(commentaryIndexDriverDataEntity));

            var dataLocator = _dataLocatorFactory.Create(commentaryIndexDriverDataEntity.Id);
            dataLocator.Initialise();

            ExportLanguageCatalogueValue(_dataEndpoint, commentaryIndexDriverDataEntity.Name, dataLocator.Name);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.CommentaryIndex, commentaryIndexDriverDataEntity.CommentaryIndex);
        }
    }
}