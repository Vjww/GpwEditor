using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Entities.Lookups;
using App.BaseGameEditor.Domain.EntityValidators;
using App.Core.Repositories;

namespace App.BaseGameEditor.Domain.Services
{
    public class LookupDomainService
    {
        private readonly IRepository<ChiefDriverLoyaltyLookupEntity> _chiefDriverLoyaltyLookupRepository;
        private readonly IEntityValidator<ChiefDriverLoyaltyLookupEntity> _chiefDriverLoyaltyLookupEntityValidator;
        private readonly IRepository<DriverNationalityLookupEntity> _driverNationalityLookupRepository;
        private readonly IEntityValidator<DriverNationalityLookupEntity> _driverNationalityLookupEntityValidator;
        private readonly IRepository<DriverRoleLookupEntity> _driverRoleLookupRepository;
        private readonly IEntityValidator<DriverRoleLookupEntity> _driverRoleLookupEntityValidator;
        private readonly IRepository<TeamDebutGrandPrixLookupEntity> _teamDebutGrandPrixLookupRepository;
        private readonly IEntityValidator<TeamDebutGrandPrixLookupEntity> _teamDebutGrandPrixLookupEntityValidator;
        private readonly IRepository<TrackDriverLookupEntity> _trackDriverLookupRepository;
        private readonly IEntityValidator<TrackDriverLookupEntity> _trackDriverLookupEntityValidator;
        private readonly IRepository<TrackLayoutLookupEntity> _trackLayoutLookupEntityRepository;
        private readonly IEntityValidator<TrackLayoutLookupEntity> _trackLayoutLookupEntityValidator;
        private readonly IRepository<TrackTeamLookupEntity> _trackTeamLookupRepository;
        private readonly IEntityValidator<TrackTeamLookupEntity> _trackTeamLookupEntityValidator;
        private readonly IRepository<TyreSupplierLookupEntity> _tyreSupplierLookupRepository;
        private readonly IEntityValidator<TyreSupplierLookupEntity> _tyreSupplierLookupEntityValidator;

        public LookupDomainService(
            IRepository<ChiefDriverLoyaltyLookupEntity> chiefDriverLoyaltyLookupRepository,
            IEntityValidator<ChiefDriverLoyaltyLookupEntity> chiefDriverLoyaltyLookupEntityValidator,
            IRepository<DriverNationalityLookupEntity> driverNationalityLookupRepository,
            IEntityValidator<DriverNationalityLookupEntity> driverNationalityLookupEntityValidator,
            IRepository<DriverRoleLookupEntity> driverRoleLookupRepository,
            IEntityValidator<DriverRoleLookupEntity> driverRoleLookupEntityValidator,
            IRepository<TeamDebutGrandPrixLookupEntity> teamDebutGrandPrixLookupRepository,
            IEntityValidator<TeamDebutGrandPrixLookupEntity> teamDebutGrandPrixLookupEntityValidator,
            IRepository<TrackDriverLookupEntity> trackDriverLookupRepository,
            IEntityValidator<TrackDriverLookupEntity> trackDriverLookupEntityValidator,
            IRepository<TrackLayoutLookupEntity> trackLayoutLookupEntityRepository,
            IEntityValidator<TrackLayoutLookupEntity> trackLayoutLookupEntityValidator,
            IRepository<TrackTeamLookupEntity> trackTeamLookupRepository,
            IEntityValidator<TrackTeamLookupEntity> trackTeamLookupEntityValidator,
            IRepository<TyreSupplierLookupEntity> tyreSupplierLookupRepository,
            IEntityValidator<TyreSupplierLookupEntity> tyreSupplierLookupEntityValidator)
        {
            _chiefDriverLoyaltyLookupRepository = chiefDriverLoyaltyLookupRepository ?? throw new ArgumentNullException(nameof(chiefDriverLoyaltyLookupRepository));
            _chiefDriverLoyaltyLookupEntityValidator = chiefDriverLoyaltyLookupEntityValidator ?? throw new ArgumentNullException(nameof(chiefDriverLoyaltyLookupEntityValidator));
            _driverNationalityLookupRepository = driverNationalityLookupRepository ?? throw new ArgumentNullException(nameof(driverNationalityLookupRepository));
            _driverNationalityLookupEntityValidator = driverNationalityLookupEntityValidator ?? throw new ArgumentNullException(nameof(driverNationalityLookupEntityValidator));
            _driverRoleLookupRepository = driverRoleLookupRepository ?? throw new ArgumentNullException(nameof(driverRoleLookupRepository));
            _driverRoleLookupEntityValidator = driverRoleLookupEntityValidator ?? throw new ArgumentNullException(nameof(driverRoleLookupEntityValidator));
            _teamDebutGrandPrixLookupRepository = teamDebutGrandPrixLookupRepository ?? throw new ArgumentNullException(nameof(teamDebutGrandPrixLookupRepository));
            _teamDebutGrandPrixLookupEntityValidator = teamDebutGrandPrixLookupEntityValidator ?? throw new ArgumentNullException(nameof(teamDebutGrandPrixLookupEntityValidator));
            _trackDriverLookupRepository = trackDriverLookupRepository ?? throw new ArgumentNullException(nameof(trackDriverLookupRepository));
            _trackDriverLookupEntityValidator = trackDriverLookupEntityValidator ?? throw new ArgumentNullException(nameof(trackDriverLookupEntityValidator));
            _trackLayoutLookupEntityRepository = trackLayoutLookupEntityRepository ?? throw new ArgumentNullException(nameof(trackLayoutLookupEntityRepository));
            _trackLayoutLookupEntityValidator = trackLayoutLookupEntityValidator ?? throw new ArgumentNullException(nameof(trackLayoutLookupEntityValidator));
            _trackTeamLookupRepository = trackTeamLookupRepository ?? throw new ArgumentNullException(nameof(trackTeamLookupRepository));
            _trackTeamLookupEntityValidator = trackTeamLookupEntityValidator ?? throw new ArgumentNullException(nameof(trackTeamLookupEntityValidator));
            _tyreSupplierLookupRepository = tyreSupplierLookupRepository ?? throw new ArgumentNullException(nameof(tyreSupplierLookupRepository));
            _tyreSupplierLookupEntityValidator = tyreSupplierLookupEntityValidator ?? throw new ArgumentNullException(nameof(tyreSupplierLookupEntityValidator));
        }

        public IEnumerable<ChiefDriverLoyaltyLookupEntity> GetChiefDriverLoyaltyLookups()
        {
            return _chiefDriverLoyaltyLookupRepository.Get();
        }

        public void SetChiefDriverLoyaltyLookups(IEnumerable<ChiefDriverLoyaltyLookupEntity> chiefDriverLoyaltyLookups)
        {
            if (chiefDriverLoyaltyLookups == null) throw new ArgumentNullException(nameof(chiefDriverLoyaltyLookups));

            var validationMessages = new List<string>();

            var list = chiefDriverLoyaltyLookups as IList<ChiefDriverLoyaltyLookupEntity> ?? chiefDriverLoyaltyLookups.ToList();
            foreach (var item in list)
            {
                var messages = _chiefDriverLoyaltyLookupEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _chiefDriverLoyaltyLookupRepository.Set(list);
        }

        public void SetChiefDriverLoyaltyLookup(ChiefDriverLoyaltyLookupEntity chiefDriverLoyaltyLookup)
        {
            if (chiefDriverLoyaltyLookup == null) throw new ArgumentNullException(nameof(chiefDriverLoyaltyLookup));

            var validationMessages = new List<string>();

            var messages = _chiefDriverLoyaltyLookupEntityValidator.Validate(chiefDriverLoyaltyLookup);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _chiefDriverLoyaltyLookupRepository.SetById(chiefDriverLoyaltyLookup);
        }

        public IEnumerable<DriverNationalityLookupEntity> GetDriverNationalityLookups()
        {
            return _driverNationalityLookupRepository.Get();
        }

        public void SetDriverNationalityLookups(IEnumerable<DriverNationalityLookupEntity> driverNationalityLookups)
        {
            if (driverNationalityLookups == null) throw new ArgumentNullException(nameof(driverNationalityLookups));

            var validationMessages = new List<string>();

            var list = driverNationalityLookups as IList<DriverNationalityLookupEntity> ?? driverNationalityLookups.ToList();
            foreach (var item in list)
            {
                var messages = _driverNationalityLookupEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _driverNationalityLookupRepository.Set(list);
        }

        public void SetDriverNationalityLookup(DriverNationalityLookupEntity driverNationalityLookup)
        {
            if (driverNationalityLookup == null) throw new ArgumentNullException(nameof(driverNationalityLookup));

            var validationMessages = new List<string>();

            var messages = _driverNationalityLookupEntityValidator.Validate(driverNationalityLookup);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _driverNationalityLookupRepository.SetById(driverNationalityLookup);
        }

        public IEnumerable<DriverRoleLookupEntity> GetDriverRoleLookups()
        {
            return _driverRoleLookupRepository.Get();
        }

        public void SetDriverRoleLookups(IEnumerable<DriverRoleLookupEntity> driverRoleLookups)
        {
            if (driverRoleLookups == null) throw new ArgumentNullException(nameof(driverRoleLookups));

            var validationMessages = new List<string>();

            var list = driverRoleLookups as IList<DriverRoleLookupEntity> ?? driverRoleLookups.ToList();
            foreach (var item in list)
            {
                var messages = _driverRoleLookupEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _driverRoleLookupRepository.Set(list);
        }

        public void SetDriverRoleLookup(DriverRoleLookupEntity driverRoleLookup)
        {
            if (driverRoleLookup == null) throw new ArgumentNullException(nameof(driverRoleLookup));

            var validationMessages = new List<string>();

            var messages = _driverRoleLookupEntityValidator.Validate(driverRoleLookup);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _driverRoleLookupRepository.SetById(driverRoleLookup);
        }

        public IEnumerable<TeamDebutGrandPrixLookupEntity> GetTeamDebutGrandPrixLookups()
        {
            return _teamDebutGrandPrixLookupRepository.Get();
        }

        public void SetTeamDebutGrandPrixLookups(IEnumerable<TeamDebutGrandPrixLookupEntity> teamDebutGrandPrixLookups)
        {
            if (teamDebutGrandPrixLookups == null) throw new ArgumentNullException(nameof(teamDebutGrandPrixLookups));

            var validationMessages = new List<string>();

            var list = teamDebutGrandPrixLookups as IList<TeamDebutGrandPrixLookupEntity> ?? teamDebutGrandPrixLookups.ToList();
            foreach (var item in list)
            {
                var messages = _teamDebutGrandPrixLookupEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _teamDebutGrandPrixLookupRepository.Set(list);
        }

        public void SetTeamDebutGrandPrixLookup(TeamDebutGrandPrixLookupEntity teamDebutGrandPrixLookup)
        {
            if (teamDebutGrandPrixLookup == null) throw new ArgumentNullException(nameof(teamDebutGrandPrixLookup));

            var validationMessages = new List<string>();

            var messages = _teamDebutGrandPrixLookupEntityValidator.Validate(teamDebutGrandPrixLookup);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _teamDebutGrandPrixLookupRepository.SetById(teamDebutGrandPrixLookup);
        }

        public IEnumerable<TrackDriverLookupEntity> GetTrackDriverLookups()
        {
            return _trackDriverLookupRepository.Get();
        }

        public void SetTrackDriverLookups(IEnumerable<TrackDriverLookupEntity> trackDriverLookups)
        {
            if (trackDriverLookups == null) throw new ArgumentNullException(nameof(trackDriverLookups));

            var validationMessages = new List<string>();

            var list = trackDriverLookups as IList<TrackDriverLookupEntity> ?? trackDriverLookups.ToList();
            foreach (var item in list)
            {
                var messages = _trackDriverLookupEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _trackDriverLookupRepository.Set(list);
        }

        public void SetTrackDriverLookup(TrackDriverLookupEntity trackDriverLookup)
        {
            if (trackDriverLookup == null) throw new ArgumentNullException(nameof(trackDriverLookup));

            var validationMessages = new List<string>();

            var messages = _trackDriverLookupEntityValidator.Validate(trackDriverLookup);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _trackDriverLookupRepository.SetById(trackDriverLookup);
        }

        public IEnumerable<TrackLayoutLookupEntity> GetTrackLayoutLookups()
        {
            return _trackLayoutLookupEntityRepository.Get();
        }

        public void SetTrackLayoutLookups(IEnumerable<TrackLayoutLookupEntity> trackLayoutLookups)
        {
            if (trackLayoutLookups == null) throw new ArgumentNullException(nameof(trackLayoutLookups));

            var validationMessages = new List<string>();

            var list = trackLayoutLookups as IList<TrackLayoutLookupEntity> ?? trackLayoutLookups.ToList();
            foreach (var item in list)
            {
                var messages = _trackLayoutLookupEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _trackLayoutLookupEntityRepository.Set(list);
        }

        public void SetTrackLayoutLookup(TrackLayoutLookupEntity trackLayoutLookup)
        {
            if (trackLayoutLookup == null) throw new ArgumentNullException(nameof(trackLayoutLookup));

            var validationMessages = new List<string>();

            var messages = _trackLayoutLookupEntityValidator.Validate(trackLayoutLookup);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _trackLayoutLookupEntityRepository.SetById(trackLayoutLookup);
        }

        public IEnumerable<TrackTeamLookupEntity> GetTrackTeamLookups()
        {
            return _trackTeamLookupRepository.Get();
        }

        public void SetTrackTeamLookups(IEnumerable<TrackTeamLookupEntity> trackTeamLookups)
        {
            if (trackTeamLookups == null) throw new ArgumentNullException(nameof(trackTeamLookups));

            var validationMessages = new List<string>();

            var list = trackTeamLookups as IList<TrackTeamLookupEntity> ?? trackTeamLookups.ToList();
            foreach (var item in list)
            {
                var messages = _trackTeamLookupEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _trackTeamLookupRepository.Set(list);
        }

        public void SetTrackTeamLookup(TrackTeamLookupEntity trackTeamLookup)
        {
            if (trackTeamLookup == null) throw new ArgumentNullException(nameof(trackTeamLookup));

            var validationMessages = new List<string>();

            var messages = _trackTeamLookupEntityValidator.Validate(trackTeamLookup);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _trackTeamLookupRepository.SetById(trackTeamLookup);
        }

        public IEnumerable<TyreSupplierLookupEntity> GetTyreSupplierLookups()
        {
            return _tyreSupplierLookupRepository.Get();
        }

        public void SetTyreSupplierLookups(IEnumerable<TyreSupplierLookupEntity> tyreSupplierLookups)
        {
            if (tyreSupplierLookups == null) throw new ArgumentNullException(nameof(tyreSupplierLookups));

            var validationMessages = new List<string>();

            var list = tyreSupplierLookups as IList<TyreSupplierLookupEntity> ?? tyreSupplierLookups.ToList();
            foreach (var item in list)
            {
                var messages = _tyreSupplierLookupEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _tyreSupplierLookupRepository.Set(list);
        }

        public void SetTyreSupplierLookup(TyreSupplierLookupEntity tyreSupplierLookup)
        {
            if (tyreSupplierLookup == null) throw new ArgumentNullException(nameof(tyreSupplierLookup));

            var validationMessages = new List<string>();

            var messages = _tyreSupplierLookupEntityValidator.Validate(tyreSupplierLookup);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _tyreSupplierLookupRepository.SetById(tyreSupplierLookup);
        }
    }
}