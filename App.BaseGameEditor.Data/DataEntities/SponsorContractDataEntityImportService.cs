using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.Calculators;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorContractDataEntityImportService : IDataEntityImportService<SponsorContractDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<SponsorContractDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorContractDataLocator> _dataLocatorFactory;
        private readonly IdentityCalculator _identityCalculator;

        public SponsorContractDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<SponsorContractDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<SponsorContractDataLocator> dataLocatorFactory,
            IdentityCalculator identityCalculator)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
            _identityCalculator = identityCalculator ?? throw new ArgumentNullException(nameof(identityCalculator));
        }

        public SponsorContractDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);

            result.TeamId = id / 10 + 1;
            result.SlotId = (id + 1) - 10 * (result.TeamId - 1);

            switch (result.SlotId)
            {
                case int n when (n >= 1 && n <= 4):
                    result.SlotTypeId = result.SlotId;
                    break;
                case int n when (n >= 5 && n <= 10):
                    result.SlotTypeId = 5;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            result.SponsorId = ImportSponsorId(dataLocator, result.TeamId, result.SlotId);
            result.Cash = ImportCashValue(dataLocator);
            // Note: result.DealId is imported via another module and will be populated retrospectively
            // Note: result.TermsId is imported via another module and will be populated retrospectively

            return result;
        }

        private int ImportSponsorId(SponsorContractDataLocator dataLocator, int teamId, int slotId)
        {
            const int slotReferenceBaseAddress = 0x0120526C;
            const int teamBlockSize = 0x00001E90;

            // Return if slot does not have a contract
            var instructionValue = _dataEndpoint.GameExecutableFileResource.ReadByte(dataLocator.SlotInstruction);
            if (instructionValue == 0x90) return 0;

            // TODO: Enable validation, requires SlotData instructions to be ordered 1-10, not 1,2,4,3,5 as currently
            /*
                // Get the slot value in the slot record
                var slotValue = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.SlotValue);

                // Throw exception if game data is not correctly ordered by slots
                if (slotValue != slotId)
                {
                    throw new ArgumentOutOfRangeException(nameof(slotValue));
                }
                */

            // Get the slot address in the slot record
            var slotAddress = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.SlotAddress);

            // Calculate the sponsor id using the address where the slot value is recorded against
            var teamMultiplier = teamId - 1;
            var slotReferenceAddress = slotReferenceBaseAddress + teamBlockSize * teamMultiplier; // Address of SponsorId 0 (none)
            return (slotAddress - slotReferenceAddress) / 4;
        }

        private int ImportCashValue(SponsorContractDataLocator dataLocator)
        {
            // Return if slot does not have a contract
            var instructionValue = _dataEndpoint.GameExecutableFileResource.ReadByte(dataLocator.CashInstruction);
            if (instructionValue == 0x90) return 0;

            return _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CashValue);
        }
    }
}