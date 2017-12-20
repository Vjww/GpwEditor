using System;
using System.Globalization;
using System.Threading;
using Common.Editor.Data.Catalogues;

namespace GpwEditor.Infrastructure.Catalogues.Language
{
    public class LanguageCatalogueParser : ICatalogueParser<LanguageCatalogueItem>
    {
        // TODO: remove?
        //private const int FirstLineId = 0;
        //private const int LastLineId = 7172;

        public string BuildResourceId(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            return "SID" + id.ToString("D6");
        }

        // TODO: Violates DRY, as repeated in CommentaryCatalogueParser
        public bool IsValueInText(string text, string value)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (value == null) throw new ArgumentNullException(nameof(value));

            // https://stackoverflow.com/a/15464440
            return Thread.CurrentThread.CurrentCulture.CompareInfo.IndexOf(text, value, CompareOptions.IgnoreCase) >= 0;
        }
    }
}