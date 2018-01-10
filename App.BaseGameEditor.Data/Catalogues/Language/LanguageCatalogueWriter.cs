using System.Collections.Generic;
using System.Linq;

namespace App.BaseGameEditor.Data.Catalogues.Language
{
    public class LanguageCatalogueWriter : ICatalogueWriter<LanguageCatalogueItem>
    {
        public void Write(IEnumerable<LanguageCatalogueItem> catalogue, int id, string value)
        {
            var item = catalogue.Single(x => x.Id == id);
            item.Value = value;
        }
    }
}