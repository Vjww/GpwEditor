using System;
using System.Collections.Generic;
using App.BaseGameEditor.Domain.Models;
using App.BaseGameEditor.Domain.Repositories;

namespace App.BaseGameEditor.Domain.Services
{
    public class TeamService : IService<TeamModel>
    {
        private readonly TeamRepository _repository;

        public TeamService(TeamRepository repository)
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

        public void Set(IEnumerable<TeamModel> models)
        {
            if (models == null) throw new ArgumentNullException(nameof(models));

            _repository.Set(models);
        }

        public void SetById(TeamModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            _repository.SetById(model);
        }
    }
}