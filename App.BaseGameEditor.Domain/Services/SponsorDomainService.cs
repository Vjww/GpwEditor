using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Entities;
using App.Core.Repositories;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.Services
{
    public class SponsorDomainService
    {
        private readonly IRepository<SponsorEntity> _sponsorRepository;
        private readonly IEntityValidator<SponsorEntity> _sponsorEntityValidator;
        private readonly IRepository<SponsorContractEntity> _sponsorContractRepository;
        private readonly IEntityValidator<SponsorContractEntity> _sponsorContractEntityValidator;

        public SponsorDomainService(
            IRepository<SponsorEntity> sponsorRepository,
            IEntityValidator<SponsorEntity> sponsorEntityValidator,
            IRepository<SponsorContractEntity> sponsorContractRepository,
            IEntityValidator<SponsorContractEntity> sponsorContractEntityValidator)
        {
            _sponsorRepository = sponsorRepository ?? throw new ArgumentNullException(nameof(sponsorRepository));
            _sponsorEntityValidator = sponsorEntityValidator ?? throw new ArgumentNullException(nameof(sponsorEntityValidator));
            _sponsorContractRepository = sponsorContractRepository ?? throw new ArgumentNullException(nameof(sponsorContractRepository));
            _sponsorContractEntityValidator = sponsorContractEntityValidator ?? throw new ArgumentNullException(nameof(sponsorContractEntityValidator));
        }

        public IEnumerable<SponsorEntity> GetSponsors()
        {
            return _sponsorRepository.Get();
        }

        public IEnumerable<SponsorEntity> GetSponsorsBySponsorTypeId(int id)
        {
            return _sponsorRepository.Get(x => x.SponsorTypeId == id).ToList();
        }

        public void SetSponsors(IEnumerable<SponsorEntity> sponsors)
        {
            if (sponsors == null) throw new ArgumentNullException(nameof(sponsors));

            var validationMessages = new List<string>();

            var list = sponsors as IList<SponsorEntity> ?? sponsors.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorRepository.Set(list);
        }

        public void SetSponsorsBySponsorTypeId(int id, IEnumerable<SponsorEntity> sponsors)
        {
            if (sponsors == null) throw new ArgumentNullException(nameof(sponsors));

            var validationMessages = new List<string>();

            var list = sponsors as IList<SponsorEntity> ?? sponsors.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            foreach (var item in list)
            {
                _sponsorRepository.SetById(item);
            }
        }

        public void SetSponsor(SponsorEntity sponsor)
        {
            if (sponsor == null) throw new ArgumentNullException(nameof(sponsor));

            var validationMessages = new List<string>();

            var messages = _sponsorEntityValidator.Validate(sponsor);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorRepository.SetById(sponsor);
        }

        public IEnumerable<SponsorContractEntity> GetSponsorContracts()
        {
            return _sponsorContractRepository.Get();
        }

        public IEnumerable<SponsorContractEntity> GetSponsorContractsByTeamId(int id)
        {
            return _sponsorContractRepository.Get(x => x.TeamId == id).ToList();
        }

        public void SetSponsorContracts(IEnumerable<SponsorContractEntity> sponsorContracts)
        {
            if (sponsorContracts == null) throw new ArgumentNullException(nameof(sponsorContracts));

            var validationMessages = new List<string>();

            var list = sponsorContracts as IList<SponsorContractEntity> ?? sponsorContracts.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorContractEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _sponsorContractRepository.Set(list);
        }

        public void SetSponsorContractsByTeamId(int id, IEnumerable<SponsorContractEntity> sponsorContracts)
        {
            if (sponsorContracts == null) throw new ArgumentNullException(nameof(sponsorContracts));

            var validationMessages = new List<string>();

            var list = sponsorContracts as IList<SponsorContractEntity> ?? sponsorContracts.ToList();
            foreach (var item in list)
            {
                var messages = _sponsorContractEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            foreach (var item in list)
            {
                _sponsorContractRepository.SetById(item);
            }
        }

        public void SetSponsorContract(SponsorContractEntity sponsorContract)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SponsorEntity> GetSponsorTeams()
        {
            return GetSponsorsBySponsorTypeId(1); // TODO: Use Enum for SponsorTypeId
        }

        public void SetSponsorTeams(IEnumerable<SponsorEntity> sponsors)
        {
            SetSponsorsBySponsorTypeId(1, sponsors);
        }

        public IEnumerable<SponsorEntity> GetSponsorEngines()
        {
            return GetSponsorsBySponsorTypeId(2); // TODO: Use Enum for SponsorTypeId
        }

        public void SetSponsorEngines(IEnumerable<SponsorEntity> sponsors)
        {
            SetSponsorsBySponsorTypeId(2, sponsors);
        }

        public IEnumerable<SponsorEntity> GetSponsorTyres()
        {
            return GetSponsorsBySponsorTypeId(3); // TODO: Use Enum for SponsorTypeId
        }

        public void SetSponsorTyres(IEnumerable<SponsorEntity> sponsors)
        {
            SetSponsorsBySponsorTypeId(3, sponsors);
        }

        public IEnumerable<SponsorEntity> GetSponsorFuels()
        {
            return GetSponsorsBySponsorTypeId(4); // TODO: Use Enum for SponsorTypeId
        }

        public void SetSponsorFuels(IEnumerable<SponsorEntity> sponsors)
        {
            SetSponsorsBySponsorTypeId(4, sponsors);
        }

        public IEnumerable<SponsorEntity> GetSponsorCashs()
        {
            return GetSponsorsBySponsorTypeId(5); // TODO: Use Enum for SponsorTypeId
        }

        public void SetSponsorCashs(IEnumerable<SponsorEntity> sponsors)
        {
            SetSponsorsBySponsorTypeId(5, sponsors);
        }

        public IEnumerable<SponsorContractEntity> GetSponsorContractsTeam01()
        {
            return GetSponsorContractsByTeamId(1);
        }

        public void SetSponsorContractsTeam01(IEnumerable<SponsorContractEntity> sponsorContracts)
        {
            SetSponsorContractsByTeamId(1, sponsorContracts);
        }

        public IEnumerable<SponsorContractEntity> GetSponsorContractsTeam02()
        {
            return GetSponsorContractsByTeamId(2);
        }

        public void SetSponsorContractsTeam02(IEnumerable<SponsorContractEntity> sponsorContracts)
        {
            SetSponsorContractsByTeamId(2, sponsorContracts);
        }

        public IEnumerable<SponsorContractEntity> GetSponsorContractsTeam03()
        {
            return GetSponsorContractsByTeamId(3);
        }

        public void SetSponsorContractsTeam03(IEnumerable<SponsorContractEntity> sponsorContracts)
        {
            SetSponsorContractsByTeamId(3, sponsorContracts);
        }

        public IEnumerable<SponsorContractEntity> GetSponsorContractsTeam04()
        {
            return GetSponsorContractsByTeamId(4);
        }

        public void SetSponsorContractsTeam04(IEnumerable<SponsorContractEntity> sponsorContracts)
        {
            SetSponsorContractsByTeamId(4, sponsorContracts);
        }

        public IEnumerable<SponsorContractEntity> GetSponsorContractsTeam05()
        {
            return GetSponsorContractsByTeamId(5);
        }

        public void SetSponsorContractsTeam05(IEnumerable<SponsorContractEntity> sponsorContracts)
        {
            SetSponsorContractsByTeamId(5, sponsorContracts);
        }

        public IEnumerable<SponsorContractEntity> GetSponsorContractsTeam06()
        {
            return GetSponsorContractsByTeamId(6);
        }

        public void SetSponsorContractsTeam06(IEnumerable<SponsorContractEntity> sponsorContracts)
        {
            SetSponsorContractsByTeamId(6, sponsorContracts);
        }

        public IEnumerable<SponsorContractEntity> GetSponsorContractsTeam07()
        {
            return GetSponsorContractsByTeamId(7);
        }

        public void SetSponsorContractsTeam07(IEnumerable<SponsorContractEntity> sponsorContracts)
        {
            SetSponsorContractsByTeamId(7, sponsorContracts);
        }

        public IEnumerable<SponsorContractEntity> GetSponsorContractsTeam08()
        {
            return GetSponsorContractsByTeamId(8);
        }

        public void SetSponsorContractsTeam08(IEnumerable<SponsorContractEntity> sponsorContracts)
        {
            SetSponsorContractsByTeamId(8, sponsorContracts);
        }

        public IEnumerable<SponsorContractEntity> GetSponsorContractsTeam09()
        {
            return GetSponsorContractsByTeamId(9);
        }

        public void SetSponsorContractsTeam09(IEnumerable<SponsorContractEntity> sponsorContracts)
        {
            SetSponsorContractsByTeamId(9, sponsorContracts);
        }

        public IEnumerable<SponsorContractEntity> GetSponsorContractsTeam10()
        {
            return GetSponsorContractsByTeamId(10);
        }

        public void SetSponsorContractsTeam10(IEnumerable<SponsorContractEntity> sponsorContracts)
        {
            SetSponsorContractsByTeamId(10, sponsorContracts);
        }

        public IEnumerable<SponsorContractEntity> GetSponsorContractsTeam11()
        {
            return GetSponsorContractsByTeamId(11);
        }

        public void SetSponsorContractsTeam11(IEnumerable<SponsorContractEntity> sponsorContracts)
        {
            SetSponsorContractsByTeamId(11, sponsorContracts);
        }
    }
}