using System.Collections.Generic;
using System.Linq;

namespace App.BaseGameEditor.Data.Catalogues.Language
{
    public class LanguageCatalogueWriter : ICatalogueWriter<LanguageCatalogueItem>
    {
        public void Write(IEnumerable<LanguageCatalogueItem> catalogue, int id, LanguageCatalogueItem item)
        {
            var catalogueItem = catalogue.Single(x => x.Id == id);
            catalogueItem.Value = item.Value;
        }
    }
}