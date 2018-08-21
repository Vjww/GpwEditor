using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Entities;
using App.Core.Repositories;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.Services
{
    public class PerformanceCurveDomainService
    {
        private readonly IRepository<PerformanceCurveEntity> _performanceCurveRepository;
        private readonly IEntityValidator<PerformanceCurveEntity> _performanceCurveEntityValidator;

        public PerformanceCurveDomainService(
            IRepository<PerformanceCurveEntity> performanceCurveRepository,
            IEntityValidator<PerformanceCurveEntity> performanceCurveEntityValidator)
        {
            _performanceCurveRepository = performanceCurveRepository ?? throw new ArgumentNullException(nameof(performanceCurveRepository));
            _performanceCurveEntityValidator = performanceCurveEntityValidator ?? throw new ArgumentNullException(nameof(performanceCurveEntityValidator));
        }

        public IEnumerable<PerformanceCurveEntity> GetPerformanceCurves()
        {
            return _performanceCurveRepository.Get();
        }

        public void SetPerformanceCurves(IEnumerable<PerformanceCurveEntity> performanceCurves)
        {
            if (performanceCurves == null) throw new ArgumentNullException(nameof(performanceCurves));

            var validationMessages = new List<string>();

            var list = performanceCurves as IList<PerformanceCurveEntity> ?? performanceCurves.ToList();
            foreach (var item in list)
            {
                var messages = _performanceCurveEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _performanceCurveRepository.Set(list);
        }

        public void SetPerformanceCurve(PerformanceCurveEntity performanceCurve)
        {
            if (performanceCurve == null) throw new ArgumentNullException(nameof(performanceCurve));

            var validationMessages = new List<string>();

            var messages = _performanceCurveEntityValidator.Validate(performanceCurve);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _performanceCurveRepository.SetById(performanceCurve);
        }
    }
}