namespace GpwEditor.Infrastructure.Mappers.BaseGame
{
    public class TeamMapper : MapperBase
    {
        private const int NameOffset = 5696 + 1; // "No Team" -> "Williams"

        public int Name { get; set; }

        public override void Map()
        {
            base.Map();

            Name = NameOffset + Id;
        }
    }
}