using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorContractDataEntityExportService : IDataEntityExportService<SponsorContractDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<SponsorContractDataLocator> _dataLocatorFactory;

        public SponsorContractDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<SponsorContractDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(SponsorContractDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));

            var dataLocator = _dataLocatorFactory.Create(dataEntity.Id);
            dataLocator.Initialise();

            ExportSponsorId(dataEntity, dataLocator);
            ExportCashValue(dataEntity, dataLocator);
            // Note: dataEntity.DealId is exported via another module and will be populated preemtively
            // Note: dataEntity.TermsId is exported via another module and will be populated preemtively
        }

        private void ExportSponsorId(SponsorContractDataEntity dataEntity, SponsorContractDataLocator dataLocator)
        {
            const int slotReferenceBaseAddress = 0x0120526C;
            const int teamBlockSize = 0x00001E90;

            // Write slot value if a sponsor is assigned to the contract
            if (dataEntity.SponsorId != 0)
            {
                var teamMultiplier = dataEntity.TeamId - 1;
                var slotReferenceAddress = slotReferenceBaseAddress + teamBlockSize * teamMultiplier; // Address of SponsorId 0 (none)
                var slotAddress = slotReferenceAddress + dataEntity.SponsorId * 4; // Export the SponsorId as an address value

                var slotInstructions = new List<byte>();

                slotInstructions.AddRange(new byte[] { 0xC7, 0x05 });                // mov
                slotInstructions.AddRange(BitConverter.GetBytes(slotAddress));       //         ds:dword_XXXXXX,
                slotInstructions.AddRange(BitConverter.GetBytes(dataEntity.SlotId)); //                          X

                _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.SlotInstruction, slotInstructions.ToArray());
            }
            else
            {
                var slotInstructions = new List<byte>();

                slotInstructions.AddRange(new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }); // nop

                _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.SlotInstruction, slotInstructions.ToArray());
            }
        }

        private void ExportCashValue(SponsorContractDataEntity dataEntity, SponsorContractDataLocator dataLocator)
        {
            // Write cash value if a sponsor is assigned to the contract
            if (dataEntity.SponsorId != 0)
            {
                _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.CashValue, dataEntity.Cash);
            }
            else
            {
                var cashValueInstructions = new List<byte>();

                cashValueInstructions.AddRange(new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }); // nop

                _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.CashInstruction, cashValueInstructions.ToArray());
            }
        }
    }
}