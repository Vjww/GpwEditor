using System;

namespace App.BaseGameEditor.Application.Services
{
    public class ValueConverterService
    {
        /// <summary>
        /// Converts the values 20, 40, 60, 80, 100 to 1, 2, 3, 4 or 5.
        /// </summary>
        /// <param name="value">The integer value to convert.</param>
        /// <returns>Returns converted value.</returns>
        public int ConvertToOneToFiveStepOne(int value)
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
                    throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        /// <summary>
        /// Converts the values 1, 2, 3, 4, 5 to 20, 40, 60, 80 or 100.
        /// </summary>
        /// <param name="value">The integer value to convert.</param>
        /// <returns>Returns converted value.</returns>
        public int ConvertToTwentyToHundredStepTwenty(int value)
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
                    throw new ArgumentOutOfRangeException(nameof(value));
            }
        }
    }
}