using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GpwEditor.Infrastructure.Catalogues.Commentary;
using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Factories.Catalogues.Commentary
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

            var commentaryCatalogueName = $"{language}CommentaryCatalogue";
            var commentaryCatalogue = _commentaryCatalogues.SingleOrDefault(x => x.Language == language);

            if (commentaryCatalogue == null)
            {
                throw new InvalidOperationException(
                    $"Unable to resolve '{commentaryCatalogueName}'. Make sure the type is registered with the dependency injection container.");
            }

            return commentaryCatalogue;
        }
    }
}