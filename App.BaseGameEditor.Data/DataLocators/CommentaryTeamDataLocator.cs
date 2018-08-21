using System;
using App.Core.Identities;
using App.Shared.Data.Calculators;

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