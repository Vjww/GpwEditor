using System.Collections.Generic;
using System.Linq;

namespace App.BaseGameEditor.Data.Catalogues.Commentary
{
    public class CommentaryCatalogueWriter : ICatalogueWriter<CommentaryCatalogueItem>
    {
        public void Write(IEnumerable<CommentaryCatalogueItem> catalogue, int id, CommentaryCatalogueItem item)
        {
            var catalogueItem = catalogue.Single(x => x.Id == id);
            catalogueItem.FileNamePrefix = item.FileNamePrefix;
        }
    }
}