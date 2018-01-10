using System.Collections.Generic;
using System.Linq;
using Common.Editor.Data.Catalogues;

namespace App.Shared.Data.Catalogues.Commentary
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