using App.Shared.Data.Catalogues.Language;
using App.Shared.Data.DataEndpoints;

namespace App.Shared.Data.DataEntities
{
    public abstract class DataEntityExportServiceBase
    {
        protected void ExportLanguageCatalogueValue(DataEndpoint dataEndpoint, LanguageCatalogueValue value, int id)
        {
            var englishCatalogueItem = dataEndpoint.EnglishLanguageCatalogue.Read(id);
            var frenchCatalogueItem = dataEndpoint.FrenchLanguageCatalogue.Read(id);
            var germanCatalogueItem = dataEndpoint.GermanLanguageCatalogue.Read(id);

            englishCatalogueItem.Value = value.English;
            frenchCatalogueItem.Value = value.French;
            germanCatalogueItem.Value = value.German;

            dataEndpoint.EnglishLanguageCatalogue.Write(id, englishCatalogueItem);
            dataEndpoint.FrenchLanguageCatalogue.Write(id, frenchCatalogueItem);
            dataEndpoint.GermanLanguageCatalogue.Write(id, germanCatalogueItem);
        }
    }
}