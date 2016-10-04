namespace Data.Extensions
{
    public static class StringExt
    {
        public static bool ValidateAsInteger(this string value)
        {
            int result;
            return int.TryParse(value, out result);
        }
    }
}
