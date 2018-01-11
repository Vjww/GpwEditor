//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using App.BaseGameEditor.Data.Catalogues.Commentary;
//using App.BaseGameEditor.Data.Enums;

//namespace App.BaseGameEditor.Data.Factories
//{
//    public class CommentaryCatalogueFactory
//    {
//        private readonly IEnumerable<ICommentaryCatalogue> _commentaryCatalogues;

//        public CommentaryCatalogueFactory(IEnumerable<ICommentaryCatalogue> commentaryCatalogues)
//        {
//            _commentaryCatalogues = commentaryCatalogues ?? throw new ArgumentNullException(nameof(commentaryCatalogues));
//        }

//        public ICommentaryCatalogue Create(LanguageType language)
//        {
//            if (!Enum.IsDefined(typeof(LanguageType), language))
//                throw new InvalidEnumArgumentException(nameof(language), (int)language, typeof(LanguageType));

//            var name = $"{language}CommentaryCatalogue";
//            var result = _commentaryCatalogues.SingleOrDefault(x => x.Language == language);

//            if (result == null)
//            {
//                throw new InvalidOperationException($"Unable to resolve '{name}'. Make sure the type is registered with the dependency injection container.");
//            }

//            return result;
//        }
//    }
//}