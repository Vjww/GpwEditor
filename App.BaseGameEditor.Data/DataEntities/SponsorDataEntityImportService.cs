using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.Calculators;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.DataEntities;
using App.Shared.Data.Factories;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorDataEntityImportService : DataEntityImportServiceBase, IDataEntityImportService<SponsorDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<SponsorDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorDataLocator> _dataLocatorFactory;
        private readonly IdentityCalculator _identityCalculator;
        private readonly ISponsorContractObjectFactory _sponsorContractObjectFactory;

        public SponsorDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<SponsorDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<SponsorDataLocator> dataLocatorFactory,
            ISponsorContractObjectFactory sponsorContractObjectFactory,
            IdentityCalculator identityCalculator)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
            _sponsorContractObjectFactory = sponsorContractObjectFactory ?? throw new ArgumentNullException(nameof(sponsorContractObjectFactory));
            _identityCalculator = identityCalculator ?? throw new ArgumentNullException(nameof(identityCalculator));
        }

        public SponsorDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);

            ImportEntityValues(result, dataLocator);

            switch (result.SponsorTypeId)
            {
                case 1: // Team Sponsor
                    ImportSponsorCashRatingValue(result, dataLocator);
                    break;
                case 2: // Engine Supplier
                    ImportSupplierCashRatingValues(result, dataLocator);
                    ImportSupplierRadRatingValues(result, dataLocator);
                    ImportSupplierInactiveValue(result, dataLocator);
                    ImportEngineAttributes(result, dataLocator);
                    ImportEngineContracts(result, dataLocator);
                    break;
                case 3: // Tyre Supplier
                    ImportSupplierCashRatingValues(result, dataLocator);
                    ImportSupplierRadRatingValues(result, dataLocator);
                    ImportSupplierInactiveValue(result, dataLocator);
                    ImportTyreAttributes(result, dataLocator);
                    ImportTyreContracts(result, dataLocator);
                    break;
                case 4: // Fuel Supplier
                    ImportSupplierCashRatingValues(result, dataLocator);
                    ImportSupplierRadRatingValues(result, dataLocator);
                    ImportSupplierInactiveValue(result, dataLocator);
                    ImportFuelAttributes(result, dataLocator);
                    ImportFuelContracts(result, dataLocator);
                    break;
                case 5: // Cash Sponsor
                    ImportSponsorCashRatingValue(result, dataLocator);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(result.SponsorTypeId));
            }

            return result;
        }

        private void ImportEntityValues(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            ImportLanguageCatalogueValue(_dataEndpoint, dataEntity.Name, dataLocator.Name);

            dataEntity.SponsorId = _identityCalculator.GetSponsorId(dataEntity.Id);
            dataEntity.SponsorTypeId = _identityCalculator.GetSponsorTypeId(dataEntity.Id);

            dataEntity.EntityTypeId = _dataEndpoint.GameExecutableFileResource.ReadByte(dataLocator.EntityTypeValue);
            dataEntity.EntityResource = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.EntityResourceValue);
            dataEntity.EntityData = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.EntityDataValue);
        }

        private void ImportSponsorCashRatingValue(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            dataEntity.CashRating = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CashRatingValue);
        }

        private void ImportSupplierCashRatingValues(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            var cashRatingInstructionValue = _dataEndpoint.GameExecutableFileResource.ReadByte(dataLocator.CashRatingInstruction);
            if (cashRatingInstructionValue == 0x6A)
            {
                dataEntity.CashRatingRandom = true;
            }
            else
            {
                dataEntity.CashRating = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CashRatingValue);
            }
        }

        private void ImportSupplierRadRatingValues(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            var radRatingInstructionValue = _dataEndpoint.GameExecutableFileResource.ReadByte(dataLocator.RadRatingInstruction);
            if (radRatingInstructionValue == 0x6A)
            {
                dataEntity.RadRatingRandom = true;
            }
            else
            {
                dataEntity.RadRating = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.RadRatingValue);
            }
        }

        private void ImportSupplierInactiveValue(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            var inactiveInstructionValue = _dataEndpoint.GameExecutableFileResource.ReadByte(dataLocator.InactiveInstruction);
            if (inactiveInstructionValue == 0xC7)
            {
                dataEntity.Inactive = true;
            }
        }

        private void ImportEngineAttributes(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            dataEntity.Fuel = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Fuel);
            dataEntity.Heat = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Heat);
            dataEntity.Power = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Power);
            dataEntity.Reliability = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Reliability);
            dataEntity.Response = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Response);
            dataEntity.Rigidity = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Rigidity);
            dataEntity.Weight = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Weight);
        }

        private void ImportTyreAttributes(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            dataEntity.DryHardGrip = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DryHardGripSupplier);
            dataEntity.DryHardResilience = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DryHardResilienceSupplier);
            dataEntity.DryHardStiffness = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DryHardStiffnessSupplier);
            dataEntity.DryHardTemperature = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DryHardTemperatureSupplier);
            dataEntity.DrySoftGrip = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DrySoftGripSupplier);
            dataEntity.DrySoftResilience = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DrySoftResilienceSupplier);
            dataEntity.DrySoftStiffness = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DrySoftStiffnessSupplier);
            dataEntity.DrySoftTemperature = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DrySoftTemperatureSupplier);
            dataEntity.IntermediateGrip = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.IntermediateGripSupplier);
            dataEntity.IntermediateResilience = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.IntermediateResilienceSupplier);
            dataEntity.IntermediateStiffness = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.IntermediateStiffnessSupplier);
            dataEntity.IntermediateTemperature = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.IntermediateTemperatureSupplier);
            dataEntity.WetWeatherGrip = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.WetWeatherGripSupplier);
            dataEntity.WetWeatherResilience = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.WetWeatherResilienceSupplier);
            dataEntity.WetWeatherStiffness = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.WetWeatherStiffnessSupplier);
            dataEntity.WetWeatherTemperature = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.WetWeatherTemperatureSupplier);
        }

        private void ImportFuelAttributes(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            dataEntity.Performance = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Performance);
            dataEntity.Tolerance = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Tolerance);
        }

        private void ImportEngineContracts(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            // Pass parameters in context of engine suppliers
            ImportSupplierContracts(
                dataEntity,
                0x007EA27C,
                SponsorDataLocator.ContractEngineLocalOffset,
                dataLocator.ContractEngineTeamIdAddress,
                dataLocator.ContractEngineTeamIdValue,
                dataLocator.ContractEngineDealIdTeamValue,
                dataLocator.ContractEngineTermsIdTeamValue);

            /* TODO: Delete code block below once functionality confirmed in above shared method
            // Scan each contract block and add contracts that involve the supplier
            for (var contractId = 0; contractId < 11; contractId++)
            {
                // Get the sponsor address in the contract record
                var calculatedOffset = SponsorDataLocator.ContractEngineLocalOffset * contractId;
                var sponsorTeamIdAddress = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ContractEngineTeamIdAddress + calculatedOffset);

                // Determine the sponsor involved in the contract via the sponsor address
                const int sponsorTeamIdBaseAddress = 0x007EA27C;
                const int sponsorBlockSize = 0x00000614;
                var difference = sponsorTeamIdAddress - sponsorTeamIdBaseAddress; // Gives us a base figure to work with
                var derivedSponsorId = difference / sponsorBlockSize; // Gives us the zero based sponsor id

                // ReSharper disable once UnusedVariable
                var derivedContractId = (difference - sponsorBlockSize * derivedSponsorId) / 4; // Gives us the zero based contract number for the sponsor id

                // If contract record involves current sponsor, create contract
                if (dataEntity.SponsorId == derivedSponsorId + 1)
                {
                    var contract = _sponsorContractObjectFactory.Create();
                    contract.SponsorId = derivedSponsorId + 1;
                    contract.SponsorTypeId = 2;
                    contract.Cash = 0; // Leave unpopulated
                    contract.TeamId = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ContractEngineTeamIdValue + calculatedOffset);
                    contract.DealId = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ContractEngineDealIdTeamValue + calculatedOffset);
                    contract.TermsId = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ContractEngineTermsIdTeamValue + calculatedOffset);
                    dataEntity.Contracts.Add(contract);
                }
            }*/
        }

        private void ImportTyreContracts(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            // Pass parameters in context of tyre suppliers
            ImportSupplierContracts(
                dataEntity,
                0x007E9040,
                SponsorDataLocator.ContractTyreLocalOffset,
                dataLocator.ContractTyreTeamIdAddress,
                dataLocator.ContractTyreTeamIdValue,
                dataLocator.ContractTyreDealIdTeamValue,
                dataLocator.ContractTyreTermsIdTeamValue);

            /* TODO: Delete code block below once functionality confirmed in above shared method
            // Scan each contract block and add contracts that involve the supplier
            for (var contractId = 0; contractId < 11; contractId++)
            {
                // Get the sponsor address in the contract record
                var calculatedOffset = SponsorDataLocator.ContractTyreLocalOffset * contractId;
                var sponsorTeamIdAddress = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ContractTyreTeamIdAddress + calculatedOffset);

                // Determine the sponsor involved in the contract via the sponsor address
                const int sponsorTeamIdBaseAddress = 0x007E9040;
                const int sponsorBlockSize = 0x00000614;
                var difference = sponsorTeamIdAddress - sponsorTeamIdBaseAddress; // Gives us a base figure to work with
                var derivedSponsorId = difference / sponsorBlockSize; // Gives us the zero based sponsor id

                // ReSharper disable once UnusedVariable
                var derivedContractId = (difference - sponsorBlockSize * derivedSponsorId) / 4; // Gives us the zero based contract number for the sponsor id

                // If contract record involves current sponsor, create contract
                if (dataEntity.SponsorId == derivedSponsorId + 1)
                {
                    var contract = _sponsorContractObjectFactory.Create();
                    contract.SponsorId = derivedSponsorId + 1;
                    contract.SponsorTypeId = 3;
                    contract.Cash = 0; // Leave unpopulated
                    contract.TeamId = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ContractTyreTeamIdValue + calculatedOffset);
                    contract.DealId = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ContractTyreDealIdTeamValue + calculatedOffset);
                    contract.TermsId = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ContractTyreTermsIdTeamValue + calculatedOffset);
                    dataEntity.Contracts.Add(contract);
                }
            }*/
        }

        private void ImportFuelContracts(SponsorDataEntity dataEntity, SponsorDataLocator dataLocator)
        {
            // Pass parameters in context of fuel suppliers
            ImportSupplierContracts(
                dataEntity,
                0x007ED31C,
                SponsorDataLocator.ContractFuelLocalOffset,
                dataLocator.ContractFuelTeamIdAddress,
                dataLocator.ContractFuelTeamIdValue,
                dataLocator.ContractFuelDealIdTeamValue,
                dataLocator.ContractFuelTermsIdTeamValue);

            /* TODO: Delete code block below once functionality confirmed in above shared method
            // Scan each contract block and add contracts that involve the supplier
            for (var contractId = 0; contractId < 11; contractId++)
            {
                // Get the sponsor address in the contract record
                var calculatedOffset = SponsorDataLocator.ContractFuelLocalOffset * contractId;
                var sponsorTeamIdAddress = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ContractFuelTeamIdAddress + calculatedOffset);

                // Determine the sponsor involved in the contract via the sponsor address
                const int sponsorTeamIdBaseAddress = 0x007ED31C;
                const int sponsorBlockSize = 0x00000614;
                var difference = sponsorTeamIdAddress - sponsorTeamIdBaseAddress; // Gives us a base figure to work with
                var derivedSponsorId = difference / sponsorBlockSize; // Gives us the zero based sponsor id

                // ReSharper disable once UnusedVariable
                var derivedContractId = (difference - sponsorBlockSize * derivedSponsorId) / 4; // Gives us the zero based contract number for the sponsor id

                // If contract record involves current sponsor, create contract
                if (dataEntity.SponsorId == derivedSponsorId + 1)
                {
                    var contract = _sponsorContractObjectFactory.Create();
                    contract.SponsorId = derivedSponsorId + 1;
                    contract.SponsorTypeId = 4;
                    contract.Cash = 0; // Leave unpopulated
                    contract.TeamId = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ContractFuelTeamIdValue + calculatedOffset);
                    contract.DealId = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ContractFuelDealIdTeamValue + calculatedOffset);
                    contract.TermsId = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ContractFuelTermsIdTeamValue + calculatedOffset);
                    dataEntity.Contracts.Add(contract);
                }
            }*/
        }

        private void ImportSupplierContracts(
            SponsorDataEntity dataEntity,
            int sponsorTeamIdBaseAddress,
            int dataLocatorContractLocalOffset,
            int dataLocatorContractTeamIdAddress,
            int dataLocatorContractTeamIdValue,
            int dataLocatorContractDealIdTeamValue,
            int dataLocatorContractTermsIdTeamValue)
        {
            // Scan each contract block and add contracts that involve the supplier
            for (var contractId = 0; contractId < 11; contractId++)
            {
                // Get the sponsor address in the contract record
                var calculatedOffset = dataLocatorContractLocalOffset * contractId;
                var sponsorTeamIdAddress = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocatorContractTeamIdAddress + calculatedOffset);

                // Determine the sponsor involved in the contract via the sponsor address
                const int sponsorBlockSize = 0x00000614;
                var difference = sponsorTeamIdAddress - sponsorTeamIdBaseAddress; // Gives us a base figure to work with
                var derivedSponsorId = difference / sponsorBlockSize; // Gives us the zero based sponsor id

                // ReSharper disable once UnusedVariable
                var derivedContractId = (difference - sponsorBlockSize * derivedSponsorId) / 4; // Gives us the zero based contract number for the sponsor id

                // If contract record involves current sponsor, create contract
                if (dataEntity.SponsorId == derivedSponsorId + 1)
                {
                    var contract = _sponsorContractObjectFactory.Create();
                    contract.SponsorId = derivedSponsorId + 1;
                    contract.SponsorTypeId = dataEntity.SponsorTypeId; // Populate from parent
                    contract.Cash = 0; // Leave unpopulated
                    contract.TeamId = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocatorContractTeamIdValue + calculatedOffset);
                    contract.DealId = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocatorContractDealIdTeamValue + calculatedOffset);
                    contract.TermsId = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocatorContractTermsIdTeamValue + calculatedOffset);
                    dataEntity.Contracts.Add(contract);
                }
            }
        }
    }
}