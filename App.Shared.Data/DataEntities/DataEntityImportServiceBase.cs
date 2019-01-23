using App.Shared.Data.Catalogues.Language;
using App.Shared.Data.DataEndpoints;

namespace App.Shared.Data.DataEntities
{
    public abstract class DataEntityImportServiceBase
    {
        protected void ImportLanguageCatalogueValue(DataEndpoint dataEndpoint, LanguageCatalogueValue value, int id)
        {
            value.English = dataEndpoint.EnglishLanguageCatalogue.Read(id).Value;
            value.French = dataEndpoint.FrenchLanguageCatalogue.Read(id).Value;
            value.German = dataEndpoint.GermanLanguageCatalogue.Read(id).Value;
        }
    }
}