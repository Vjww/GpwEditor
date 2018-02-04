using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Entities;
using App.Core.Repositories;

namespace App.BaseGameEditor.Domain.Services
{
    public class PersonService
    {
        private readonly IRepository<F1ChiefCommercialEntity> _f1ChiefCommercialRepository;
        private readonly IRepository<F1ChiefDesignerEntity> _f1ChiefDesignerRepository;
        private readonly IRepository<F1ChiefEngineerEntity> _f1ChiefEngineerRepository;
        private readonly IRepository<F1ChiefMechanicEntity> _f1ChiefMechanicRepository;
        private readonly IRepository<F1DriverEntity> _f1DriverRepository;

        public PersonService(
            IRepository<F1ChiefCommercialEntity> f1ChiefCommercialRepository,
            IRepository<F1ChiefDesignerEntity> f1ChiefDesignerRepository,
            IRepository<F1ChiefEngineerEntity> f1ChiefEngineerRepository,
            IRepository<F1ChiefMechanicEntity> f1ChiefMechanicRepository,
            IRepository<F1DriverEntity> f1DriverRepository)
        {
            _f1ChiefCommercialRepository = f1ChiefCommercialRepository ?? throw new ArgumentNullException(nameof(f1ChiefCommercialRepository));
            _f1ChiefDesignerRepository = f1ChiefDesignerRepository ?? throw new ArgumentNullException(nameof(f1ChiefDesignerRepository));
            _f1ChiefEngineerRepository = f1ChiefEngineerRepository ?? throw new ArgumentNullException(nameof(f1ChiefEngineerRepository));
            _f1ChiefMechanicRepository = f1ChiefMechanicRepository ?? throw new ArgumentNullException(nameof(f1ChiefMechanicRepository));
            _f1DriverRepository = f1DriverRepository ?? throw new ArgumentNullException(nameof(f1DriverRepository));
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
                var messages = item.Validate();
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

            var messages = person.Validate();
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
                var messages = item.Validate();
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

            var messages = person.Validate();
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
                var messages = item.Validate();
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

            var messages = person.Validate();
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
                var messages = item.Validate();
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

            var messages = person.Validate();
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
                var messages = item.Validate();
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

            var messages = person.Validate();
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _f1DriverRepository.SetById(person);
        }
    }
}