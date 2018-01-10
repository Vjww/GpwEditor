using System.Collections.Generic;
using System.Linq;
using Common.Editor.Data.Catalogues;

namespace App.Shared.Data.Catalogues.Commentary
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