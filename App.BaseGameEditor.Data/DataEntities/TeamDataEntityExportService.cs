using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class TeamDataEntityExportService : IDataEntityExportService<TeamDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<TeamDataLocator> _dataLocatorFactory;

        public TeamDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<TeamDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(TeamDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is TeamDataEntity teamDataEntity)) throw new ArgumentNullException(nameof(teamDataEntity));

            var dataLocator = _dataLocatorFactory.Create(teamDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItem = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            var frenchCatalogueItem = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            var germanCatalogueItem = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);

            englishCatalogueItem.Value = teamDataEntity.Name.English;
            frenchCatalogueItem.Value = teamDataEntity.Name.French;
            germanCatalogueItem.Value = teamDataEntity.Name.German;

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, englishCatalogueItem);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, frenchCatalogueItem);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, germanCatalogueItem);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LastPosition, teamDataEntity.LastPosition);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LastPoints, teamDataEntity.LastPoints);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DebutGrandPrix, teamDataEntity.DebutGrandPrix);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DebutYear, teamDataEntity.DebutYear);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Wins, teamDataEntity.Wins);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.YearlyBudget, teamDataEntity.YearlyBudget);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.UnknownA, teamDataEntity.UnknownA);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Location, teamDataEntity.Location);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LocationX, teamDataEntity.LocationX);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LocationY, teamDataEntity.LocationY);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.TyreSupplier, teamDataEntity.TyreSupplier);
        }
    }
}