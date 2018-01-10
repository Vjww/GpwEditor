using System.Collections.Generic;

namespace App.BaseGameEditor.Data.Catalogues
{
    public interface ICatalogueReader<in TCatalogueItem>
        where TCatalogueItem : class, ICatalogueItem
    {
        string Read(IEnumerable<TCatalogueItem> catalogue, int id);
    }
}