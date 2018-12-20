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
        private const int TeamItemCount = 7;
        private const int EngineItemCount = 8;
        private const int TyreItemCount = 3;
        private const int FuelItemCount = 9;
        private const int CashItemCount = 71;
        private const int ContractItemCount = 10;

        private readonly SponsorshipDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<SponsorshipTeamEntity> _teamEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipEngineEntity> _engineEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipTyreEntity> _tyreEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipFuelEntity> _fuelEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipCashEntity> _cashEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam01Entity> _contractTeam01EntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam02Entity> _contractTeam02EntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam03Entity> _contractTeam03EntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam04Entity> _contractTeam04EntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam05Entity> _contractTeam05EntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam06Entity> _contractTeam06EntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam07Entity> _contractTeam07EntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam08Entity> _contractTeam08EntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam09Entity> _contractTeam09EntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam10Entity> _contractTeam10EntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam11Entity> _contractTeam11EntityFactory;
        private readonly IMapperService _mapperService;

        public SponsorshipDomainModelImportService(
            SponsorshipDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<SponsorshipTeamEntity> teamEntityFactory,
            IIntegerIdentityFactory<SponsorshipEngineEntity> engineEntityFactory,
            IIntegerIdentityFactory<SponsorshipTyreEntity> tyreEntityFactory,
            IIntegerIdentityFactory<SponsorshipFuelEntity> fuelEntityFactory,
            IIntegerIdentityFactory<SponsorshipCashEntity> cashEntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam01Entity> contractTeam01EntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam02Entity> contractTeam02EntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam03Entity> contractTeam03EntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam04Entity> contractTeam04EntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam05Entity> contractTeam05EntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam06Entity> contractTeam06EntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam07Entity> contractTeam07EntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam08Entity> contractTeam08EntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam09Entity> contractTeam09EntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam10Entity> contractTeam10EntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam11Entity> contractTeam11EntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _teamEntityFactory = teamEntityFactory ?? throw new ArgumentNullException(nameof(teamEntityFactory));
            _engineEntityFactory = engineEntityFactory ?? throw new ArgumentNullException(nameof(engineEntityFactory));
            _tyreEntityFactory = tyreEntityFactory ?? throw new ArgumentNullException(nameof(tyreEntityFactory));
            _fuelEntityFactory = fuelEntityFactory ?? throw new ArgumentNullException(nameof(fuelEntityFactory));
            _cashEntityFactory = cashEntityFactory ?? throw new ArgumentNullException(nameof(cashEntityFactory));
            _contractTeam01EntityFactory = contractTeam01EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam01EntityFactory));
            _contractTeam02EntityFactory = contractTeam02EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam02EntityFactory));
            _contractTeam03EntityFactory = contractTeam03EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam03EntityFactory));
            _contractTeam04EntityFactory = contractTeam04EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam04EntityFactory));
            _contractTeam05EntityFactory = contractTeam05EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam05EntityFactory));
            _contractTeam06EntityFactory = contractTeam06EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam06EntityFactory));
            _contractTeam07EntityFactory = contractTeam07EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam07EntityFactory));
            _contractTeam08EntityFactory = contractTeam08EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam08EntityFactory));
            _contractTeam09EntityFactory = contractTeam09EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam09EntityFactory));
            _contractTeam10EntityFactory = contractTeam10EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam10EntityFactory));
            _contractTeam11EntityFactory = contractTeam11EntityFactory ?? throw new ArgumentNullException(nameof(contractTeam11EntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Import()
        {
            ImportSponsorshipTeams();
            ImportSponsorshipEngines();
            ImportSponsorshipTyres();
            ImportSponsorshipFuels();
            ImportSponsorshipCashs();
            ImportSponsorshipContractsTeam01();
            ImportSponsorshipContractsTeam02();
            ImportSponsorshipContractsTeam03();
            ImportSponsorshipContractsTeam04();
            ImportSponsorshipContractsTeam05();
            ImportSponsorshipContractsTeam06();
            ImportSponsorshipContractsTeam07();
            ImportSponsorshipContractsTeam08();
            ImportSponsorshipContractsTeam09();
            ImportSponsorshipContractsTeam10();
            ImportSponsorshipContractsTeam11();
        }

        private void ImportSponsorshipTeams()
        {
            var entities = new List<SponsorshipTeamEntity>();
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
            var entities = new List<SponsorshipEngineEntity>();
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
            var entities = new List<SponsorshipTyreEntity>();
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
            var entities = new List<SponsorshipFuelEntity>();
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
            var entities = new List<SponsorshipCashEntity>();
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
    }
}