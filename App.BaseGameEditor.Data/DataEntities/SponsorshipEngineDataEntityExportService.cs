using System;
using System.Collections.Generic;
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

            var cashRatingStructLocation = 0x007E9FC0 + 1556 * dataEntity.Id;
            if (sponsorshipEngineDataEntity.CashRatingRandom)
            {
                var cashRatingRelativeSubAddress = 0x00498A5A - 0x00400C00 - (dataLocator.CashRatingInstruction + 2 + 5); // TODO: Refactor to use CalculateRelativeAddress method

                var cashRatingRandomInstructions = new List<byte>();

                cashRatingRandomInstructions.AddRange(new byte[] { 0x6A, 0x05 });                           // push    5
                cashRatingRandomInstructions.AddRange(new byte[] { 0xE8 });                                 // call    
                cashRatingRandomInstructions.AddRange(BitConverter.GetBytes(cashRatingRelativeSubAddress)); //         sub_498A5A
                cashRatingRandomInstructions.AddRange(new byte[] { 0x83, 0xC4, 0x04 });                     // add     esp, 4
                cashRatingRandomInstructions.AddRange(new byte[] { 0x40 });                                 // inc     eax
                cashRatingRandomInstructions.AddRange(new byte[] { 0xE8 });                                 // mov
                cashRatingRandomInstructions.AddRange(BitConverter.GetBytes(cashRatingStructLocation));     //         ds:dword_XXXXXX, eax

                _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.CashRatingInstruction, cashRatingRandomInstructions.ToArray());
            }
            else
            {
                var cashRatingRandomInstructions = new List<byte>();

                cashRatingRandomInstructions.AddRange(new byte[] { 0xC7, 0x05 });                         // mov
                cashRatingRandomInstructions.AddRange(BitConverter.GetBytes(cashRatingStructLocation));   //         ds:dword_XXXXXX,
                cashRatingRandomInstructions.AddRange(BitConverter.GetBytes(dataEntity.CashRating));      //                          X
                cashRatingRandomInstructions.AddRange(new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }); // nop

                _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.CashRatingInstruction, cashRatingRandomInstructions.ToArray());
            }

            var radRatingStructLocation = 0x007EA348 + 1556 * dataEntity.Id;
            if (sponsorshipEngineDataEntity.RadRatingRandom)
            {
                var radRatingRelativeSubAddress = 0x00498A5A - 0x00400C00 - (dataLocator.RadRatingInstruction + 2 + 5); // TODO: Refactor to use CalculateRelativeAddress method

                var radRatingRandomInstructions = new List<byte>();

                radRatingRandomInstructions.AddRange(new byte[] { 0x6A, 0x05 });                          // push    5
                radRatingRandomInstructions.AddRange(new byte[] { 0xE8 });                                // call    
                radRatingRandomInstructions.AddRange(BitConverter.GetBytes(radRatingRelativeSubAddress)); //         sub_498A5A
                radRatingRandomInstructions.AddRange(new byte[] { 0x83, 0xC4, 0x04 });                    // add     esp, 4
                radRatingRandomInstructions.AddRange(new byte[] { 0x40 });                                // inc     eax
                radRatingRandomInstructions.AddRange(new byte[] { 0xE8 });                                // mov
                radRatingRandomInstructions.AddRange(BitConverter.GetBytes(radRatingStructLocation));     //         ds:dword_XXXXXX, eax

                _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.RadRatingInstruction, radRatingRandomInstructions.ToArray());
            }
            else
            {
                var radRatingRandomInstructions = new List<byte>();

                radRatingRandomInstructions.AddRange(new byte[] { 0xC7, 0x05 });                         // mov
                radRatingRandomInstructions.AddRange(BitConverter.GetBytes(radRatingStructLocation));    //         ds:dword_XXXXXX,
                radRatingRandomInstructions.AddRange(BitConverter.GetBytes(dataEntity.RadRating));       //                          X
                radRatingRandomInstructions.AddRange(new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }); // nop

                _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.RadRatingInstruction, radRatingRandomInstructions.ToArray());
            }

            var inactiveStructLocation = 0x007EA350 + 1556 * dataEntity.Id;
            if (sponsorshipEngineDataEntity.Inactive)
            {
                var inactiveInstructions = new List<byte>();

                inactiveInstructions.AddRange(new byte[] { 0xC7, 0x05 });                          // mov
                inactiveInstructions.AddRange(BitConverter.GetBytes(inactiveStructLocation));      //         ds:dword_XXXXXX,
                inactiveInstructions.AddRange(BitConverter.GetBytes(dataEntity.Inactive ? 2 : 0)); //                          X

                _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.InactiveInstruction, inactiveInstructions.ToArray());
            }
            else
            {
                var inactiveInstructions = new List<byte>();

                inactiveInstructions.AddRange(new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }); // nop

                _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.InactiveInstruction, inactiveInstructions.ToArray());
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