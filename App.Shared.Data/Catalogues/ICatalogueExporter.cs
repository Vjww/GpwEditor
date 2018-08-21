using System.Collections.Generic;

namespace App.Shared.Data.Catalogues
{
    public interface ICatalogueExporter<in TCatalogueItem>
        where TCatalogueItem : class, ICatalogueItem
    {
        void Export(IEnumerable<TCatalogueItem> catalogue, string filePath);
    }
}