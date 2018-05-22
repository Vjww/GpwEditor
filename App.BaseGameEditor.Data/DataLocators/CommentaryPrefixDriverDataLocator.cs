using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class CommentaryPrefixDriverDataLocator : IntegerIdentityBase, IDataLocator
    {
        public int CommentaryIndexP1 { get; set; }
        public int CommentaryIndexP2 { get; set; }
        public int CommentaryIndexP3 { get; set; }
        public int CommentaryIndexOut { get; set; }
        public int CommentaryIndexPits { get; set; }

        public void Initialise()
        {
            CommentaryIndexP1 = Id + 67;
            CommentaryIndexP2 = Id + 108;
            CommentaryIndexP3 = Id + 149;
            CommentaryIndexOut = Id + 190;
            CommentaryIndexPits = Id + 243;
        }
    }
}