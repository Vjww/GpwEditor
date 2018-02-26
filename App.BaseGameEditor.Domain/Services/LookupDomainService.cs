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
        private readonly IRepository<TeamDebutGrandPrixLookupEntity> _teamDebutGrandPrixLookupRepository;
        private readonly IEntityValidator<TeamDebutGrandPrixLookupEntity> _teamDebutGrandPrixLookupEntityValidator;
        private readonly IRepository<TrackFastestLapDriverLookupEntity> _trackFastestLapDriverLookupRepository;
        private readonly IEntityValidator<TrackFastestLapDriverLookupEntity> _trackFastestLapDriverLookupEntityValidator;
        private readonly IRepository<TrackLayoutLookupEntity> _trackLayoutLookupEntityRepository;
        private readonly IEntityValidator<TrackLayoutLookupEntity> _trackLayoutLookupEntityValidator;
        private readonly IRepository<TyreSupplierLookupEntity> _tyreSupplierLookupRepository;
        private readonly IEntityValidator<TyreSupplierLookupEntity> _tyreSupplierLookupEntityValidator;

        public LookupDomainService(
            IRepository<ChiefDriverLoyaltyLookupEntity> chiefDriverLoyaltyLookupRepository,
            IEntityValidator<ChiefDriverLoyaltyLookupEntity> chiefDriverLoyaltyLookupEntityValidator,
            IRepository<DriverNationalityLookupEntity> driverNationalityLookupRepository,
            IEntityValidator<DriverNationalityLookupEntity> driverNationalityLookupEntityValidator,
            IRepository<TeamDebutGrandPrixLookupEntity> teamDebutGrandPrixLookupRepository,
            IEntityValidator<TeamDebutGrandPrixLookupEntity> teamDebutGrandPrixLookupEntityValidator,
            IRepository<TrackFastestLapDriverLookupEntity> trackFastestLapDriverLookupRepository,
            IEntityValidator<TrackFastestLapDriverLookupEntity> trackFastestLapDriverLookupEntityValidator,
            IRepository<TrackLayoutLookupEntity> trackLayoutLookupEntityRepository,
            IEntityValidator<TrackLayoutLookupEntity> trackLayoutLookupEntityValidator,
            IRepository<TyreSupplierLookupEntity> tyreSupplierLookupRepository,
            IEntityValidator<TyreSupplierLookupEntity> tyreSupplierLookupEntityValidator)
        {
            _chiefDriverLoyaltyLookupRepository = chiefDriverLoyaltyLookupRepository ?? throw new ArgumentNullException(nameof(chiefDriverLoyaltyLookupRepository));
            _chiefDriverLoyaltyLookupEntityValidator = chiefDriverLoyaltyLookupEntityValidator ?? throw new ArgumentNullException(nameof(chiefDriverLoyaltyLookupEntityValidator));
            _driverNationalityLookupRepository = driverNationalityLookupRepository ?? throw new ArgumentNullException(nameof(driverNationalityLookupRepository));
            _driverNationalityLookupEntityValidator = driverNationalityLookupEntityValidator ?? throw new ArgumentNullException(nameof(driverNationalityLookupEntityValidator));
            _teamDebutGrandPrixLookupRepository = teamDebutGrandPrixLookupRepository ?? throw new ArgumentNullException(nameof(teamDebutGrandPrixLookupRepository));
            _teamDebutGrandPrixLookupEntityValidator = teamDebutGrandPrixLookupEntityValidator ?? throw new ArgumentNullException(nameof(teamDebutGrandPrixLookupEntityValidator));
            _trackFastestLapDriverLookupRepository = trackFastestLapDriverLookupRepository ?? throw new ArgumentNullException(nameof(trackFastestLapDriverLookupRepository));
            _trackFastestLapDriverLookupEntityValidator = trackFastestLapDriverLookupEntityValidator ?? throw new ArgumentNullException(nameof(trackFastestLapDriverLookupEntityValidator));
            _trackLayoutLookupEntityRepository = trackLayoutLookupEntityRepository ?? throw new ArgumentNullException(nameof(trackLayoutLookupEntityRepository));
            _trackLayoutLookupEntityValidator = trackLayoutLookupEntityValidator ?? throw new ArgumentNullException(nameof(trackLayoutLookupEntityValidator));
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

        public IEnumerable<TrackFastestLapDriverLookupEntity> GetTrackFastestLapDriverLookups()
        {
            return _trackFastestLapDriverLookupRepository.Get();
        }

        public void SetTrackFastestLapDriverLookups(IEnumerable<TrackFastestLapDriverLookupEntity> trackFastestLapDriverLookups)
        {
            if (trackFastestLapDriverLookups == null) throw new ArgumentNullException(nameof(trackFastestLapDriverLookups));

            var validationMessages = new List<string>();

            var list = trackFastestLapDriverLookups as IList<TrackFastestLapDriverLookupEntity> ?? trackFastestLapDriverLookups.ToList();
            foreach (var item in list)
            {
                var messages = _trackFastestLapDriverLookupEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _trackFastestLapDriverLookupRepository.Set(list);
        }

        public void SetTrackFastestLapDriverLookup(TrackFastestLapDriverLookupEntity trackFastestLapDriverLookup)
        {
            if (trackFastestLapDriverLookup == null) throw new ArgumentNullException(nameof(trackFastestLapDriverLookup));

            var validationMessages = new List<string>();

            var messages = _trackFastestLapDriverLookupEntityValidator.Validate(trackFastestLapDriverLookup);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _trackFastestLapDriverLookupRepository.SetById(trackFastestLapDriverLookup);
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