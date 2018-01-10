using System.Collections.Generic;
using System.Linq;

namespace App.BaseGameEditor.Data.Catalogues.Language
{
    public class LanguageCatalogueReader : ICatalogueReader<LanguageCatalogueItem>
    {
        public string Read(IEnumerable<LanguageCatalogueItem> catalogue, int id)
        {
            var item = catalogue.Single(x => x.Id == id);
            return item.Value;
        }
    }
}