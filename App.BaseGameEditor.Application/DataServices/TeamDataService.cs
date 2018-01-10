using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Models;
using App.BaseGameEditor.Domain.Repositories;

namespace App.BaseGameEditor.Application.DataServices
{
    public class TeamDataService
    {
        private readonly TeamRepository _repository;

        public TeamDataService(TeamRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<TeamModel> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<TeamModel> Get(Func<TeamModel, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return _repository.Get(predicate);
        }

        public TeamModel GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            return _repository.GetById(id);
        }

        public void Set(IEnumerable<TeamModel> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            var validationFailureMessages = new List<string>();
            var list = items as IList<TeamModel> ?? items.ToList();
            foreach (var item in list)
            {
                var messages = item.Validate();
                validationFailureMessages.AddRange(messages);
            }

            if (validationFailureMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _repository.Set(list);
        }

        public void SetById(TeamModel item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var validationFailureMessages = new List<string>();

            var messages = item.Validate();
            validationFailureMessages.AddRange(messages);

            if (validationFailureMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _repository.SetById(item);
        }
    }
}