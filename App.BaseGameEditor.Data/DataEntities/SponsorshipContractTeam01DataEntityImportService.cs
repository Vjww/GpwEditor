using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.Calculators;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorshipContractTeam01DataEntityImportService : IDataEntityImportService<SponsorshipContractTeam01DataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam01DataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractDataLocator> _dataLocatorFactory;
        private readonly IdentityCalculator _identityCalculator;

        public SponsorshipContractTeam01DataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<SponsorshipContractTeam01DataEntity> dataEntityFactory,
            IIntegerIdentityFactory<SponsorshipContractDataLocator> dataLocatorFactory,
            IdentityCalculator identityCalculator)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
            _identityCalculator = identityCalculator ?? throw new ArgumentNullException(nameof(identityCalculator));
        }

        public SponsorshipContractTeam01DataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);

            result.TeamId = 1; // TODO: Update for each class and remove this message
            result.SlotId = id + 1;

            switch (result.SlotId)
            {
                case int n when (n >= 1 && n <= 4):
                    result.SponsorType = result.SlotId;
                    break;
                case int n when (n >= 5 && n <= 10):
                    result.SponsorType = 5;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            result.SponsorId = ImportSponsorId(dataLocator, result.TeamId, result.SlotId);
            result.ContractValue = ImportCashSponsorshipValue(dataLocator, result.TeamId, result.SlotId);
            // result.ContractDeal = ImportSupplierDeal(dataLocator, result.TeamId, result.SlotId);   // TODO: Implemented in BLL
            // result.ContractTerms = ImportSupplierTerms(dataLocator, result.TeamId, result.SlotId); // TODO: Implemented in BLL

            //// Import attributes specific to suppliers
            //if (result.SlotId == 2 || result.SlotId == 3 || result.SlotId == 4)
            //{
            //    // TODO: Requires deeper thought on how to import data! as arranged by sponsor, not team
            //    // result.SponsorsTeamId
            //    result.ContractDeal = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.GetContractDeal(teamId));
            //    result.ContractTerms = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.GetContractTerms(teamId));
            //}

            return result;
        }

        private int ImportSponsorId(SponsorshipContractDataLocator dataLocator, int teamId, int slotId)
        {
            const int baseSlotReferenceAddress = 0x0120526C;
            var slotReferenceAddress = baseSlotReferenceAddress + 7824 * (teamId - 1); // Address of SponsorId 0 (none)

            // TODO: If slot numbers will be ordered 1-10, then no need to have a for loop to find slot and go straight for the record if it isnt nop'd.
            // For each slot record in team block (10 slot records per team)
            for (var recordId = 1; recordId < 11; recordId++)
            {
                // Skip empty slots if exists
                var instructionValue = _dataEndpoint.GameExecutableFileResource.ReadByte(dataLocator.SlotInstruction(teamId, recordId));
                if (instructionValue == 0x90) continue;

                // Get the slot value in the slot record
                var slotValue = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.SlotValue(teamId, recordId));

                // If record has matching slot id
                if (slotValue == slotId)
                {
                    // Get the slot address in the slot record
                    var slotAddress = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.SlotAddress(teamId, recordId));

                    // Calculate the sponsor id using the address where the slot value is recorded against
                    return (slotAddress - slotReferenceAddress) / 4;
                }
            }

            return 0;
        }

        private int ImportCashSponsorshipValue(SponsorshipContractDataLocator dataLocator, int teamId, int slotId)
        {
            throw new NotImplementedException();
        }
    }
}