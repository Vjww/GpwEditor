using System;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Factories
{
    public class TeamDataEntityFactory
    {
        private readonly Func<TeamDataEntity> _instantiateType;

        public TeamDataEntityFactory(Func<TeamDataEntity> instantiateType)
        {
            _instantiateType = instantiateType ?? throw new ArgumentNullException(nameof(instantiateType));
        }

        public TeamDataEntity Create(int id)
        {
            var result = _instantiateType.Invoke();
            result.Id = id;
            return result;
        }
    }
}