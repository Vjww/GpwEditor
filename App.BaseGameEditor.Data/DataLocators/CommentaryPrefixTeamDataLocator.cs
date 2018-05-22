using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class CommentaryPrefixTeamDataLocator : IntegerIdentityBase, IDataLocator
    {
        public int CommentaryIndexOut { get; set; }

        public void Initialise()
        {
            CommentaryIndexOut = Id + 231;
        }
    }
}