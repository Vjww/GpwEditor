using System.Collections.Generic;
using System.Linq;

namespace App.Shared.Data.Catalogues.Commentary
{
    public class CommentaryCatalogueReader : ICatalogueReader<CommentaryCatalogueItem>
    {
        public CommentaryCatalogueItem Read(IEnumerable<CommentaryCatalogueItem> catalogue, int id)
        {
            return catalogue.Single(x => x.Id == id);
        }
    }
}