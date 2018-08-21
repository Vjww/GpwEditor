using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Entities;
using App.Core.Repositories;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.Services
{
    public class PersonDomainService
    {
        private readonly IRepository<F1ChiefCommercialEntity> _f1ChiefCommercialRepository;
        private readonly IRepository<F1ChiefDesignerEntity> _f1ChiefDesignerRepository;
        private readonly IRepository<F1ChiefEngineerEntity> _f1ChiefEngineerRepository;
        private readonly IRepository<F1ChiefMechanicEntity> _f1ChiefMechanicRepository;
        private readonly IRepository<F1DriverEntity> _f1DriverRepository;
        private readonly IRepository<NonF1ChiefCommercialEntity> _nonF1ChiefCommercialRepository;
        private readonly IRepository<NonF1ChiefDesignerEntity> _nonF1ChiefDesignerRepository;
        private readonly IRepository<NonF1ChiefEngineerEntity> _nonF1ChiefEngineerRepository;
        private readonly IRepository<NonF1ChiefMechanicEntity> _nonF1ChiefMechanicRepository;
        private readonly IRepository<NonF1DriverEntity> _nonF1DriverRepository;
        private readonly IEntityValidator<F1ChiefCommercialEntity> _f1ChiefCommercialEntityValidator;
        private readonly IEntityValidator<F1ChiefDesignerEntity> _f1ChiefDesignerEntityValidator;
        private readonly IEntityValidator<F1ChiefEngineerEntity> _f1ChiefEngineerEntityValidator;
        private readonly IEntityValidator<F1ChiefMechanicEntity> _f1ChiefMechanicEntityValidator;
        private readonly IEntityValidator<F1DriverEntity> _f1DriverEntityValidator;
        private readonly IEntityValidator<NonF1ChiefCommercialEntity> _nonF1ChiefCommercialEntityValidator;
        private readonly IEntityValidator<NonF1ChiefDesignerEntity> _nonF1ChiefDesignerEntityValidator;
        private readonly IEntityValidator<NonF1ChiefEngineerEntity> _nonF1ChiefEngineerEntityValidator;
        private readonly IEntityValidator<NonF1ChiefMechanicEntity> _nonF1ChiefMechanicEntityValidator;
        private readonly IEntityValidator<NonF1DriverEntity> _nonF1DriverEntityValidator;

        public PersonDomainService(
            IRepository<F1ChiefCommercialEntity> f1ChiefCommercialRepository,
            IRepository<F1ChiefDesignerEntity> f1ChiefDesignerRepository,
            IRepository<F1ChiefEngineerEntity> f1ChiefEngineerRepository,
            IRepository<F1ChiefMechanicEntity> f1ChiefMechanicRepository,
            IRepository<F1DriverEntity> f1DriverRepository,
            IRepository<NonF1ChiefCommercialEntity> nonF1ChiefCommercialRepository,
            IRepository<NonF1ChiefDesignerEntity> nonF1ChiefDesignerRepository,
            IRepository<NonF1ChiefEngineerEntity> nonF1ChiefEngineerRepository,
            IRepository<NonF1ChiefMechanicEntity> nonF1ChiefMechanicRepository,
            IRepository<NonF1DriverEntity> nonF1DriverRepository,
            IEntityValidator<F1ChiefCommercialEntity> f1ChiefCommercialEntityValidator,
            IEntityValidator<F1ChiefDesignerEntity> f1ChiefDesignerEntityValidator,
            IEntityValidator<F1ChiefEngineerEntity> f1ChiefEngineerEntityValidator,
            IEntityValidator<F1ChiefMechanicEntity> f1ChiefMechanicEntityValidator,
            IEntityValidator<F1DriverEntity> f1DriverEntityValidator,
            IEntityValidator<NonF1ChiefCommercialEntity> nonF1ChiefCommercialEntityValidator,
            IEntityValidator<NonF1ChiefDesignerEntity> nonF1ChiefDesignerEntityValidator,
            IEntityValidator<NonF1ChiefEngineerEntity> nonF1ChiefEngineerEntityValidator,
            IEntityValidator<NonF1ChiefMechanicEntity> nonF1ChiefMechanicEntityValidator,
            IEntityValidator<NonF1DriverEntity> nonF1DriverEntityValidator)
        {
            _f1ChiefCommercialRepository = f1ChiefCommercialRepository ?? throw new ArgumentNullException(nameof(f1ChiefCommercialRepository));
            _f1ChiefDesignerRepository = f1ChiefDesignerRepository ?? throw new ArgumentNullException(nameof(f1ChiefDesignerRepository));
            _f1ChiefEngineerRepository = f1ChiefEngineerRepository ?? throw new ArgumentNullException(nameof(f1ChiefEngineerRepository));
            _f1ChiefMechanicRepository = f1ChiefMechanicRepository ?? throw new ArgumentNullException(nameof(f1ChiefMechanicRepository));
            _f1DriverRepository = f1DriverRepository ?? throw new ArgumentNullException(nameof(f1DriverRepository));
            _nonF1ChiefCommercialRepository = nonF1ChiefCommercialRepository ?? throw new ArgumentNullException(nameof(nonF1ChiefCommercialRepository));
            _nonF1ChiefDesignerRepository = nonF1ChiefDesignerRepository ?? throw new ArgumentNullException(nameof(nonF1ChiefDesignerRepository));
            _nonF1ChiefEngineerRepository = nonF1ChiefEngineerRepository ?? throw new ArgumentNullException(nameof(nonF1ChiefEngineerRepository));
            _nonF1ChiefMechanicRepository = nonF1ChiefMechanicRepository ?? throw new ArgumentNullException(nameof(nonF1ChiefMechanicRepository));
            _nonF1DriverRepository = nonF1DriverRepository ?? throw new ArgumentNullException(nameof(nonF1DriverRepository));
            _f1ChiefCommercialEntityValidator = f1ChiefCommercialEntityValidator ?? throw new ArgumentNullException(nameof(f1ChiefCommercialEntityValidator));
            _f1ChiefDesignerEntityValidator = f1ChiefDesignerEntityValidator ?? throw new ArgumentNullException(nameof(f1ChiefDesignerEntityValidator));
            _f1ChiefEngineerEntityValidator = f1ChiefEngineerEntityValidator ?? throw new ArgumentNullException(nameof(f1ChiefEngineerEntityValidator));
            _f1ChiefMechanicEntityValidator = f1ChiefMechanicEntityValidator ?? throw new ArgumentNullException(nameof(f1ChiefMechanicEntityValidator));
            _f1DriverEntityValidator = f1DriverEntityValidator ?? throw new ArgumentNullException(nameof(f1DriverEntityValidator));
            _nonF1ChiefCommercialEntityValidator = nonF1ChiefCommercialEntityValidator ?? throw new ArgumentNullException(nameof(nonF1ChiefCommercialEntityValidator));
            _nonF1ChiefDesignerEntityValidator = nonF1ChiefDesignerEntityValidator ?? throw new ArgumentNullException(nameof(nonF1ChiefDesignerEntityValidator));
            _nonF1ChiefEngineerEntityValidator = nonF1ChiefEngineerEntityValidator ?? throw new ArgumentNullException(nameof(nonF1ChiefEngineerEntityValidator));
            _nonF1ChiefMechanicEntityValidator = nonF1ChiefMechanicEntityValidator ?? throw new ArgumentNullException(nameof(nonF1ChiefMechanicEntityValidator));
            _nonF1DriverEntityValidator = nonF1DriverEntityValidator ?? throw new ArgumentNullException(nameof(nonF1DriverEntityValidator));
        }

        public IEnumerable<F1ChiefCommercialEntity> GetF1ChiefCommercials()
        {
            return _f1ChiefCommercialRepository.Get();
        }

        public void SetF1ChiefCommercials(IEnumerable<F1ChiefCommercialEntity> persons)
        {
            if (persons == null) throw new ArgumentNullException(nameof(persons));

            var validationMessages = new List<string>();

            var list = persons as IList<F1ChiefCommercialEntity> ?? persons.ToList();
            foreach (var item in list)
            {
                var messages = _f1ChiefCommercialEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _f1ChiefCommercialRepository.Set(list);
        }

        public void SetF1ChiefCommercial(F1ChiefCommercialEntity person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));

            var validationMessages = new List<string>();

            var messages = _f1ChiefCommercialEntityValidator.Validate(person);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _f1ChiefCommercialRepository.SetById(person);
        }

        public IEnumerable<F1ChiefDesignerEntity> GetF1ChiefDesigners()
        {
            return _f1ChiefDesignerRepository.Get();
        }

        public void SetF1ChiefDesigners(IEnumerable<F1ChiefDesignerEntity> persons)
        {
            if (persons == null) throw new ArgumentNullException(nameof(persons));

            var validationMessages = new List<string>();

            var list = persons as IList<F1ChiefDesignerEntity> ?? persons.ToList();
            foreach (var item in list)
            {
                var messages = _f1ChiefDesignerEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _f1ChiefDesignerRepository.Set(list);
        }

        public void SetF1ChiefDesigner(F1ChiefDesignerEntity person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));

            var validationMessages = new List<string>();

            var messages = _f1ChiefDesignerEntityValidator.Validate(person);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _f1ChiefDesignerRepository.SetById(person);
        }

        public IEnumerable<F1ChiefEngineerEntity> GetF1ChiefEngineers()
        {
            return _f1ChiefEngineerRepository.Get();
        }

        public void SetF1ChiefEngineers(IEnumerable<F1ChiefEngineerEntity> persons)
        {
            if (persons == null) throw new ArgumentNullException(nameof(persons));

            var validationMessages = new List<string>();

            var list = persons as IList<F1ChiefEngineerEntity> ?? persons.ToList();
            foreach (var item in list)
            {
                var messages = _f1ChiefEngineerEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _f1ChiefEngineerRepository.Set(list);
        }

        public void SetF1ChiefEngineer(F1ChiefEngineerEntity person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));

            var validationMessages = new List<string>();

            var messages = _f1ChiefEngineerEntityValidator.Validate(person);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _f1ChiefEngineerRepository.SetById(person);
        }

        public IEnumerable<F1ChiefMechanicEntity> GetF1ChiefMechanics()
        {
            return _f1ChiefMechanicRepository.Get();
        }

        public void SetF1ChiefMechanics(IEnumerable<F1ChiefMechanicEntity> persons)
        {
            if (persons == null) throw new ArgumentNullException(nameof(persons));

            var validationMessages = new List<string>();

            var list = persons as IList<F1ChiefMechanicEntity> ?? persons.ToList();
            foreach (var item in list)
            {
                var messages = _f1ChiefMechanicEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _f1ChiefMechanicRepository.Set(list);
        }

        public void SetF1ChiefMechanic(F1ChiefMechanicEntity person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));

            var validationMessages = new List<string>();

            var messages = _f1ChiefMechanicEntityValidator.Validate(person);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _f1ChiefMechanicRepository.SetById(person);
        }

        public IEnumerable<F1DriverEntity> GetF1Drivers()
        {
            return _f1DriverRepository.Get();
        }

        public void SetF1Drivers(IEnumerable<F1DriverEntity> persons)
        {
            if (persons == null) throw new ArgumentNullException(nameof(persons));

            var validationMessages = new List<string>();

            var list = persons as IList<F1DriverEntity> ?? persons.ToList();
            foreach (var item in list)
            {
                var messages = _f1DriverEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _f1DriverRepository.Set(list);
        }

        public void SetF1Driver(F1DriverEntity person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));

            var validationMessages = new List<string>();

            var messages = _f1DriverEntityValidator.Validate(person);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _f1DriverRepository.SetById(person);
        }

        public IEnumerable<NonF1ChiefCommercialEntity> GetNonF1ChiefCommercials()
        {
            return _nonF1ChiefCommercialRepository.Get();
        }

        public void SetNonF1ChiefCommercials(IEnumerable<NonF1ChiefCommercialEntity> persons)
        {
            if (persons == null) throw new ArgumentNullException(nameof(persons));

            var validationMessages = new List<string>();

            var list = persons as IList<NonF1ChiefCommercialEntity> ?? persons.ToList();
            foreach (var item in list)
            {
                var messages = _nonF1ChiefCommercialEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _nonF1ChiefCommercialRepository.Set(list);
        }

        public void SetNonF1ChiefCommercial(NonF1ChiefCommercialEntity person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));

            var validationMessages = new List<string>();

            var messages = _nonF1ChiefCommercialEntityValidator.Validate(person);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _nonF1ChiefCommercialRepository.SetById(person);
        }

        public IEnumerable<NonF1ChiefDesignerEntity> GetNonF1ChiefDesigners()
        {
            return _nonF1ChiefDesignerRepository.Get();
        }

        public void SetNonF1ChiefDesigners(IEnumerable<NonF1ChiefDesignerEntity> persons)
        {
            if (persons == null) throw new ArgumentNullException(nameof(persons));

            var validationMessages = new List<string>();

            var list = persons as IList<NonF1ChiefDesignerEntity> ?? persons.ToList();
            foreach (var item in list)
            {
                var messages = _nonF1ChiefDesignerEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _nonF1ChiefDesignerRepository.Set(list);
        }

        public void SetNonF1ChiefDesigner(NonF1ChiefDesignerEntity person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));

            var validationMessages = new List<string>();

            var messages = _nonF1ChiefDesignerEntityValidator.Validate(person);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _nonF1ChiefDesignerRepository.SetById(person);
        }

        public IEnumerable<NonF1ChiefEngineerEntity> GetNonF1ChiefEngineers()
        {
            return _nonF1ChiefEngineerRepository.Get();
        }

        public void SetNonF1ChiefEngineers(IEnumerable<NonF1ChiefEngineerEntity> persons)
        {
            if (persons == null) throw new ArgumentNullException(nameof(persons));

            var validationMessages = new List<string>();

            var list = persons as IList<NonF1ChiefEngineerEntity> ?? persons.ToList();
            foreach (var item in list)
            {
                var messages = _nonF1ChiefEngineerEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _nonF1ChiefEngineerRepository.Set(list);
        }

        public void SetNonF1ChiefEngineer(NonF1ChiefEngineerEntity person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));

            var validationMessages = new List<string>();

            var messages = _nonF1ChiefEngineerEntityValidator.Validate(person);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _nonF1ChiefEngineerRepository.SetById(person);
        }

        public IEnumerable<NonF1ChiefMechanicEntity> GetNonF1ChiefMechanics()
        {
            return _nonF1ChiefMechanicRepository.Get();
        }

        public void SetNonF1ChiefMechanics(IEnumerable<NonF1ChiefMechanicEntity> persons)
        {
            if (persons == null) throw new ArgumentNullException(nameof(persons));

            var validationMessages = new List<string>();

            var list = persons as IList<NonF1ChiefMechanicEntity> ?? persons.ToList();
            foreach (var item in list)
            {
                var messages = _nonF1ChiefMechanicEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _nonF1ChiefMechanicRepository.Set(list);
        }

        public void SetNonF1ChiefMechanic(NonF1ChiefMechanicEntity person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));

            var validationMessages = new List<string>();

            var messages = _nonF1ChiefMechanicEntityValidator.Validate(person);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _nonF1ChiefMechanicRepository.SetById(person);
        }

        public IEnumerable<NonF1DriverEntity> GetNonF1Drivers()
        {
            return _nonF1DriverRepository.Get();
        }

        public void SetNonF1Drivers(IEnumerable<NonF1DriverEntity> persons)
        {
            if (persons == null) throw new ArgumentNullException(nameof(persons));

            var validationMessages = new List<string>();

            var list = persons as IList<NonF1DriverEntity> ?? persons.ToList();
            foreach (var item in list)
            {
                var messages = _nonF1DriverEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _nonF1DriverRepository.Set(list);
        }

        public void SetNonF1Driver(NonF1DriverEntity person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));

            var validationMessages = new List<string>();

            var messages = _nonF1DriverEntityValidator.Validate(person);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _nonF1DriverRepository.SetById(person);
        }
    }
}