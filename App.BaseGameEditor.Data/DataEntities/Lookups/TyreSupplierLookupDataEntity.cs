﻿using App.Core.Entities;
using App.Core.Entities.Lookups;
using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataEntities.Lookups
{
    public class TyreSupplierLookupDataEntity : IntegerIdentityBase, ILookup, IEntity
    {
        public int Value { get; set; }
        public string Description { get; set; }
    }
}