using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class EngineModel : IntegerIdentityBase, IEntity
    {
        public string Name { get; set; }
        public int Fuel { get; set; }
        public int Heat { get; set; }
        public int Power { get; set; }
        public int Reliability { get; set; }
        public int Response { get; set; }
        public int Rigidity { get; set; }
        public int Weight { get; set; }
    }
}