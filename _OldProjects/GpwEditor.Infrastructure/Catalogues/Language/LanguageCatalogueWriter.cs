using System.Collections.Generic;
using System.Linq;
using Common.Editor.Data.Catalogues;

namespace GpwEditor.Infrastructure.Catalogues.Language
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