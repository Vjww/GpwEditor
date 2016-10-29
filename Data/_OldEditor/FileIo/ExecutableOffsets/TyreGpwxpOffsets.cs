namespace Common.DataAccess.ExecutableOffsets
{
    class TyreGpwxpOffsets
    {
        // Goodyear (1)
        // Attributes for engineering module	B1424689 - S135 - A19
        // Attributes for business module     	B1424775 - S135 - A10

        // Bridgestone (2)
        // Attributes for engineering module	B1424144 - S135 - A19
        // Attributes for business module     	B1424230 - S135 - A10

        // Michelin (3)
        // Attributes for engineering module	B1425234 - S95  - A19
        // Attributes for business module     	B1425610 - S40  - A10

        // B = Base offset (3x tyre suppliers)
        // S = Struct offset (4x compounds per supplier)
        // A = Attribute offset (4x attributes per compound)

        // a vs b = tyre attributes in engineering vs business modules
        // note goodyear base offsets are later in the file than the bridgestone base offsets

        public const int OffsetBase1a = 1424689;
        public const int OffsetBase1b = 1424775;
        public const int OffsetBase2a = 1424144;
        public const int OffsetBase2b = 1424230;
        public const int OffsetBase3a = 1425234;
        public const int OffsetBase3b = 1425610;
        public const int OffsetStruct1a = 135;
        public const int OffsetStruct1b = 135;
        public const int OffsetStruct2a = 135;
        public const int OffsetStruct2b = 135;
        public const int OffsetStruct3a = 95;
        public const int OffsetStruct3b = 40;
        public const int OffsetAttribute1a = 19;
        public const int OffsetAttribute1b = 10;
        public const int OffsetAttribute2a = 19;
        public const int OffsetAttribute2b = 10;
        public const int OffsetAttribute3a = 19;
        public const int OffsetAttribute3b = 10;
    }
}
