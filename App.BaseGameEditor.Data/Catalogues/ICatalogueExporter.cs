using System.Collections.Generic;

namespace App.BaseGameEditor.Data.Catalogues
{
    public interface ICatalogueExporter<in TCatalogueItem>
        where TCatalogueItem : class, ICatalogueItem
    {
        void Export(IEnumerable<TCatalogueItem> catalogue, string filePath);
    }
}