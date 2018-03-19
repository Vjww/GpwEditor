using System;

namespace App.BaseGameEditor.Domain.Services
{
    public class PayDriverRatingService
    {
        public int Calculate(int value)
        {
            // Default salary ratings ($million)
            //   Level 1: 2.6 - 3.5
            //   Level 2: 3.6 - 4.5
            //   Level 3: 5.6 - 6.5
            //   Level 4: 7.6 - 8.5
            //   Level 5: 9.6 - 10.5

            var salary = Math.Abs(value);

            if (salary < 3600000) return 1;
            if (salary < 5600000) return 2;
            if (salary < 7600000) return 3;
            return salary < 9600000 ? 4 : 5;
        }
    }
}