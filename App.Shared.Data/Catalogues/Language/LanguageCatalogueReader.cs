using System.Collections.Generic;
using System.Linq;

namespace App.Shared.Data.Catalogues.Language
{
    public class LanguageCatalogueReader : ICatalogueReader<LanguageCatalogueItem>
    {
        public LanguageCatalogueItem Read(IEnumerable<LanguageCatalogueItem> catalogue, int id)
        {
            return catalogue.Single(x => x.Id == id);
        }
    }
}