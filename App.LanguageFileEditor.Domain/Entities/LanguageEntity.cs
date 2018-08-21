using App.Core.Entities;
using App.Core.Identities;

namespace App.LanguageFileEditor.Domain.Entities
{
    public class LanguageEntity : IntegerIdentityBase, IEntity
    {
        public string Index { get; set; }
        public string EnglishValue { get; set; }
        public string FrenchValue { get; set; }
        public string GermanValue { get; set; }
    }
}