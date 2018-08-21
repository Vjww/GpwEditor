using System.Collections.Generic;

namespace App.Shared.Data.Catalogues
{
    public interface ICatalogueImporter<out TCatalogueItem>
        where TCatalogueItem : class, ICatalogueItem
    {
        IEnumerable<TCatalogueItem> Import(string filePath);
    }
}