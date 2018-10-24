using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorshipEngineDataEntityExportService : IDataEntityExportService<SponsorshipEngineDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<SponsorshipEngineDataLocator> _dataLocatorFactory;

        public SponsorshipEngineDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<SponsorshipEngineDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(SponsorshipEngineDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is SponsorshipEngineDataEntity sponsorshipEngineDataEntity)) throw new ArgumentNullException(nameof(sponsorshipEngineDataEntity));

            var dataLocator = _dataLocatorFactory.Create(sponsorshipEngineDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItem = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            var frenchCatalogueItem = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            var germanCatalogueItem = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);

            englishCatalogueItem.Value = sponsorshipEngineDataEntity.Name.English;
            frenchCatalogueItem.Value = sponsorshipEngineDataEntity.Name.French;
            germanCatalogueItem.Value = sponsorshipEngineDataEntity.Name.German;

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, englishCatalogueItem);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, frenchCatalogueItem);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, germanCatalogueItem);

            if (sponsorshipEngineDataEntity.CashRatingRandom)
            {
                //_dataEndpoint.GameExecutableFileResource.WriteBytes(new byte[] { "C7 05 3C 9D 7E 00 02 00 00 00" }); // TODO: Write random value instructions
            }
            else
            {
                //_dataEndpoint.GameExecutableFileResource.WriteBytes(new byte[] { }); // TODO: Write determined value instructions
            }

            if (sponsorshipEngineDataEntity.RadRatingRandom)
            {
                //_dataEndpoint.GameExecutableFileResource.WriteBytes(new byte[] { }); // TODO: Write random value instructions
            }
            else
            {
                //_dataEndpoint.GameExecutableFileResource.WriteBytes(new byte[] { }); // TODO: Write determined value instructions
            }

            if (sponsorshipEngineDataEntity.Inactive)
            {
                //_dataEndpoint.GameExecutableFileResource.WriteBytes(new byte[] { "C7 05 3C 9D 7E 00 02 00 00 00" }); // TODO: Write inactive instructions
            }
            else
            {
                //_dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.InactiveInstruction, new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }); // TODO: Write nops
            }

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Fuel, sponsorshipEngineDataEntity.Fuel);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Heat, sponsorshipEngineDataEntity.Heat);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Power, sponsorshipEngineDataEntity.Power);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Reliability, sponsorshipEngineDataEntity.Reliability);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Response, sponsorshipEngineDataEntity.Response);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Rigidity, sponsorshipEngineDataEntity.Rigidity);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Weight, sponsorshipEngineDataEntity.Weight);
        }
    }
}