using System;
using App.Core.Identities;
using App.Shared.Data.Calculators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class NonF1ChiefMechanicDataLocator : IntegerIdentityBase, IDataLocator
    {
        private readonly IdentityCalculator _calculator;

        private const int NameOffset = 5795; // "None"

        private const int BaseOffset = 454524;
        private const int LocalOffset = 60;
        private const int AbilityOffset = 10;
        private const int AgeOffset = 50;
        private const int SalaryOffset = 0;
        private const int RaceBonusOffset = 30;
        private const int ChampionshipBonusOffset = 40;

        public int Name { get; set; }
        public int Ability { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int RaceBonus { get; set; }
        public int ChampionshipBonus { get; set; }

        public NonF1ChiefMechanicDataLocator(IdentityCalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void Initialise()
        {
            Name = NameOffset + _calculator.GetNonF1ChiefMechanicNameId(Id);

            var stepOffset = LocalOffset * Id;

            Ability = BaseOffset + stepOffset + AbilityOffset;
            Age = BaseOffset + stepOffset + AgeOffset;
            Salary = BaseOffset + stepOffset + SalaryOffset;
            RaceBonus = BaseOffset + stepOffset + RaceBonusOffset;
            ChampionshipBonus = BaseOffset + stepOffset + ChampionshipBonusOffset;
        }
    }
}