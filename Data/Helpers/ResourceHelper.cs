using System;
using System.Linq;
using Data.Collections.Language;

namespace Data.Helpers
{
    public static class ResourceHelper
    {
        public static string GetResourceText(IdentityCollection identityCollection, string resourceId)
        {
            var resource = identityCollection.SingleOrDefault(x => x.ResourceId == resourceId);

            if (resource == null)
            {
                throw new Exception($"Unable to find a resource string in the language file matching the resource id {resourceId}.");
            }

            return resource.ResourceText;
        }

        public static void SetResourceText(IdentityCollection identityCollection, string resourceId, string resourceText)
        {
            var resource = identityCollection.SingleOrDefault(x => x.ResourceId == resourceId);

            if (resource == null)
            {
                throw new Exception($"Unable to find a resource string in the language file matching the resource id {resourceId}.");
            }

            resource.ResourceText = resourceText;
        }
    }
}
