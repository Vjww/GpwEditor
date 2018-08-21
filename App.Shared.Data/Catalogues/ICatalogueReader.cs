using System.Collections.Generic;

namespace App.Shared.Data.Catalogues
{
    public interface ICatalogueReader<TCatalogueItem>
        where TCatalogueItem : class, ICatalogueItem
    {
        TCatalogueItem Read(IEnumerable<TCatalogueItem> catalogue, int id);
    }
}