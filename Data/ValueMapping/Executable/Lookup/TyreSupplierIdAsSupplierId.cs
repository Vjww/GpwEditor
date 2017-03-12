namespace Data.ValueMapping.Executable.Lookup
{
    public class TyreSupplierIdAsSupplierId : ILookup
    {
        private const int NameIndex = 4883; // "TyreA"

        public int Name { get; set; }

        public TyreSupplierIdAsSupplierId(int id)
        {
            Name = NameIndex + GetLocalResourceId(id) - 8;
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    8, 9, 10
                };

            return idToResourceIdMap[id];
        }
    }
}
