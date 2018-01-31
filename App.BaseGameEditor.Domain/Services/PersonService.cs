using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Repositories;

namespace App.BaseGameEditor.Domain.Services
{
    public class PersonService
    {
        private readonly IF1ChiefCommercialRepository _f1ChiefCommercialRepository;

        public PersonService(IF1ChiefCommercialRepository f1ChiefCommercialRepository)
        {
            _f1ChiefCommercialRepository = f1ChiefCommercialRepository ?? throw new ArgumentNullException(nameof(f1ChiefCommercialRepository));
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
    }
}