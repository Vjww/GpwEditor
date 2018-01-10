using System.Collections.Generic;
using System.Linq;

namespace App.BaseGameEditor.Data.Catalogues.Commentary
{
    public class CommentaryCatalogueWriter : ICatalogueWriter<CommentaryCatalogueItem>
    {
        public void Write(IEnumerable<CommentaryCatalogueItem> catalogue, int id, string value)
        {
            var item = catalogue.Single(x => x.Id == id);
            item.Transcript = value;
        }
    }
}