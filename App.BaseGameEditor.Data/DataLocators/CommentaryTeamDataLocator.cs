using System;
using App.BaseGameEditor.Data.Calculators;
using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class CommentaryTeamDataLocator : IntegerIdentityBase, IDataLocator
    {
        private readonly IdentityCalculator _calculator;

        public int CommentaryIndex { get; set; }

        public CommentaryTeamDataLocator(IdentityCalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void Initialise()
        {
            CommentaryIndex = _calculator.GetCommentaryTeamIndex(Id);
        }
    }
}