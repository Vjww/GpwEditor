using System;
using System.Collections.Generic;

namespace App.BaseGameEditor.Domain.Entities
{
    public abstract class EntityBase : IEntity
    {
        private bool _isIdInitialised;
        private int _id;

        public int Id
        {
            get => _id;
            set => SetId(value);
        }

        public abstract IEnumerable<string> Validate();

        private void SetId(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            if (_isIdInitialised) throw new InvalidOperationException($"The {nameof(Id)} property cannot be changed after it has been initialised.");

            _id = id;
            _isIdInitialised = true;
        }
    }
}