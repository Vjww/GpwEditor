using System.Collections.Generic;

namespace App.BaseGameEditor.Data.Catalogues
{
    public interface ICatalogueReader<TCatalogueItem>
        where TCatalogueItem : class, ICatalogueItem
    {
        TCatalogueItem Read(IEnumerable<TCatalogueItem> catalogue, int id);
    }
}