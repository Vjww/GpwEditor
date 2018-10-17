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

        public SponsorshipDomainService(
            IRepository<SponsorshipTeamEntity> sponsorshipTeamRepository,
            IEntityValidator<SponsorshipTeamEntity> sponsorshipTeamEntityValidator,
            IRepository<SponsorshipEngineEntity> sponsorshipEngineRepository,
            IEntityValidator<SponsorshipEngineEntity> sponsorshipEngineEntityValidator,
            IRepository<SponsorshipTyreEntity> sponsorshipTyreRepository,
            IEntityValidator<SponsorshipTyreEntity> sponsorshipTyreEntityValidator,
            IRepository<SponsorshipFuelEntity> sponsorshipFuelRepository,
            IEntityValidator<SponsorshipFuelEntity> sponsorshipFuelEntityValidator,
            IRepository<SponsorshipCashEntity> sponsorshipCashRepository,
            IEntityValidator<SponsorshipCashEntity> sponsorshipCashEntityValidator)
        {
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
        }

        public IEnumerable<SponsorshipTeamEntity> GetSponsorshipTeams()
        {
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
    }
}