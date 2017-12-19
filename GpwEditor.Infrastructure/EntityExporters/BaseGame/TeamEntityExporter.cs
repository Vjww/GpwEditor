using System;
using System.Linq;
using Common.Editor.Data.Entities;
using GpwEditor.Infrastructure.DataEndpoints;
using GpwEditor.Infrastructure.DataLocators;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Infrastructure.EntityExporters.BaseGame
{
    public class TeamEntityExporter : IEntityExporter
    {
        private readonly BaseGameDataEndpoint _dataEndpoint;
        private readonly TeamDataLocator _dataLocator;

        public TeamEntityExporter(BaseGameDataEndpoint dataEndpoint, TeamDataLocator dataLocator)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocator = dataLocator ?? throw new ArgumentNullException(nameof(dataLocator));
        }

        public void Export(IEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (!(entity is TeamEntity teamEntity)) throw new ArgumentNullException(nameof(teamEntity));

            _dataLocator.Map(teamEntity.Id);

            _dataEndpoint.EnglishLanguageCatalogue.Single(x => x.Id == _dataLocator.Name).Value = teamEntity.Name.English;
            _dataEndpoint.FrenchLanguageCatalogue.Single(x => x.Id == _dataLocator.Name).Value = teamEntity.Name.French;
            _dataEndpoint.GermanLanguageCatalogue.Single(x => x.Id == _dataLocator.Name).Value = teamEntity.Name.German;
            _dataEndpoint.GameExecutableResource.WriteInteger(_dataLocator.LastPosition, teamEntity.LastPosition);
            _dataEndpoint.GameExecutableResource.WriteInteger(_dataLocator.LastPoints, teamEntity.LastPoints);
            _dataEndpoint.GameExecutableResource.WriteInteger(_dataLocator.FirstGpTrack, teamEntity.FirstGpTrack);
            _dataEndpoint.GameExecutableResource.WriteInteger(_dataLocator.FirstGpYear, teamEntity.FirstGpYear);
            _dataEndpoint.GameExecutableResource.WriteInteger(_dataLocator.Wins, teamEntity.Wins);
            _dataEndpoint.GameExecutableResource.WriteInteger(_dataLocator.YearlyBudget, teamEntity.YearlyBudget);
            _dataEndpoint.GameExecutableResource.WriteInteger(_dataLocator.UnknownA, teamEntity.UnknownA);
            _dataEndpoint.GameExecutableResource.WriteInteger(_dataLocator.CountryMapId, teamEntity.CountryMapId);
            _dataEndpoint.GameExecutableResource.WriteInteger(_dataLocator.LocationPointerX, teamEntity.LocationPointerX);
            _dataEndpoint.GameExecutableResource.WriteInteger(_dataLocator.LocationPointerY, teamEntity.LocationPointerY);
            _dataEndpoint.GameExecutableResource.WriteInteger(_dataLocator.TyreSupplierId, teamEntity.TyreSupplierId);
        }
    }
}