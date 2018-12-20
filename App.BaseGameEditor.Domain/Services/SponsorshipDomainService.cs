using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Entities;
using App.Core.Repositories;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.Services
{
    public class SponsorshipDomainService
    {
        private readonly IRepository<SponsorEntity> _sponsorRepository;
        private readonly IRepository<SponsorshipTeamEntity> _sponsorshipTeamRepository;
        private readonly IEntityValidator<SponsorshipTeamEntity> _sponsorshipTeamEntityValidator;
        private readonly IRepository<SponsorshipEngineEntity> _sponsorshipEngineRepository;
        private readonly IEntityValidator<SponsorshipEngineEntity> _sponsorshipEngineEntityValidator;
        private readonly IRepository<SponsorshipTyreEntity> _sponsorshipTyreRepository;
        private readonly IEntityValidator<SponsorshipTyreEntity> _sponsorshipTyreEntityValidator;
        private readonly IRepository<SponsorshipFuelEntity> _sponsorshipFuelRepository;
        private readonly IEntityValidator<SponsorshipFuelEntity> _sponsorshipFuelEntityValidator;
        private readonly IRepository<SponsorshipCashEntity> _sponsorshipCashRepository;
        private readonly IEntityValidator<SponsorshipCashEntity> _sponsorshipCashEntityValidator;
        private readonly IRepository<SponsorshipContractTeam01Entity> _sponsorshipContractTeam01Repository;
        private readonly IRepository<SponsorshipContractTeam02Entity> _sponsorshipContractTeam02Repository;
        private readonly IRepository<SponsorshipContractTeam03Entity> _sponsorshipContractTeam03Repository;
        private readonly IRepository<SponsorshipContractTeam04Entity> _sponsorshipContractTeam04Repository;
        private readonly IRepository<SponsorshipContractTeam05Entity> _sponsorshipContractTeam05Repository;
        private readonly IRepository<SponsorshipContractTeam06Entity> _sponsorshipContractTeam06Repository;
        private readonly IRepository<SponsorshipContractTeam07Entity> _sponsorshipContractTeam07Repository;
        private readonly IRepository<SponsorshipContractTeam08Entity> _sponsorshipContractTeam08Repository;
        private readonly IRepository<SponsorshipContractTeam09Entity> _sponsorshipContractTeam09Repository;
        private readonly IRepository<SponsorshipContractTeam10Entity> _sponsorshipContractTeam10Repository;
        private readonly IRepository<SponsorshipContractTeam11Entity> _sponsorshipContractTeam11Repository;
        private readonly IEntityValidator<SponsorshipContractTeam01Entity> _sponsorshipContractTeam01EntityValidator;
        private readonly IEntityValidator<SponsorshipContractTeam02Entity> _sponsorshipContractTeam02EntityValidator;
        private readonly IEntityValidator<SponsorshipContractTeam03Entity> _sponsorshipContractTeam03EntityValidator;
        private readonly IEntityValidator<SponsorshipContractTeam04Entity> _sponsorshipContractTeam04EntityValidator;
        private readonly IEntityValidator<SponsorshipContractTeam05Entity> _sponsorshipContractTeam05EntityValidator;
        private readonly IEntityValidator<SponsorshipContractTeam06Entity> _sponsorshipContractTeam06EntityValidator;
        private readonly IEntityValidator<SponsorshipContractTeam07Entity> _sponsorshipContractTeam07EntityValidator;
        private readonly IEntityValidator<SponsorshipContractTeam08Entity> _sponsorshipContractTeam08EntityValidator;
        private readonly IEntityValidator<SponsorshipContractTeam09Entity> _sponsorshipContractTeam09EntityValidator;
        private readonly IEntityValidator<SponsorshipContractTeam10Entity> _sponsorshipContractTeam10EntityValidator;
        private readonly IEntityValidator<SponsorshipContractTeam11Entity> _sponsorshipContractTeam11EntityValidator;

        public SponsorshipDomainService(
            IRepository<SponsorEntity> sponsorRepository,
            IRepository<SponsorshipTeamEntity> sponsorshipTeamRepository,
            IEntityValidator<SponsorshipTeamEntity> sponsorshipTeamEntityValidator,
            IRepository<SponsorshipEngineEntity> sponsorshipEngineRepository,
            IEntityValidator<SponsorshipEngineEntity> sponsorshipEngineEntityValidator,
            IRepository<SponsorshipTyreEntity> sponsorshipTyreRepository,
            IEntityValidator<SponsorshipTyreEntity> sponsorshipTyreEntityValidator,
            IRepository<SponsorshipFuelEntity> sponsorshipFuelRepository,
            IEntityValidator<SponsorshipFuelEntity> sponsorshipFuelEntityValidator,
            IRepository<SponsorshipCashEntity> sponsorshipCashRepository,
            IEntityValidator<SponsorshipCashEntity> sponsorshipCashEntityValidator, 
            IRepository<SponsorshipContractTeam01Entity> sponsorshipContractTeam01Repository,
            IRepository<SponsorshipContractTeam02Entity> sponsorshipContractTeam02Repository,
            IRepository<SponsorshipContractTeam03Entity> sponsorshipContractTeam03Repository,
            IRepository<SponsorshipContractTeam04Entity> sponsorshipContractTeam04Repository,
            IRepository<SponsorshipContractTeam05Entity> sponsorshipContractTeam05Repository,
            IRepository<SponsorshipContractTeam06Entity> sponsorshipContractTeam06Repository,
            IRepository<SponsorshipContractTeam07Entity> sponsorshipContractTeam07Repository,
            IRepository<SponsorshipContractTeam08Entity> sponsorshipContractTeam08Repository,
            IRepository<SponsorshipContractTeam09Entity> sponsorshipContractTeam09Repository,
            IRepository<SponsorshipContractTeam10Entity> sponsorshipContractTeam10Repository,
            IRepository<SponsorshipContractTeam11Entity> sponsorshipContractTeam11Repository,
            IEntityValidator<SponsorshipContractTeam01Entity> sponsorshipContractTeam01EntityValidator,
            IEntityValidator<SponsorshipContractTeam02Entity> sponsorshipContractTeam02EntityValidator,
            IEntityValidator<SponsorshipContractTeam03Entity> sponsorshipContractTeam03EntityValidator,
            IEntityValidator<SponsorshipContractTeam04Entity> sponsorshipContractTeam04EntityValidator,
            IEntityValidator<SponsorshipContractTeam05Entity> sponsorshipContractTeam05EntityValidator,
            IEntityValidator<SponsorshipContractTeam06Entity> sponsorshipContractTeam06EntityValidator,
            IEntityValidator<SponsorshipContractTeam07Entity> sponsorshipContractTeam07EntityValidator,
            IEntityValidator<SponsorshipContractTeam08Entity> sponsorshipContractTeam08EntityValidator,
            IEntityValidator<SponsorshipContractTeam09Entity> sponsorshipContractTeam09EntityValidator,
            IEntityValidator<SponsorshipContractTeam10Entity> sponsorshipContractTeam10EntityValidator,
            IEntityValidator<SponsorshipContractTeam11Entity> sponsorshipContractTeam11EntityValidator)
        {
            _sponsorRepository = sponsorRepository ?? throw new ArgumentNullException(nameof(sponsorRepository));
            _sponsorshipTeamRepository = sponsorshipTeamRepository ?? throw new ArgumentNullException(nameof(sponsorshipTeamRepository));
            _sponsorshipTeamEntityValidator = sponsorshipTeamEntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipTeamEntityValidator));
            _sponsorshipEngineRepository = sponsorshipEngineRepository ?? throw new ArgumentNullException(nameof(sponsorshipEngineRepository));
            _sponsorshipEngineEntityValidator = sponsorshipEngineEntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipEngineEntityValidator));
            _sponsorshipTyreRepository = sponsorshipTyreRepository ?? throw new ArgumentNullException(nameof(sponsorshipTyreRepository));
            _sponsorshipTyreEntityValidator = sponsorshipTyreEntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipTyreEntityValidator));
            _sponsorshipFuelRepository = sponsorshipFuelRepository ?? throw new ArgumentNullException(nameof(sponsorshipFuelRepository));
            _sponsorshipFuelEntityValidator = sponsorshipFuelEntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipFuelEntityValidator));
            _sponsorshipCashRepository = sponsorshipCashRepository ?? throw new ArgumentNullException(nameof(sponsorshipCashRepository));
            _sponsorshipCashEntityValidator = sponsorshipCashEntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipCashEntityValidator));
            _sponsorshipContractTeam01Repository = sponsorshipContractTeam01Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam01Repository));
            _sponsorshipContractTeam02Repository = sponsorshipContractTeam02Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam02Repository));
            _sponsorshipContractTeam03Repository = sponsorshipContractTeam03Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam03Repository));
            _sponsorshipContractTeam04Repository = sponsorshipContractTeam04Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam04Repository));
            _sponsorshipContractTeam05Repository = sponsorshipContractTeam05Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam05Repository));
            _sponsorshipContractTeam06Repository = sponsorshipContractTeam06Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam06Repository));
            _sponsorshipContractTeam07Repository = sponsorshipContractTeam07Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam07Repository));
            _sponsorshipContractTeam08Repository = sponsorshipContractTeam08Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam08Repository));
            _sponsorshipContractTeam09Repository = sponsorshipContractTeam09Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam09Repository));
            _sponsorshipContractTeam10Repository = sponsorshipContractTeam10Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam10Repository));
            _sponsorshipContractTeam11Repository = sponsorshipContractTeam11Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam11Repository));
            _sponsorshipContractTeam01EntityValidator = sponsorshipContractTeam01EntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam01EntityValidator));
            _sponsorshipContractTeam02EntityValidator = sponsorshipContractTeam02EntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam02EntityValidator));
            _sponsorshipContractTeam03EntityValidator = sponsorshipContractTeam03EntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam03EntityValidator));
            _sponsorshipContractTeam04EntityValidator = sponsorshipContractTeam04EntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam04EntityValidator));
            _sponsorshipContractTeam05EntityValidator = sponsorshipContractTeam05EntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam05EntityValidator));
            _sponsorshipContractTeam06EntityValidator = sponsorshipContractTeam06EntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam06EntityValidator));
            _sponsorshipContractTeam07EntityValidator = sponsorshipContractTeam07EntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam07EntityValidator));
            _sponsorshipContractTeam08EntityValidator = sponsorshipContractTeam08EntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam08EntityValidator));
            _sponsorshipContractTeam09EntityValidator = sponsorshipContractTeam09EntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam09EntityValidator));
            _sponsorshipContractTeam10EntityValidator = sponsorshipContractTeam10EntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam10EntityValidator));
            _sponsorshipContractTeam11EntityValidator = sponsorshipContractTeam11EntityValidator ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam11EntityValidator));
        }

        public IEnumerable<SponsorshipTeamEntity> GetSponsorshipTeams()
        {
            // TODO: Get all team sponsor records from all sponsors repository
            // TODO: e.g. var teamSponsors = _sponsorsRepository.Get(x => x.SponsorType == SponsorType.Team);
            // TODO:      mapper.Map<IEnum<SponsorTeamEntity>>(teamSponsors);
            var entities = _sponsorRepository.Get(x => x.SponsorType == 1).OrderBy(x => x.Id); // TODO: Use Enum
            return mapper.Map<SponsorshipTeamEntity>(entities);

            return _sponsorshipTeamRepository.Get();
        }

        public void SetSponsorshipTeams(IEnumerable<SponsorshipTeamEntity> sponsorshipTeams)
        {
            if (sponsorshipTeams == null) throw new ArgumentNullException(nameof(sponsorshipTeams));

            var validationMessages = new List<string>();

            var list = sponsorshipTeams as IList<SponsorshipTeamEntity> ?? sponsorshipTeams.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipTeamEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipTeamRepository.Set(list);
        }

        public void SetSponsorshipTeam(SponsorshipTeamEntity sponsorshipTeam)
        {
            if (sponsorshipTeam == null) throw new ArgumentNullException(nameof(sponsorshipTeam));

            var validationMessages = new List<string>();

            var messages = _sponsorshipTeamEntityValidator.Validate(sponsorshipTeam);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipTeamRepository.SetById(sponsorshipTeam);
        }

        public IEnumerable<SponsorshipEngineEntity> GetSponsorshipEngines()
        {
            return _sponsorshipEngineRepository.Get();
        }

        public void SetSponsorshipEngines(IEnumerable<SponsorshipEngineEntity> sponsorshipEngines)
        {
            if (sponsorshipEngines == null) throw new ArgumentNullException(nameof(sponsorshipEngines));

            var validationMessages = new List<string>();

            var list = sponsorshipEngines as IList<SponsorshipEngineEntity> ?? sponsorshipEngines.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipEngineEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipEngineRepository.Set(list);
        }

        public void SetSponsorshipEngine(SponsorshipEngineEntity sponsorshipEngine)
        {
            if (sponsorshipEngine == null) throw new ArgumentNullException(nameof(sponsorshipEngine));

            var validationMessages = new List<string>();

            var messages = _sponsorshipEngineEntityValidator.Validate(sponsorshipEngine);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipEngineRepository.SetById(sponsorshipEngine);
        }

        public IEnumerable<SponsorshipTyreEntity> GetSponsorshipTyres()
        {
            return _sponsorshipTyreRepository.Get();
        }

        public void SetSponsorshipTyres(IEnumerable<SponsorshipTyreEntity> sponsorshipTyres)
        {
            if (sponsorshipTyres == null) throw new ArgumentNullException(nameof(sponsorshipTyres));

            var validationMessages = new List<string>();

            var list = sponsorshipTyres as IList<SponsorshipTyreEntity> ?? sponsorshipTyres.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipTyreEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipTyreRepository.Set(list);
        }

        public void SetSponsorshipTyre(SponsorshipTyreEntity sponsorshipTyre)
        {
            if (sponsorshipTyre == null) throw new ArgumentNullException(nameof(sponsorshipTyre));

            var validationMessages = new List<string>();

            var messages = _sponsorshipTyreEntityValidator.Validate(sponsorshipTyre);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipTyreRepository.SetById(sponsorshipTyre);
        }

        public IEnumerable<SponsorshipFuelEntity> GetSponsorshipFuels()
        {
            return _sponsorshipFuelRepository.Get();
        }

        public void SetSponsorshipFuels(IEnumerable<SponsorshipFuelEntity> sponsorshipFuels)
        {
            if (sponsorshipFuels == null) throw new ArgumentNullException(nameof(sponsorshipFuels));

            var validationMessages = new List<string>();

            var list = sponsorshipFuels as IList<SponsorshipFuelEntity> ?? sponsorshipFuels.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipFuelEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipFuelRepository.Set(list);
        }

        public void SetSponsorshipFuel(SponsorshipFuelEntity sponsorshipFuel)
        {
            if (sponsorshipFuel == null) throw new ArgumentNullException(nameof(sponsorshipFuel));

            var validationMessages = new List<string>();

            var messages = _sponsorshipFuelEntityValidator.Validate(sponsorshipFuel);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipFuelRepository.SetById(sponsorshipFuel);
        }

        public IEnumerable<SponsorshipCashEntity> GetSponsorshipCashs()
        {
            return _sponsorshipCashRepository.Get();
        }

        public void SetSponsorshipCashs(IEnumerable<SponsorshipCashEntity> sponsorshipCashs)
        {
            if (sponsorshipCashs == null) throw new ArgumentNullException(nameof(sponsorshipCashs));

            var validationMessages = new List<string>();

            var list = sponsorshipCashs as IList<SponsorshipCashEntity> ?? sponsorshipCashs.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipCashEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipCashRepository.Set(list);
        }

        public void SetSponsorshipCash(SponsorshipCashEntity sponsorshipCash)
        {
            if (sponsorshipCash == null) throw new ArgumentNullException(nameof(sponsorshipCash));

            var validationMessages = new List<string>();

            var messages = _sponsorshipCashEntityValidator.Validate(sponsorshipCash);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipCashRepository.SetById(sponsorshipCash);
        }

        public IEnumerable<SponsorshipContractTeam01Entity> GetSponsorshipContractsTeam01()
        {
            return _sponsorshipContractTeam01Repository.Get();
        }

        public void SetSponsorshipContractsTeam01(IEnumerable<SponsorshipContractTeam01Entity> sponsorshipContracts)
        {
            if (sponsorshipContracts == null) throw new ArgumentNullException(nameof(sponsorshipContracts));

            var validationMessages = new List<string>();

            var list = sponsorshipContracts as IList<SponsorshipContractTeam01Entity> ?? sponsorshipContracts.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipContractTeam01EntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam01Repository.Set(list);
        }

        public void SetSponsorshipContractTeam01(SponsorshipContractTeam01Entity sponsorshipContract)
        {
            if (sponsorshipContract == null) throw new ArgumentNullException(nameof(sponsorshipContract));

            var validationMessages = new List<string>();

            var messages = _sponsorshipContractTeam01EntityValidator.Validate(sponsorshipContract);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam01Repository.SetById(sponsorshipContract);
        }

        public IEnumerable<SponsorshipContractTeam02Entity> GetSponsorshipContractsTeam02()
        {
            return _sponsorshipContractTeam02Repository.Get();
        }

        public void SetSponsorshipContractsTeam02(IEnumerable<SponsorshipContractTeam02Entity> sponsorshipContracts)
        {
            if (sponsorshipContracts == null) throw new ArgumentNullException(nameof(sponsorshipContracts));

            var validationMessages = new List<string>();

            var list = sponsorshipContracts as IList<SponsorshipContractTeam02Entity> ?? sponsorshipContracts.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipContractTeam02EntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam02Repository.Set(list);
        }

        public void SetSponsorshipContractTeam02(SponsorshipContractTeam02Entity sponsorshipContract)
        {
            if (sponsorshipContract == null) throw new ArgumentNullException(nameof(sponsorshipContract));

            var validationMessages = new List<string>();

            var messages = _sponsorshipContractTeam02EntityValidator.Validate(sponsorshipContract);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam02Repository.SetById(sponsorshipContract);
        }

        public IEnumerable<SponsorshipContractTeam03Entity> GetSponsorshipContractsTeam03()
        {
            return _sponsorshipContractTeam03Repository.Get();
        }

        public void SetSponsorshipContractsTeam03(IEnumerable<SponsorshipContractTeam03Entity> sponsorshipContracts)
        {
            if (sponsorshipContracts == null) throw new ArgumentNullException(nameof(sponsorshipContracts));

            var validationMessages = new List<string>();

            var list = sponsorshipContracts as IList<SponsorshipContractTeam03Entity> ?? sponsorshipContracts.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipContractTeam03EntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam03Repository.Set(list);
        }

        public void SetSponsorshipContractTeam03(SponsorshipContractTeam03Entity sponsorshipContract)
        {
            if (sponsorshipContract == null) throw new ArgumentNullException(nameof(sponsorshipContract));

            var validationMessages = new List<string>();

            var messages = _sponsorshipContractTeam03EntityValidator.Validate(sponsorshipContract);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam03Repository.SetById(sponsorshipContract);
        }

        public IEnumerable<SponsorshipContractTeam04Entity> GetSponsorshipContractsTeam04()
        {
            return _sponsorshipContractTeam04Repository.Get();
        }

        public void SetSponsorshipContractsTeam04(IEnumerable<SponsorshipContractTeam04Entity> sponsorshipContracts)
        {
            if (sponsorshipContracts == null) throw new ArgumentNullException(nameof(sponsorshipContracts));

            var validationMessages = new List<string>();

            var list = sponsorshipContracts as IList<SponsorshipContractTeam04Entity> ?? sponsorshipContracts.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipContractTeam04EntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam04Repository.Set(list);
        }

        public void SetSponsorshipContractTeam04(SponsorshipContractTeam04Entity sponsorshipContract)
        {
            if (sponsorshipContract == null) throw new ArgumentNullException(nameof(sponsorshipContract));

            var validationMessages = new List<string>();

            var messages = _sponsorshipContractTeam04EntityValidator.Validate(sponsorshipContract);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam04Repository.SetById(sponsorshipContract);
        }

        public IEnumerable<SponsorshipContractTeam05Entity> GetSponsorshipContractsTeam05()
        {
            return _sponsorshipContractTeam05Repository.Get();
        }

        public void SetSponsorshipContractsTeam05(IEnumerable<SponsorshipContractTeam05Entity> sponsorshipContracts)
        {
            if (sponsorshipContracts == null) throw new ArgumentNullException(nameof(sponsorshipContracts));

            var validationMessages = new List<string>();

            var list = sponsorshipContracts as IList<SponsorshipContractTeam05Entity> ?? sponsorshipContracts.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipContractTeam05EntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam05Repository.Set(list);
        }

        public void SetSponsorshipContractTeam05(SponsorshipContractTeam05Entity sponsorshipContract)
        {
            if (sponsorshipContract == null) throw new ArgumentNullException(nameof(sponsorshipContract));

            var validationMessages = new List<string>();

            var messages = _sponsorshipContractTeam05EntityValidator.Validate(sponsorshipContract);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam05Repository.SetById(sponsorshipContract);
        }

        public IEnumerable<SponsorshipContractTeam06Entity> GetSponsorshipContractsTeam06()
        {
            return _sponsorshipContractTeam06Repository.Get();
        }

        public void SetSponsorshipContractsTeam06(IEnumerable<SponsorshipContractTeam06Entity> sponsorshipContracts)
        {
            if (sponsorshipContracts == null) throw new ArgumentNullException(nameof(sponsorshipContracts));

            var validationMessages = new List<string>();

            var list = sponsorshipContracts as IList<SponsorshipContractTeam06Entity> ?? sponsorshipContracts.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipContractTeam06EntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam06Repository.Set(list);
        }

        public void SetSponsorshipContractTeam06(SponsorshipContractTeam06Entity sponsorshipContract)
        {
            if (sponsorshipContract == null) throw new ArgumentNullException(nameof(sponsorshipContract));

            var validationMessages = new List<string>();

            var messages = _sponsorshipContractTeam06EntityValidator.Validate(sponsorshipContract);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam06Repository.SetById(sponsorshipContract);
        }

        public IEnumerable<SponsorshipContractTeam07Entity> GetSponsorshipContractsTeam07()
        {
            return _sponsorshipContractTeam07Repository.Get();
        }

        public void SetSponsorshipContractsTeam07(IEnumerable<SponsorshipContractTeam07Entity> sponsorshipContracts)
        {
            if (sponsorshipContracts == null) throw new ArgumentNullException(nameof(sponsorshipContracts));

            var validationMessages = new List<string>();

            var list = sponsorshipContracts as IList<SponsorshipContractTeam07Entity> ?? sponsorshipContracts.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipContractTeam07EntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam07Repository.Set(list);
        }

        public void SetSponsorshipContractTeam07(SponsorshipContractTeam07Entity sponsorshipContract)
        {
            if (sponsorshipContract == null) throw new ArgumentNullException(nameof(sponsorshipContract));

            var validationMessages = new List<string>();

            var messages = _sponsorshipContractTeam07EntityValidator.Validate(sponsorshipContract);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam07Repository.SetById(sponsorshipContract);
        }

        public IEnumerable<SponsorshipContractTeam08Entity> GetSponsorshipContractsTeam08()
        {
            return _sponsorshipContractTeam08Repository.Get();
        }

        public void SetSponsorshipContractsTeam08(IEnumerable<SponsorshipContractTeam08Entity> sponsorshipContracts)
        {
            if (sponsorshipContracts == null) throw new ArgumentNullException(nameof(sponsorshipContracts));

            var validationMessages = new List<string>();

            var list = sponsorshipContracts as IList<SponsorshipContractTeam08Entity> ?? sponsorshipContracts.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipContractTeam08EntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam08Repository.Set(list);
        }

        public void SetSponsorshipContractTeam08(SponsorshipContractTeam08Entity sponsorshipContract)
        {
            if (sponsorshipContract == null) throw new ArgumentNullException(nameof(sponsorshipContract));

            var validationMessages = new List<string>();

            var messages = _sponsorshipContractTeam08EntityValidator.Validate(sponsorshipContract);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam08Repository.SetById(sponsorshipContract);
        }

        public IEnumerable<SponsorshipContractTeam09Entity> GetSponsorshipContractsTeam09()
        {
            return _sponsorshipContractTeam09Repository.Get();
        }

        public void SetSponsorshipContractsTeam09(IEnumerable<SponsorshipContractTeam09Entity> sponsorshipContracts)
        {
            if (sponsorshipContracts == null) throw new ArgumentNullException(nameof(sponsorshipContracts));

            var validationMessages = new List<string>();

            var list = sponsorshipContracts as IList<SponsorshipContractTeam09Entity> ?? sponsorshipContracts.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipContractTeam09EntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam09Repository.Set(list);
        }

        public void SetSponsorshipContractTeam09(SponsorshipContractTeam09Entity sponsorshipContract)
        {
            if (sponsorshipContract == null) throw new ArgumentNullException(nameof(sponsorshipContract));

            var validationMessages = new List<string>();

            var messages = _sponsorshipContractTeam09EntityValidator.Validate(sponsorshipContract);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam09Repository.SetById(sponsorshipContract);
        }

        public IEnumerable<SponsorshipContractTeam10Entity> GetSponsorshipContractsTeam10()
        {
            return _sponsorshipContractTeam10Repository.Get();
        }

        public void SetSponsorshipContractsTeam10(IEnumerable<SponsorshipContractTeam10Entity> sponsorshipContracts)
        {
            if (sponsorshipContracts == null) throw new ArgumentNullException(nameof(sponsorshipContracts));

            var validationMessages = new List<string>();

            var list = sponsorshipContracts as IList<SponsorshipContractTeam10Entity> ?? sponsorshipContracts.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipContractTeam10EntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam10Repository.Set(list);
        }

        public void SetSponsorshipContractTeam10(SponsorshipContractTeam10Entity sponsorshipContract)
        {
            if (sponsorshipContract == null) throw new ArgumentNullException(nameof(sponsorshipContract));

            var validationMessages = new List<string>();

            var messages = _sponsorshipContractTeam10EntityValidator.Validate(sponsorshipContract);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam10Repository.SetById(sponsorshipContract);
        }

        public IEnumerable<SponsorshipContractTeam11Entity> GetSponsorshipContractsTeam11()
        {
            return _sponsorshipContractTeam11Repository.Get();
        }

        public void SetSponsorshipContractsTeam11(IEnumerable<SponsorshipContractTeam11Entity> sponsorshipContracts)
        {
            if (sponsorshipContracts == null) throw new ArgumentNullException(nameof(sponsorshipContracts));

            var validationMessages = new List<string>();

            var list = sponsorshipContracts as IList<SponsorshipContractTeam11Entity> ?? sponsorshipContracts.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorshipContractTeam11EntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam11Repository.Set(list);
        }

        public void SetSponsorshipContractTeam11(SponsorshipContractTeam11Entity sponsorshipContract)
        {
            if (sponsorshipContract == null) throw new ArgumentNullException(nameof(sponsorshipContract));

            var validationMessages = new List<string>();

            var messages = _sponsorshipContractTeam11EntityValidator.Validate(sponsorshipContract);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorshipContractTeam11Repository.SetById(sponsorshipContract);
        }
    }
}