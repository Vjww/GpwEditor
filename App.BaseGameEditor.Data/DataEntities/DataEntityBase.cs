using System;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class DataEntityBase : IDataEntity
    {
        private bool _isIdInitialised;
        private int _id;

        protected DataEntityBase()
        {
        }

        public int Id
        {
            get => _id;
            set => SetId(value);
        }

        private void SetId(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            if (_isIdInitialised) throw new InvalidOperationException($"The {nameof(Id)} property cannot be changed after it has been initialised.");

            _id = id;
            _isIdInitialised = true;
        }
    }
}