using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.EntityValidators;
using App.Core.Repositories;

namespace App.LanguageFileEditor.Domain.Services
{
    public class LanguageDomainService
    {
        private readonly IRepository<LanguageEntity> _languageRepository;
        private readonly IEntityValidator<LanguageEntity> _languageEntityValidator;

        public LanguageDomainService(
            IRepository<LanguageEntity> languageRepository,
            IEntityValidator<LanguageEntity> languageEntityValidator)
        {
            _languageRepository = languageRepository ?? throw new ArgumentNullException(nameof(languageRepository));
            _languageEntityValidator = languageEntityValidator ?? throw new ArgumentNullException(nameof(languageEntityValidator));
        }

        public IEnumerable<LanguageEntity> GetLanguages()
        {
            return _languageRepository.Get();
        }

        public void SetLanguages(IEnumerable<LanguageEntity> languages)
        {
            if (languages == null) throw new ArgumentNullException(nameof(languages));

            var validationMessages = new List<string>();

            var list = languages as IList<LanguageEntity> ?? languages.ToList();
            foreach (var item in list)
            {
                var messages = _languageEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _languageRepository.Set(list);
        }

        public void SetLanguage(LanguageEntity language)
        {
            if (language == null) throw new ArgumentNullException(nameof(language));

            var validationMessages = new List<string>();

            var messages = _languageEntityValidator.Validate(language);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _languageRepository.SetById(language);
        }
    }
}