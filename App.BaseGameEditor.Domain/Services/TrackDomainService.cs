using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Entities;
using App.Core.Repositories;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.Services
{
    public class TrackDomainService
    {
        private readonly IRepository<TrackEntity> _trackRepository;
        private readonly IEntityValidator<TrackEntity> _trackEntityValidator;

        public TrackDomainService(
            IRepository<TrackEntity> trackRepository,
            IEntityValidator<TrackEntity> trackEntityValidator)
        {
            _trackRepository = trackRepository ?? throw new ArgumentNullException(nameof(trackRepository));
            _trackEntityValidator = trackEntityValidator ?? throw new ArgumentNullException(nameof(trackEntityValidator));
        }

        public IEnumerable<TrackEntity> GetTracks()
        {
            return _trackRepository.Get();
        }

        public void SetTracks(IEnumerable<TrackEntity> tracks)
        {
            if (tracks == null) throw new ArgumentNullException(nameof(tracks));

            var validationMessages = new List<string>();

            var list = tracks as IList<TrackEntity> ?? tracks.ToList();
            foreach (var item in list)
            {
                var messages = _trackEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _trackRepository.Set(list);
        }

        public void SetTrack(TrackEntity track)
        {
            if (track == null) throw new ArgumentNullException(nameof(track));

            var validationMessages = new List<string>();

            var messages = _trackEntityValidator.Validate(track);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _trackRepository.SetById(track);
        }
    }
}