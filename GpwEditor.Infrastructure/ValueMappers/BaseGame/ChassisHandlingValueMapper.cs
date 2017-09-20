namespace GpwEditor.Infrastructure.ValueMappers.BaseGame
{
    public class ChassisHandlingValueMapper : ValueMapperBase
    {
        private const int BaseOffset = 1094126;
        private const int LocalOffset = 30;
        private const int ValueOffset = 0;

        public int Value { get; set; }

        public override void Map()
        {
            base.Map();

            var stepOffset = LocalOffset * GetTeamAlphabeticalId(Id);

            Value = BaseOffset + stepOffset + ValueOffset;
        }
    }
}