﻿using System;
using App.Core.Identities;
using App.Shared.Data.Calculators;
using App.Shared.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class F1ChiefCommercialDataLocator : IntegerIdentityBase, IDataLocator
    {
        private readonly IdentityCalculator _calculator;

        private const int NameOffset = 5795; // "None"

        private const int BaseOffset = 463060;
        private const int LocalOffset = 260;
        private const int AbilityOffset = 0;
        private const int AgeOffset = 20;
        private const int SalaryOffset = 10;
        private const int RoyaltyOffset = 40;
        private const int MoraleOffset = 30;

        public int Name { get; set; }
        public int Ability { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int Royalty { get; set; }
        public int Morale { get; set; }

        public F1ChiefCommercialDataLocator(IdentityCalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void Initialise()
        {
            Name = NameOffset + _calculator.GetF1ChiefCommercialNameId(Id);

            var stepOffset = LocalOffset * Id;

            Ability = BaseOffset + stepOffset + AbilityOffset;
            Age = BaseOffset + stepOffset + AgeOffset;
            Salary = BaseOffset + stepOffset + SalaryOffset;
            Royalty = BaseOffset + stepOffset + RoyaltyOffset;
            Morale = BaseOffset + stepOffset + MoraleOffset;
        }
    }
}