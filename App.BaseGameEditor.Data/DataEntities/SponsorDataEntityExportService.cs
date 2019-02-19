using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.DataEntities;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorDataEntityExportService : DataEntityExportServiceBase, IDataEntityExportService<SponsorDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<SponsorDataLocator> _dataLocatorFactory;

        public SponsorDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<SponsorDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(SponsorDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));

            var dataLocator = _dataLocatorFactory.Create(dataEntity.Id);
            dataLocator.Initialise();

            ExportEntityValues(dataEntity, dataLocator);

            switch (dataEntity.SponsorTypeId)
            {
                case 1: // Team Sponsor
                    ExportSponsorCashRatingValue(dataEntity, dataLocator);
                    break;
                case 2: // Engine Supplier
                    ExportSupplierCashRatingValues(dataEntity, dataLocator, 0x007E9FC0);
                    ExportSupplierRadRatingValues(dataEntity, dataLocator, 0x007EA348);
                    ExportSupplierInactiveValue(dataEntity, dataLocator, 0x007EA350);
                    ExportEngineAttributes(dataEntity, dataLocator);
                    ExportEngineContracts(dataEntity, dataLocator);
                    break;
                case 3: // Tyre Supplier
                    ExportSupplierCashRatingValues(dataEntity, dataLocator, 0x007E8D84);
                    ExportSupplierRadRatingValues(dataEntity, dataLocator, 0x007E910C);
                    ExportSupplierInactiveValue(dataEntity, dataLocator, 0x007E9114);
                    ExportTyreAttributes(dataEntity, dataLocator);
                    ExportTyreContracts(dataEntity, dataLocator);
                    break;
                case 4: // Fuel Supplier
                    ExportSupplierCashRatingValues(dataEntity, dataLocator, 0x007ED060);
                    ExportSupplierRadRatingValues(dataEntity, dataLocator, 0x007ED3E8);
                    ExportSupplierInactiveValue(dataEntity, dataLocator, 0x007ED3F0);
                    ExportFuelAttributes(dataEntity, dataLocator);
                    ExportFuelContracts(dataEntity, dataLocator);
                    break;
                case 5: // Cash Sponsor
                    ExportSponsorCashRatingValue(dataEntity, dataLocator);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataEntity.SponsorTypeId));
            }
        }

        private void ExportEntityValues(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            ExportLanguageCatalogueValue(_dataEndpoint, dataEntity.Name, dataLocator.Name);
        }

        private void ExportSponsorCashRatingValue(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.CashRatingValue, BitConverter.GetBytes(dataEntity.CashRating));
        }

        private void ExportSupplierCashRatingValues(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator, int sponsorCashRatingBaseAddress)
        {
            const int sponsorBlockSize = 0x00000614;
            var sponsorMultiplier = dataEntity.SponsorId - 1;
            var sponsorCashRatingAddress = sponsorCashRatingBaseAddress + sponsorBlockSize * sponsorMultiplier;

            if (dataEntity.CashRatingRandom)
            {
                var cashRatingRelativeSubAddress = 0x00498A5A - 0x00400C00 - (dataLocator.CashRatingInstruction + 2 + 5); // TODO: Refactor to use CalculateRelativeAddress method

                var cashRatingInstructions = new List<byte>();

                cashRatingInstructions.AddRange(new byte[] { 0x6A, 0x05 });                           // push    5
                cashRatingInstructions.AddRange(new byte[] { 0xE8 });                                 // call    
                cashRatingInstructions.AddRange(BitConverter.GetBytes(cashRatingRelativeSubAddress)); //         sub_498A5A
                cashRatingInstructions.AddRange(new byte[] { 0x83, 0xC4, 0x04 });                     // add     esp, 4
                cashRatingInstructions.AddRange(new byte[] { 0x40 });                                 // inc     eax
                cashRatingInstructions.AddRange(new byte[] { 0xA3 });                                 // mov
                cashRatingInstructions.AddRange(BitConverter.GetBytes(sponsorCashRatingAddress));     //         ds:dword_XXXXXX, eax

                _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.CashRatingInstruction, cashRatingInstructions.ToArray());
            }
            else
            {
                var cashRatingInstructions = new List<byte>();

                cashRatingInstructions.AddRange(new byte[] { 0xC7, 0x05 });                         // mov
                cashRatingInstructions.AddRange(BitConverter.GetBytes(sponsorCashRatingAddress));   //         ds:dword_XXXXXX,
                cashRatingInstructions.AddRange(BitConverter.GetBytes(dataEntity.CashRating));      //                          X
                cashRatingInstructions.AddRange(new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }); // nop

                _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.CashRatingInstruction, cashRatingInstructions.ToArray());
            }
        }

        private void ExportSupplierRadRatingValues(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator, int sponsorRadRatingBaseAddress)
        {
            const int sponsorBlockSize = 0x00000614;
            var sponsorMultiplier = dataEntity.SponsorId - 1;
            var sponsorRadRatingAddress = sponsorRadRatingBaseAddress + sponsorBlockSize * sponsorMultiplier;

            if (dataEntity.RadRatingRandom)
            {
                var radRatingRelativeSubAddress = 0x00498A5A - 0x00400C00 - (dataLocator.RadRatingInstruction + 2 + 5); // TODO: Refactor to use CalculateRelativeAddress method

                var radRatingInstructions = new List<byte>();

                radRatingInstructions.AddRange(new byte[] { 0x6A, 0x05 });                          // push    5
                radRatingInstructions.AddRange(new byte[] { 0xE8 });                                // call    
                radRatingInstructions.AddRange(BitConverter.GetBytes(radRatingRelativeSubAddress)); //         sub_498A5A
                radRatingInstructions.AddRange(new byte[] { 0x83, 0xC4, 0x04 });                    // add     esp, 4
                radRatingInstructions.AddRange(new byte[] { 0x40 });                                // inc     eax
                radRatingInstructions.AddRange(new byte[] { 0xA3 });                                // mov
                radRatingInstructions.AddRange(BitConverter.GetBytes(sponsorRadRatingAddress));     //         ds:dword_XXXXXX, eax

                _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.RadRatingInstruction, radRatingInstructions.ToArray());
            }
            else
            {
                var radRatingInstructions = new List<byte>();

                radRatingInstructions.AddRange(new byte[] { 0xC7, 0x05 });                         // mov
                radRatingInstructions.AddRange(BitConverter.GetBytes(sponsorRadRatingAddress));    //         ds:dword_XXXXXX,
                radRatingInstructions.AddRange(BitConverter.GetBytes(dataEntity.RadRating));       //                          X
                radRatingInstructions.AddRange(new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }); // nop

                _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.RadRatingInstruction, radRatingInstructions.ToArray());
            }
        }

        private void ExportSupplierInactiveValue(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator, int sponsorInactiveBaseAddress)
        {
            const int sponsorBlockSize = 0x00000614;
            var sponsorMultiplier = dataEntity.SponsorId - 1;
            var sponsorInactiveAddress = sponsorInactiveBaseAddress + sponsorBlockSize * sponsorMultiplier;

            if (dataEntity.Inactive)
            {
                var inactiveInstructions = new List<byte>();

                inactiveInstructions.AddRange(new byte[] { 0xC7, 0x05 });                          // mov
                inactiveInstructions.AddRange(BitConverter.GetBytes(sponsorInactiveAddress));      //         ds:dword_XXXXXX,
                inactiveInstructions.AddRange(BitConverter.GetBytes(dataEntity.Inactive ? 2 : 0)); //                          X

                _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.InactiveInstruction, inactiveInstructions.ToArray());
            }
            else
            {
                var inactiveInstructions = new List<byte>();

                inactiveInstructions.AddRange(new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }); // nop

                _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.InactiveInstruction, inactiveInstructions.ToArray());
            }
        }

        private void ExportEngineAttributes(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Fuel, dataEntity.Fuel);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Heat, dataEntity.Heat);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Power, dataEntity.Power);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Reliability, dataEntity.Reliability);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Response, dataEntity.Response);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Rigidity, dataEntity.Rigidity);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Weight, dataEntity.Weight);
        }

        private void ExportTyreAttributes(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardGripSupplier, dataEntity.DryHardGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardResilienceSupplier, dataEntity.DryHardResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardStiffnessSupplier, dataEntity.DryHardStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardTemperatureSupplier, dataEntity.DryHardTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftGripSupplier, dataEntity.DrySoftGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftResilienceSupplier, dataEntity.DrySoftResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftStiffnessSupplier, dataEntity.DrySoftStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftTemperatureSupplier, dataEntity.DrySoftTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateGripSupplier, dataEntity.IntermediateGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateResilienceSupplier, dataEntity.IntermediateResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateStiffnessSupplier, dataEntity.IntermediateStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateTemperatureSupplier, dataEntity.IntermediateTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherGripSupplier, dataEntity.WetWeatherGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherResilienceSupplier, dataEntity.WetWeatherResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherStiffnessSupplier, dataEntity.WetWeatherStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherTemperatureSupplier, dataEntity.WetWeatherTemperature);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardGripTeam, dataEntity.DryHardGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardResilienceTeam, dataEntity.DryHardResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardStiffnessTeam, dataEntity.DryHardStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardTemperatureTeam, dataEntity.DryHardTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftGripTeam, dataEntity.DrySoftGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftResilienceTeam, dataEntity.DrySoftResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftStiffnessTeam, dataEntity.DrySoftStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftTemperatureTeam, dataEntity.DrySoftTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateGripTeam, dataEntity.IntermediateGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateResilienceTeam, dataEntity.IntermediateResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateStiffnessTeam, dataEntity.IntermediateStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateTemperatureTeam, dataEntity.IntermediateTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherGripTeam, dataEntity.WetWeatherGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherResilienceTeam, dataEntity.WetWeatherResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherStiffnessTeam, dataEntity.WetWeatherStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherTemperatureTeam, dataEntity.WetWeatherTemperature);
        }

        private void ExportFuelAttributes(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Performance, dataEntity.Performance);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Tolerance, dataEntity.Tolerance);
        }

        private void ExportSupplierContracts(
            SponsorDataEntity dataEntity,
            int sponsorTeamIdBaseAddress,
            int sponsorDealIdBaseAddress,
            int sponsorTermsIdBaseAddress,
            int teamDealIdBaseAddress,
            int teamTermsIdBaseAddress,
            int dataLocatorContractLocalOffset,
            int dataLocatorContractTeamIdAddress,
            int dataLocatorContractTeamIdValue,
            int dataLocatorContractDealIdSponsorAddress,
            int dataLocatorContractDealIdSponsorValue,
            int dataLocatorContractDealIdTeamAddress,
            int dataLocatorContractDealIdTeamValue,
            int dataLocatorContractTermsIdSponsorAddress,
            int dataLocatorContractTermsIdSponsorValue,
            int dataLocatorContractTermsIdTeamAddress,
            int dataLocatorContractTermsIdTeamValue)
        {
            const int sponsorBlockSize = 0x00000614;
            const int teamBlockSize = 0x00001E90;

            // TODO: Where there are multiple contracts for a supplier, should contract data against the sponsor block be written in
            // TODO: numerical order of teamId (as currently coded) or alphabetical order of team name (as coded in original game instructions)?
            // TODO: This might affect the ingame display of contracts on the supplier contracts view.

            // Iterate through any contracts against the current supplier and write contract data blocks into position based on team order (shown below)
            // e.g. if Ferrari (2) and Sauber (7) have a contract with Ferrari (Supplier), write Ferrari's contract at block 2 and Sauber's at block 7.
            // e.g. if Ferrari (2) and Tyrrell (10) have a contract with Goodyear (Supplier), write Ferrari's contract at block 2 and Tyrrell's at block 10.
            // e.g. if Arrows (8), Minardi (11) and Tyrrell (10) have a contract with Elf (Supplier), write Arrows' contract at block 8, Tyrrell's at block 10 and Minardi's at block 11.
            var contractId = 0;
            foreach (var contract in dataEntity.Contracts)
            {
                var offsetMultiplier = contract.TeamId - 1; // determines data block location
                var calculatedOffset = dataLocatorContractLocalOffset * offsetMultiplier;
                var sponsorMultiplier = contract.SponsorId - 1;
                var teamMultiplier = contract.TeamId - 1; // determines data block location

                // Write ingame address value and ingame TeamId value for ingame sponsor data block
                var sponsorTeamIdAddress = sponsorTeamIdBaseAddress + sponsorBlockSize * sponsorMultiplier + 4 * contractId;
                _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocatorContractTeamIdAddress + calculatedOffset, sponsorTeamIdAddress);
                _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocatorContractTeamIdValue + calculatedOffset, contract.TeamId);

                // Write ingame address value and ingame DealId value for ingame sponsor data block
                var sponsorDealIdAddress = sponsorDealIdBaseAddress + sponsorBlockSize * sponsorMultiplier + 4 * contractId;
                _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocatorContractDealIdSponsorAddress + calculatedOffset, sponsorDealIdAddress);
                _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocatorContractDealIdSponsorValue + calculatedOffset, contract.DealId);

                // Write ingame address value and ingame DealId value for ingame team data block
                var teamDealIdAddress = teamDealIdBaseAddress + teamBlockSize * teamMultiplier;
                _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocatorContractDealIdTeamAddress + calculatedOffset, teamDealIdAddress);
                _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocatorContractDealIdTeamValue + calculatedOffset, contract.DealId);

                // Write ingame address value and ingame TermsId value for ingame sponsor data block
                var sponsorTermsIdAddress = sponsorTermsIdBaseAddress + sponsorBlockSize * sponsorMultiplier + 4 * contractId;
                _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocatorContractTermsIdSponsorAddress + calculatedOffset, sponsorTermsIdAddress);
                _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocatorContractTermsIdSponsorValue + calculatedOffset, contract.TermsId);

                // Write ingame address value and ingame TermsId value for ingame team data block
                var teamTermsIdAddress = teamTermsIdBaseAddress + teamBlockSize * teamMultiplier;
                _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocatorContractTermsIdTeamAddress + calculatedOffset, teamTermsIdAddress);
                _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocatorContractTermsIdTeamValue + calculatedOffset, contract.TermsId);

                contractId++;
            }
        }

        private void ExportEngineContracts(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            ExportSupplierContracts(
                dataEntity,
                0x007EA27C,
                0x007EA35C,
                0x007EA09C,
                0x01205640,
                0x01205614,
                SponsorDataLocator.ContractEngineLocalOffset,
                dataLocator.ContractEngineTeamIdAddress,
                dataLocator.ContractEngineTeamIdValue,
                dataLocator.ContractEngineDealIdSponsorAddress,
                dataLocator.ContractEngineDealIdSponsorValue,
                dataLocator.ContractEngineDealIdTeamAddress,
                dataLocator.ContractEngineDealIdTeamValue,
                dataLocator.ContractEngineTermsIdSponsorAddress,
                dataLocator.ContractEngineTermsIdSponsorValue,
                dataLocator.ContractEngineTermsIdTeamAddress,
                dataLocator.ContractEngineTermsIdTeamValue);
        }

        private void ExportTyreContracts(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            ExportSupplierContracts(
                dataEntity,
                0x007E9040,
                0x007E9120,
                0x007E8E60,
                0x01205644,
                0x01205618,
                SponsorDataLocator.ContractTyreLocalOffset,
                dataLocator.ContractTyreTeamIdAddress,
                dataLocator.ContractTyreTeamIdValue,
                dataLocator.ContractTyreDealIdSponsorAddress,
                dataLocator.ContractTyreDealIdSponsorValue,
                dataLocator.ContractTyreDealIdTeamAddress,
                dataLocator.ContractTyreDealIdTeamValue,
                dataLocator.ContractTyreTermsIdSponsorAddress,
                dataLocator.ContractTyreTermsIdSponsorValue,
                dataLocator.ContractTyreTermsIdTeamAddress,
                dataLocator.ContractTyreTermsIdTeamValue);
        }

        private void ExportFuelContracts(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            ExportSupplierContracts(
                dataEntity,
                0x007ED31C,
                0x007ED3FC,
                0x007ED13C,
                0x01205648,
                0x0120561C,
                SponsorDataLocator.ContractFuelLocalOffset,
                dataLocator.ContractFuelTeamIdAddress,
                dataLocator.ContractFuelTeamIdValue,
                dataLocator.ContractFuelDealIdSponsorAddress,
                dataLocator.ContractFuelDealIdSponsorValue,
                dataLocator.ContractFuelDealIdTeamAddress,
                dataLocator.ContractFuelDealIdTeamValue,
                dataLocator.ContractFuelTermsIdSponsorAddress,
                dataLocator.ContractFuelTermsIdSponsorValue,
                dataLocator.ContractFuelTermsIdTeamAddress,
                dataLocator.ContractFuelTermsIdTeamValue);
        }
    }
}