﻿using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class F1ChiefCommercialModel : IntegerIdentityBase, IEntity
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int Ability { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int Royalty { get; set; }
        public int Morale { get; set; }
    }
}