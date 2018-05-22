using System;
using App.BaseGameEditor.Data.Calculators;
using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class CommentaryIndexTeamDataLocator : IntegerIdentityBase, IDataLocator
    {
        private readonly IdentityCalculator _calculator;

        private const int NameOffset = 5696; // "No Team"

        private const int BaseOffset = 1182835;
        private const int LocalOffset = 12;

        public int Name { get; set; }
        public int CommentaryIndex { get; set; }

        public CommentaryIndexTeamDataLocator(IdentityCalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void Initialise()
        {
            Name = NameOffset + _calculator.GetTeamNameId(Id);

            var stepOffset = LocalOffset * Id;

            CommentaryIndex = BaseOffset + stepOffset;
        }
    }
}