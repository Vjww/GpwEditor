using Data.Entities.EntityTypes;
using Data.ValueMapping.MappingTypes;

namespace Data.Entities.Executable.Environment.StaffSalaries
{
    public class Commercial : FiveLevelValueTypeBase
    {
        public Commercial(string name, IFiveLevelMappingType valueMapping) : base(name, valueMapping)
        {
            //
        }
    }
}
