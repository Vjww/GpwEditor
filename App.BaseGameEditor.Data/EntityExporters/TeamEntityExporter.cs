﻿using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Entities;

namespace App.BaseGameEditor.Data.EntityExporters
{
    public class TeamEntityExporter : IEntityExporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly TeamDataLocator _dataLocator;

        public TeamEntityExporter(DataEndpoint dataEndpoint, TeamDataLocator dataLocator)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocator = dataLocator ?? throw new ArgumentNullException(nameof(dataLocator));
        }

        public void Export(IEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (!(entity is TeamEntity teamEntity)) throw new ArgumentNullException(nameof(teamEntity));

            _dataLocator.Initialise(teamEntity.Id);

            _dataEndpoint.EnglishLanguageCatalogue.Write(_dataLocator.Name, teamEntity.Name.English);
            _dataEndpoint.FrenchLanguageCatalogue.Write(_dataLocator.Name, teamEntity.Name.French);
            _dataEndpoint.GermanLanguageCatalogue.Write(_dataLocator.Name, teamEntity.Name.German);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.LastPosition, teamEntity.LastPosition);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.LastPoints, teamEntity.LastPoints);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.FirstGpTrack, teamEntity.FirstGpTrack);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.FirstGpYear, teamEntity.FirstGpYear);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.Wins, teamEntity.Wins);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.YearlyBudget, teamEntity.YearlyBudget);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.UnknownA, teamEntity.UnknownA);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.CountryMapId, teamEntity.CountryMapId);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.LocationPointerX, teamEntity.LocationPointerX);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.LocationPointerY, teamEntity.LocationPointerY);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.TyreSupplierId, teamEntity.TyreSupplierId);
        }
    }
}