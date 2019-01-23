using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.DataEntities;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class NonF1ChiefMechanicDataEntityExportService : DataEntityExportServiceBase, IDataEntityExportService<NonF1ChiefMechanicDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<NonF1ChiefMechanicDataLocator> _dataLocatorFactory;

        public NonF1ChiefMechanicDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<NonF1ChiefMechanicDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(NonF1ChiefMechanicDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is NonF1ChiefMechanicDataEntity nonF1ChiefMechanicDataEntity)) throw new ArgumentNullException(nameof(nonF1ChiefMechanicDataEntity));

            var dataLocator = _dataLocatorFactory.Create(nonF1ChiefMechanicDataEntity.Id);
            dataLocator.Initialise();

            ExportLanguageCatalogueValue(_dataEndpoint, nonF1ChiefMechanicDataEntity.Name, dataLocator.Name);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Age, nonF1ChiefMechanicDataEntity.Age);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Ability, nonF1ChiefMechanicDataEntity.Ability);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Salary, nonF1ChiefMechanicDataEntity.Salary);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.RaceBonus, nonF1ChiefMechanicDataEntity.RaceBonus);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.ChampionshipBonus, nonF1ChiefMechanicDataEntity.ChampionshipBonus);
        }
    }
}