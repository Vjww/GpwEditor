using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorshipTeamDataEntityExportService : IDataEntityExportService<SponsorshipTeamDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<SponsorshipTeamDataLocator> _dataLocatorFactory;

        public SponsorshipTeamDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<SponsorshipTeamDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(SponsorshipTeamDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is SponsorshipTeamDataEntity sponsorshipTeamDataEntity)) throw new ArgumentNullException(nameof(sponsorshipTeamDataEntity));

            var dataLocator = _dataLocatorFactory.Create(sponsorshipTeamDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItem = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            var frenchCatalogueItem = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            var germanCatalogueItem = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);

            englishCatalogueItem.Value = sponsorshipTeamDataEntity.Name.English;
            frenchCatalogueItem.Value = sponsorshipTeamDataEntity.Name.French;
            germanCatalogueItem.Value = sponsorshipTeamDataEntity.Name.German;

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, englishCatalogueItem);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, frenchCatalogueItem);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, germanCatalogueItem);

            // TODO: Use below code and clean up
            //var englishCatalogueItem = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            //var frenchCatalogueItem = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            //var germanCatalogueItem = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);

            //englishCatalogueItem.Value = sponsorEntityDataEntity.Name.English;
            //frenchCatalogueItem.Value = sponsorEntityDataEntity.Name.French;
            //germanCatalogueItem.Value = sponsorEntityDataEntity.Name.German;

            //_dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, englishCatalogueItem);
            //_dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, frenchCatalogueItem);
            //_dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, germanCatalogueItem);

            //_dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Fuel, sponsorEntityDataEntity.Fuel);
            //_dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Heat, sponsorEntityDataEntity.Heat);
            //_dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Power, sponsorEntityDataEntity.Power);
            //_dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Reliability, sponsorEntityDataEntity.Reliability);
            //_dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Response, sponsorEntityDataEntity.Response);
            //_dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Rigidity, sponsorEntityDataEntity.Rigidity);
            //_dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Weight, sponsorEntityDataEntity.Weight);


            // TODO: From here down

            // ResetBlockWithNops(size); // +22 to size for suppliers vs sponsors

            // var instructionPointer = dataLocator.InstructionsBaseOffset;

            //int[] loadResourceStringSubRelativeAddressInstructions = { 0x90, 0x90, 0x90, 0x90 };
            //loadResourceStringSubRelativeAddressInstructions = _instructionService.CalculateRelativeAddress(currentAddress, 0x0051371B);

            //int[] getRandomNumberSubRelativeAddressInstructions = { 0x90, 0x90, 0x90, 0x90 };
            //getRandomNumberSubRelativeAddressInstructions = _instructionService.CalculateRelativeAddress(currentAddress, 0x00498A5A);

            //var sponsorTypeAddress = _instructionService.GetInstructions(dataLocator.GetSponsorTypeAddress(dataEntity.SponsorshipType));  // Return 1 byte
            //var sponsorTypeValue = _instructionService.GetInstructions(dataLocator.GetSponsorTypeId(dataEntity.SponsorshipType));         // Return 4 bytes
            //var sponsorStringValue = _instructionService.GetInstructions(dataLocator.GetSponsorTypeId(dataEntity.SponsorshipType));       // Return 4 bytes
            //var sponsorEntityStructIndex = _instructionService.GetInstructions(dataLocator.GetEntityStructIndex(dataEntity.SponsorshipId)); // Return 4 bytes

            // TODO: Below is no longer required as entity data will be hardcoded and doesnt require modification.
            //byte[] instructions;
            //instructions.Concat(new [] { 0xC6, 0x05 }, GetSponsorTypeAddress(8E 9F 7E 00), GetSponsorTypeId(02)));   //mov ds:byte_7E9F8E, 2          Count: 7
            //instructions.Concat(new [] { 0x68 }, GetSponsorStringId(16 13 00 00)));                                 //push    1316h                  Count: 5
            //instructions.Concat(new [] { 0xE8 }, GetRelativeSubAddress(0x0051371B, 13)));                           //call sub_51371B  Count: 5
            //instructions.Concat(new [] { 0x83, 0xC4, 0x04 }));                                                      //add esp, 4                     Count: 3
            //instructions.Concat(new [] { 0x50 }));                                                    //push eax; Source               Count: 1
            //instructions.Concat(new [] { 0xB8, 0x90, 0x5C, 0x7E, 0x00 }));                            //mov eax, offset dword_7E5C90   Count: 5
            //instructions.Concat(new [] { 0x05 }, GetStructIndex(0xE0, 0x42, 0x00, 0x00)));            //add eax, 42E0h                 Count: 5
            //instructions.Concat(new [] { 0x50 }));                                                    //push eax; Dest                 Count: 1
            //instructions.Concat(new [] { 0xE8, } GetRelativeSubAddress(0x0067C58C, xx) ));                            //call sub_67C58C                Count: 5
            //instructions.Concat(new [] { 0x83, 0xC4, 0x08 }));                                        //add esp, 8                     Count: 3
            //WriteInstructions(instructions);

            //byte[] instructions = new byte[] { };
            //if (dataEntity.CashRatingRandom)
            //{
            //    instructions.Concat(new byte[] { 0x6A, 0x05 });                                          // push    5                                        Count: 2
            //    instructions.Concat(Concat(new byte[] { 0xE8 }, GetRelativeSubAddress(0xFFFB079F, 0))); // call uf_GetRandomNumber                          Count: 5
            //    instructions.Concat(new byte[] { 0x83, 0xC4, 0x04 });                                    // add esp, 4                                       Count: 3
            //    instructions.Concat(new byte[] { 0x40 });                                               // inc eax                                          Count: 1
            //    instructions.Concat(Concat(new byte[] { 0xA3 }, GetCashAddress(0x007ECA4C, 0)));        // mov ds:dword_7ECA4C, eax                         Count: 5
            //    ////instructions.Concat(new [] { 0x6A, 0x05 };                                //            push    5                                        Count: 2
            //    ////instructions.Concat(new [] { 0xE8, 0x8F, 0x07, 0xFB, 0xFF});              //            call uf_GetRandomNumber                          Count: 5
            //    ////instructions.Concat(new [] { 0x83, 0xC4, 0x04});                          //            add esp, 4                                       Count: 3
            //    ////instructions.Concat(new [] { 0x40});                                      //            inc eax                                          Count: 1
            //    ////instructions.Concat(new [] { 0xA3, GetRadAddress(D4 CD 7E 00)});        //          mov ds:dword_7ECDD4, eax                         Count: 5
            //}
            //else
            //{
            //    instructions.Concat(Concat(new byte[] { 0xC7, 0x05 }, GetCashAddress(0x007E9FC0, 0), GetFundsValues(0x00000001))); // mov ds:dword_7E9FC0, 1   Count: 10
            //    instructions.Concat(new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 });                                         // nop                      Count: 6
            //    ////instructions.Concat(new [] { C7 05 GetRadAddress(48 A3 7E 00) GetFundsValues(01 00 00 00))};     //mov ds:dword_7EA348, 1         Count: 10
            //    ////instructions.Concat(new [] { 90 90 90 90 90 90};               //
            //}
            //WriteInstructions(instructions);
        }

        //private byte[] GetFundsValues(int i)
        //{
        //    throw new NotImplementedException();
        //}

        //private byte[] GetCashAddress(int memoryAddress, int instructionAddress)
        //{
        //    throw new NotImplementedException();
        //}

        //private byte[] GetRelativeSubAddress(uint subAddress, int instructionAddress) // TODO: uint?
        //{
        //    throw new NotImplementedException();
        //}

        //private void WriteInstructions(byte[] bytes)
        //{
        //    throw new NotImplementedException();
        //}

        //private byte[] Concat(params byte[][] bytes)
        //{
        //    byte[] result = { };

        //    foreach (var byteArray in bytes)
        //    {
        //        result.Concat(byteArray);
        //    }

        //    return result;
        //}
    }
}