using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class LanguageModel : IntegerIdentityBase, IEntity
    {
        public string Index { get; set; }
        public string EnglishValue { get; set; }
        public string FrenchValue { get; set; }
        public string GermanValue { get; set; }
    }
}