using System;

namespace Core.Extensions
{
    public static class IntExt
    {
        /// <summary>
        /// Builds a string table id from an integer value.
        /// </summary>
        /// <param name="id">The string table identifier.</param>
        /// <returns>Returns "SID000000"</returns>
        public static string BuildStringTableId(this int id)
        {
            return "SID" + id.ToString("D6");
        }

        /// <summary>
        /// Validates the value as 0, 1, 2, 3, 4 or 5.
        /// </summary>
        /// <param name="value">The integer value to validate.</param>
        /// <returns>Returns true when value is valid.</returns>
        public static bool ValidateAsZeroToFiveStepOne(this int value)
        {
            switch (value)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Validates the value as 1, 2, 3, 4 or 5.
        /// </summary>
        /// <param name="value">The integer value to validate.</param>
        /// <returns>Returns true when value is valid.</returns>
        public static bool ValidateAsOneToFiveStepOne(this int value)
        {
            switch (value)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Validates the value as 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 or 10.
        /// </summary>
        /// <param name="value">The integer value to validate.</param>
        /// <returns>Returns true when value is valid.</returns>
        public static bool ValidateAsZeroToTenStepOne(this int value)
        {
            switch (value)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Validates the value as 1, 2, 3, 4, 5, 6, 7, 8, 9 or 10.
        /// </summary>
        /// <param name="value">The integer value to validate.</param>
        /// <returns>Returns true when value is valid.</returns>
        public static bool ValidateAsOneToTenStepOne(this int value)
        {
            switch (value)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Validates the value as 0, 20, 40, 60, 80 or 100.
        /// </summary>
        /// <param name="value">The integer value to validate.</param>
        /// <returns>Returns true when value is valid.</returns>
        public static bool ValidateAsZeroToHundredStepTwenty(this int value)
        {
            switch (value)
            {
                case 0:
                case 20:
                case 40:
                case 60:
                case 80:
                case 100:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Validates the value as 20, 40, 60, 80 or 100.
        /// </summary>
        /// <param name="value">The integer value to validate.</param>
        /// <returns>Returns true when value is valid.</returns>
        public static bool ValidateAsTwentyToHundredStepTwenty(this int value)
        {
            switch (value)
            {
                case 20:
                case 40:
                case 60:
                case 80:
                case 100:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Converts the values 20, 40, 60, 80, 100 to 1, 2, 3, 4 or 5.
        /// </summary>
        /// <param name="value">The integer value to convert.</param>
        /// <returns>Returns converted value.</returns>
        public static int ConvertToOneToFiveStepOne(this int value)
        {
            switch (value)
            {
                case 20:
                    return 1;
                case 40:
                    return 2;
                case 60:
                    return 3;
                case 80:
                    return 4;
                case 100:
                    return 5;
                default:
                    throw new NotImplementedException("Value not handled by switch statement.");
            }
        }

        /// <summary>
        /// Converts the values 1, 2, 3, 4, 5 to 20, 40, 60, 80 or 100.
        /// </summary>
        /// <param name="value">The integer value to convert.</param>
        /// <returns>Returns converted value.</returns>
        public static int ConvertToTwentyToHundredStepTwenty(this int value)
        {
            switch (value)
            {
                case 1:
                    return 20;
                case 2:
                    return 40;
                case 3:
                    return 60;
                case 4:
                    return 80;
                case 5:
                    return 100;
                default:
                    throw new NotImplementedException("Value not handled by switch statement.");
            }
        }
    }
}
