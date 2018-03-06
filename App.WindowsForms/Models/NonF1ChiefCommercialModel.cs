﻿using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class NonF1ChiefCommercialModel : IntegerIdentityBase, IEntity
    {
        public string Name { get; set; }
        public int Ability { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int Royalty { get; set; }
    }
}