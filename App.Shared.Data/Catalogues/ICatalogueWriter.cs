using System.Collections.Generic;

namespace App.Shared.Data.Catalogues
{
    public interface ICatalogueWriter<in TCatalogueItem>
        where TCatalogueItem : class, ICatalogueItem
    {
        void Write(IEnumerable<TCatalogueItem> catalogue, int id, TCatalogueItem item);
    }
}