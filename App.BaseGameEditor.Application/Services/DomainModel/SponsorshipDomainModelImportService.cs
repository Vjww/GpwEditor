using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Services;
using App.Core.Factories;
using App.Shared.Infrastructure.Services;

namespace App.BaseGameEditor.Application.Services.DomainModel
{
    public class SponsorshipDomainModelImportService
    {
        private const int SponsorItemCount = 98;
        private const int SponsorContractItemCount = 110;
        // TODO: private const int TeamItemCount = 7;
        // TODO: private const int EngineItemCount = 8;
        // TODO: private const int TyreItemCount = 3;
        // TODO: private const int FuelItemCount = 9;
        // TODO: private const int CashItemCount = 71;
        // TODO: private const int ContractItemCount = 10;

        private readonly SponsorDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<SponsorEntity> _sponsorEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorContractEntity> _sponsorContractEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorTeamEntity> _teamEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorEngineEntity> _engineEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorTyreEntity> _tyreEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorFuelEntity> _fuelEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorCashEntity> _cashEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam01Entity> _contractTeam01EntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam02Entity> _contractTeam02EntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam03Entity> _contractTeam03EntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam04Entity> _contractTeam04EntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam05Entity> _contractTeam05EntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam06Entity> _contractTeam06EntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam07Entity> _contractTeam07EntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam08Entity> _contractTeam08EntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam09Entity> _contractTeam09EntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam10Entity> _contractTeam10EntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam11Entity> _contractTeam11EntityFactory;
        private readonly IMapperService _mapperService;

        public SponsorshipDomainModelImportService(
            SponsorDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<SponsorEntity> sponsorEntityFactory,
            IIntegerIdentityFactory<SponsorContractEntity> sponsorContractEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorTeamEntity> teamEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorEngineEntity> engineEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorTyreEntity> tyreEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorFuelEntity> fuelEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorCashEntity> cashEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam01Entity> contractTeam01EntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam02Entity> contractTeam02EntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam03Entity> contractTeam03EntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam04Entity> contractTeam04EntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam05Entity> contractTeam05EntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam06Entity> contractTeam06EntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam07Entity> contractTeam07EntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam08Entity> contractTeam08EntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam09Entity> contractTeam09EntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam10Entity> contractTeam10EntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam11Entity> contractTeam11EntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _sponsorEntityFactory = sponsorEntityFactory ?? throw new ArgumentNullException(nameof(sponsorEntityFactory));
            _sponsorContractEntityFactory = sponsorContractEntityFactory ?? throw new ArgumentNullException(nameof(sponsorContractEntityFactory));
            // TODO: _teamEntityFactory = teamEntityFactory ?? throw new ArgumentNullException(nameof(teamEntityFactory));
            // TODO: _engineEntityFactory = engineEntityFactory ?? throw new ArgumentNullException(nameof(engineEntityFactory));
            // TODO: _tyreEntityFactory = tyreEntityFactory ?? throw new ArgumentNullException(nameof(tyreEntityFactory));
            // TODO: _fuelEntityFactory = fuelEntityFactory ?? throw new ArgumentNullException(nameof(fuelEntityFactory));
            // TODO: _cashEntityFactory = cashEntityFactory ?? throw new ArgumentNullException(nameof(cashEntityFactory));
            // TODO: _contractTeam01EntityFactory = contractTeam01EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam01EntityFactory));
            // TODO: _contractTeam02EntityFactory = contractTeam02EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam02EntityFactory));
            // TODO: _contractTeam03EntityFactory = contractTeam03EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam03EntityFactory));
            // TODO: _contractTeam04EntityFactory = contractTeam04EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam04EntityFactory));
            // TODO: _contractTeam05EntityFactory = contractTeam05EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam05EntityFactory));
            // TODO: _contractTeam06EntityFactory = contractTeam06EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam06EntityFactory));
            // TODO: _contractTeam07EntityFactory = contractTeam07EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam07EntityFactory));
            // TODO: _contractTeam08EntityFactory = contractTeam08EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam08EntityFactory));
            // TODO: _contractTeam09EntityFactory = contractTeam09EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam09EntityFactory));
            // TODO: _contractTeam10EntityFactory = contractTeam10EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam10EntityFactory));
            // TODO: _contractTeam11EntityFactory = contractTeam11EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam11EntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Import()
        {
            ImportSponsors();
            ImportSponsorContracts();

            // TODO: ImportSponsorshipTeams();
            // TODO: ImportSponsorshipEngines();
            // TODO: ImportSponsorshipTyres();
            // TODO: ImportSponsorshipFuels();
            // TODO: ImportSponsorshipCashs();
            // TODO: ImportSponsorshipContractsTeam01();
            // TODO: ImportSponsorshipContractsTeam02();
            // TODO: ImportSponsorshipContractsTeam03();
            // TODO: ImportSponsorshipContractsTeam04();
            // TODO: ImportSponsorshipContractsTeam05();
            // TODO: ImportSponsorshipContractsTeam06();
            // TODO: ImportSponsorshipContractsTeam07();
            // TODO: ImportSponsorshipContractsTeam08();
            // TODO: ImportSponsorshipContractsTeam09();
            // TODO: ImportSponsorshipContractsTeam10();
            // TODO: ImportSponsorshipContractsTeam11();

            BlendDataAfterImport();
        }

        private void BlendDataAfterImport()
        {
            var sponsors = _domainService.GetSponsors().ToList();
            var sponsorContracts = _domainService.GetSponsorContracts().ToList();

            // Move values from SponsorContracts to Sponsor.Contracts
            foreach (var sponsor in sponsors)
            {
                foreach (var contract in sponsor.Contracts)
                {
                    foreach (var sponsorContract in sponsorContracts)
                    {
                        if (sponsorContract.SlotTypeId == contract.SponsorTypeId && sponsorContract.TeamId == contract.TeamId)
                        {
                            contract.Cash = sponsorContract.Cash;
                        }
                    }
                }
            }
            _domainService.SetSponsors(sponsors);

            // Move values from Sponsor.Contracts to SponsorContracts
            foreach (var sponsorContract in sponsorContracts)
            {
                foreach (var sponsor in sponsors)
                {
                    foreach (var contract in sponsor.Contracts)
                    {
                        if (contract.SponsorTypeId == sponsorContract.SlotTypeId && contract.TeamId == sponsorContract.TeamId)
                        {
                            sponsorContract.DealId = contract.DealId;
                            sponsorContract.TermsId = contract.TermsId;
                        }
                    }
                }
            }
            _domainService.SetSponsorContracts(sponsorContracts);
        }

        private void ImportSponsors()
        {
            var entities = new List<SponsorEntity>();
            for (var i = 0; i < SponsorItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.Sponsors.Get(x => x.Id == id).Single();

                var entity = _sponsorEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsors(entities);
        }

        private void ImportSponsorContracts()
        {
            var entities = new List<SponsorContractEntity>();
            for (var i = 0; i < SponsorContractItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorContracts.Get(x => x.Id == id).Single();

                var entity = _sponsorContractEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorContracts(entities);
        }

        /*
        private void ImportSponsorshipTeams()
        {
            var entities = new List<SponsorTeamEntity>();
            for (var i = 0; i < TeamItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipTeams.Get(x => x.Id == id).Single();

                var entity = _teamEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipTeams(entities);
        }

        private void ImportSponsorshipEngines()
        {
            var entities = new List<SponsorEngineEntity>();
            for (var i = 0; i < EngineItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipEngines.Get(x => x.Id == id).Single();

                var entity = _engineEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipEngines(entities);
        }

        private void ImportSponsorshipTyres()
        {
            var entities = new List<SponsorTyreEntity>();
            for (var i = 0; i < TyreItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipTyres.Get(x => x.Id == id).Single();

                var entity = _tyreEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipTyres(entities);
        }

        private void ImportSponsorshipFuels()
        {
            var entities = new List<SponsorFuelEntity>();
            for (var i = 0; i < FuelItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipFuels.Get(x => x.Id == id).Single();

                var entity = _fuelEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipFuels(entities);
        }

        private void ImportSponsorshipCashs()
        {
            var entities = new List<SponsorCashEntity>();
            for (var i = 0; i < CashItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipCashs.Get(x => x.Id == id).Single();

                var entity = _cashEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipCashs(entities);
        }

        private void ImportSponsorshipContractsTeam01()
        {
            var entities = new List<SponsorshipContractTeam01Entity>();
            for (var i = 0; i < ContractItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipContractsTeam01.Get(x => x.Id == id).Single();

                var entity = _contractTeam01EntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipContractsTeam01(entities);
        }

        private void ImportSponsorshipContractsTeam02()
        {
            var entities = new List<SponsorshipContractTeam02Entity>();
            for (var i = 0; i < ContractItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipContractsTeam02.Get(x => x.Id == id).Single();

                var entity = _contractTeam02EntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipContractsTeam02(entities);
        }

        private void ImportSponsorshipContractsTeam03()
        {
            var entities = new List<SponsorshipContractTeam03Entity>();
            for (var i = 0; i < ContractItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipContractsTeam03.Get(x => x.Id == id).Single();

                var entity = _contractTeam03EntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipContractsTeam03(entities);
        }

        private void ImportSponsorshipContractsTeam04()
        {
            var entities = new List<SponsorshipContractTeam04Entity>();
            for (var i = 0; i < ContractItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipContractsTeam04.Get(x => x.Id == id).Single();

                var entity = _contractTeam04EntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipContractsTeam04(entities);
        }

        private void ImportSponsorshipContractsTeam05()
        {
            var entities = new List<SponsorshipContractTeam05Entity>();
            for (var i = 0; i < ContractItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipContractsTeam05.Get(x => x.Id == id).Single();

                var entity = _contractTeam05EntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipContractsTeam05(entities);
        }

        private void ImportSponsorshipContractsTeam06()
        {
            var entities = new List<SponsorshipContractTeam06Entity>();
            for (var i = 0; i < ContractItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipContractsTeam06.Get(x => x.Id == id).Single();

                var entity = _contractTeam06EntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipContractsTeam06(entities);
        }

        private void ImportSponsorshipContractsTeam07()
        {
            var entities = new List<SponsorshipContractTeam07Entity>();
            for (var i = 0; i < ContractItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipContractsTeam07.Get(x => x.Id == id).Single();

                var entity = _contractTeam07EntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipContractsTeam07(entities);
        }

        private void ImportSponsorshipContractsTeam08()
        {
            var entities = new List<SponsorshipContractTeam08Entity>();
            for (var i = 0; i < ContractItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipContractsTeam08.Get(x => x.Id == id).Single();

                var entity = _contractTeam08EntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipContractsTeam08(entities);
        }

        private void ImportSponsorshipContractsTeam09()
        {
            var entities = new List<SponsorshipContractTeam09Entity>();
            for (var i = 0; i < ContractItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipContractsTeam09.Get(x => x.Id == id).Single();

                var entity = _contractTeam09EntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipContractsTeam09(entities);
        }

        private void ImportSponsorshipContractsTeam10()
        {
            var entities = new List<SponsorshipContractTeam10Entity>();
            for (var i = 0; i < ContractItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipContractsTeam10.Get(x => x.Id == id).Single();

                var entity = _contractTeam10EntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipContractsTeam10(entities);
        }

        private void ImportSponsorshipContractsTeam11()
        {
            var entities = new List<SponsorshipContractTeam11Entity>();
            for (var i = 0; i < ContractItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipContractsTeam11.Get(x => x.Id == id).Single();

                var entity = _contractTeam11EntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipContractsTeam11(entities);
        }
        */
    }
}