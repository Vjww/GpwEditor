using System.Collections.Generic;
using System.Linq;

namespace App.BaseGameEditor.Data.Catalogues.Commentary
{
    public class CommentaryCatalogueReader : ICatalogueReader<CommentaryCatalogueItem>
    {
        public string Read(IEnumerable<CommentaryCatalogueItem> catalogue, int id)
        {
            var item = catalogue.Single(x => x.Id == id);
            return item.Transcript;
        }
    }
}