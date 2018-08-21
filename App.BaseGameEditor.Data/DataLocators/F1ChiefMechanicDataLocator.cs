using System;
using App.Core.Identities;
using App.Shared.Data.Calculators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class F1ChiefMechanicDataLocator : IntegerIdentityBase, IDataLocator
    {
        private readonly IdentityCalculator _calculator;

        private const int NameOffset = 5795; // "None"

        private const int BaseOffset = 463250;
        private const int LocalOffset = 260;
        private const int AbilityOffset = 0;
        private const int AgeOffset = 20;
        private const int SalaryOffset = 10;
        private const int RaceBonusOffset = 30;
        private const int ChampionshipBonusOffset = 40;
        private const int DriverLoyaltyOffset = 60;
        private const int MoraleOffset = 50;

        public int Name { get; set; }
        public int Ability { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int RaceBonus { get; set; }
        public int ChampionshipBonus { get; set; }
        public int DriverLoyalty { get; set; }
        public int Morale { get; set; }

        public F1ChiefMechanicDataLocator(IdentityCalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void Initialise()
        {
            Name = NameOffset + _calculator.GetF1ChiefMechanicNameId(Id);

            var stepOffset = LocalOffset * Id;

            Ability = BaseOffset + stepOffset + AbilityOffset;
            Age = BaseOffset + stepOffset + AgeOffset;
            Salary = BaseOffset + stepOffset + SalaryOffset;
            RaceBonus = BaseOffset + stepOffset + RaceBonusOffset;
            ChampionshipBonus = BaseOffset + stepOffset + ChampionshipBonusOffset;
            DriverLoyalty = BaseOffset + stepOffset + DriverLoyaltyOffset;
            Morale = BaseOffset + stepOffset + MoraleOffset;
        }
    }
}