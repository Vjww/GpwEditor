using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using App.Shared.Data.Catalogues.Commentary;
using App.Shared.Data.Enums;

namespace App.Shared.Data.Factories.Catalogues.Commentary
{
    public class CommentaryCatalogueFactory : ICommentaryCatalogueFactory
    {
        private readonly IEnumerable<ICommentaryCatalogue> _commentaryCatalogues;

        public CommentaryCatalogueFactory(IEnumerable<ICommentaryCatalogue> commentaryCatalogues)
        {
            _commentaryCatalogues = commentaryCatalogues ?? throw new ArgumentNullException(nameof(commentaryCatalogues));
        }

        public ICommentaryCatalogue Create(LanguageType language)
        {
            if (!Enum.IsDefined(typeof(LanguageType), language))
                throw new InvalidEnumArgumentException(nameof(language), (int)language, typeof(LanguageType));

            var name = $"{language}CommentaryCatalogue";
            var result = _commentaryCatalogues.SingleOrDefault(x => x.Language == language);

            if (result == null)
            {
                throw new InvalidOperationException($"Unable to resolve '{name}'. Make sure the type is registered with the dependency injection container.");
            }

            return result;
        }
    }
}