using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.DataEntities;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorFiaDataEntityImportService : DataEntityImportServiceBase, IDataEntityImportService<SponsorFiaDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<SponsorFiaDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorFiaDataLocator> _dataLocatorFactory;

        public SponsorFiaDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<SponsorFiaDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<SponsorFiaDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public SponsorFiaDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            ImportLanguageCatalogueValue(_dataEndpoint, result.Name, dataLocator.Name);
            result.Cash = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CashValueA);

            return result;
        }
    }
}