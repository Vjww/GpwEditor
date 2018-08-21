using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Entities;
using App.Core.Repositories;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.Services
{
    public class SupplierDomainService
    {
        private readonly IRepository<EngineEntity> _engineRepository;
        private readonly IEntityValidator<EngineEntity> _engineEntityValidator;
        private readonly IRepository<TyreEntity> _tyreRepository;
        private readonly IEntityValidator<TyreEntity> _tyreEntityValidator;
        private readonly IRepository<FuelEntity> _fuelRepository;
        private readonly IEntityValidator<FuelEntity> _fuelEntityValidator;

        public SupplierDomainService(
            IRepository<EngineEntity> engineRepository,
            IEntityValidator<EngineEntity> engineEntityValidator,
            IRepository<TyreEntity> tyreRepository,
            IEntityValidator<TyreEntity> tyreEntityValidator,
            IRepository<FuelEntity> fuelRepository,
            IEntityValidator<FuelEntity> fuelEntityValidator)
        {
            _engineRepository = engineRepository ?? throw new ArgumentNullException(nameof(engineRepository));
            _engineEntityValidator = engineEntityValidator ?? throw new ArgumentNullException(nameof(engineEntityValidator));
            _tyreRepository = tyreRepository ?? throw new ArgumentNullException(nameof(tyreRepository));
            _tyreEntityValidator = tyreEntityValidator ?? throw new ArgumentNullException(nameof(tyreEntityValidator));
            _fuelRepository = fuelRepository ?? throw new ArgumentNullException(nameof(fuelRepository));
            _fuelEntityValidator = fuelEntityValidator ?? throw new ArgumentNullException(nameof(fuelEntityValidator));
        }

        public IEnumerable<EngineEntity> GetEngines()
        {
            return _engineRepository.Get();
        }

        public void SetEngines(IEnumerable<EngineEntity> engines)
        {
            if (engines == null) throw new ArgumentNullException(nameof(engines));

            var validationMessages = new List<string>();

            var list = engines as IList<EngineEntity> ?? engines.ToList();
            foreach (var item in list)
            {
                var messages = _engineEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _engineRepository.Set(list);
        }

        public void SetEngine(EngineEntity engine)
        {
            if (engine == null) throw new ArgumentNullException(nameof(engine));

            var validationMessages = new List<string>();

            var messages = _engineEntityValidator.Validate(engine);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _engineRepository.SetById(engine);
        }

        public IEnumerable<TyreEntity> GetTyres()
        {
            return _tyreRepository.Get();
        }

        public void SetTyres(IEnumerable<TyreEntity> tyres)
        {
            if (tyres == null) throw new ArgumentNullException(nameof(tyres));

            var validationMessages = new List<string>();

            var list = tyres as IList<TyreEntity> ?? tyres.ToList();
            foreach (var item in list)
            {
                var messages = _tyreEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _tyreRepository.Set(list);
        }

        public void SetTyre(TyreEntity tyre)
        {
            if (tyre == null) throw new ArgumentNullException(nameof(tyre));

            var validationMessages = new List<string>();

            var messages = _tyreEntityValidator.Validate(tyre);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _tyreRepository.SetById(tyre);
        }

        public IEnumerable<FuelEntity> GetFuels()
        {
            return _fuelRepository.Get();
        }

        public void SetFuels(IEnumerable<FuelEntity> fuels)
        {
            if (fuels == null) throw new ArgumentNullException(nameof(fuels));

            var validationMessages = new List<string>();

            var list = fuels as IList<FuelEntity> ?? fuels.ToList();
            foreach (var item in list)
            {
                var messages = _fuelEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _fuelRepository.Set(list);
        }

        public void SetFuel(FuelEntity fuel)
        {
            if (fuel == null) throw new ArgumentNullException(nameof(fuel));

            var validationMessages = new List<string>();

            var messages = _fuelEntityValidator.Validate(fuel);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _fuelRepository.SetById(fuel);
        }
    }
}