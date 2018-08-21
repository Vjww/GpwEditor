using System;
using App.Core.Identities;
using App.Shared.Data.Calculators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class CommentaryIndexDriverDataLocator : IntegerIdentityBase, IDataLocator
    {
        private readonly IdentityCalculator _calculator;

        private const int NameOffset = 5795; // "None"

        private const int BaseOffset = 474720;
        private const int LocalOffset = 10;

        public int Name { get; set; }
        public int CommentaryIndex { get; set; }

        public CommentaryIndexDriverDataLocator(IdentityCalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void Initialise()
        {
            Name = NameOffset + _calculator.GetF1AndNonF1DriverNameId(Id);

            var stepOffset = LocalOffset * Id;

            CommentaryIndex = BaseOffset + stepOffset;
        }
    }
}