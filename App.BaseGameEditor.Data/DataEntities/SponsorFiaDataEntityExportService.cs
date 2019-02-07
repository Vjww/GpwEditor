using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.DataEntities;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorFiaDataEntityExportService : DataEntityExportServiceBase, IDataEntityExportService<SponsorFiaDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<SponsorFiaDataLocator> _dataLocatorFactory;

        public SponsorFiaDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<SponsorFiaDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(SponsorFiaDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));

            var dataLocator = _dataLocatorFactory.Create(dataEntity.Id);
            dataLocator.Initialise();

            ExportLanguageCatalogueValue(_dataEndpoint, dataEntity.Name, dataLocator.Name);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.CashValueA, dataEntity.Cash);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.CashValueB, dataEntity.Cash);
        }
    }
}