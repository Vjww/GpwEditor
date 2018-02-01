﻿using System;
using App.BaseGameEditor.Data.Calculators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class ChassisHandlingDataLocator : DataLocatorBase
    {
        private const int BaseOffset = 1094126;
        private const int LocalOffset = 30;
        private const int ValueOffset = 0;

        private readonly IdentityCalculator _identityCalculator;

        public int Value { get; set; }

        public ChassisHandlingDataLocator(IdentityCalculator identityCalculator)
        {
            _identityCalculator = identityCalculator ?? throw new ArgumentNullException(nameof(identityCalculator));
        }

        public override void Initialise(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            Id = id;

            var stepOffset = LocalOffset * _identityCalculator.GetTeamAlphabeticalId(Id);

            Value = BaseOffset + stepOffset + ValueOffset;
        }
    }
}