using System;
using AutoMapper;

namespace App.BaseGameEditor.Application.Maps.AutoMapper.MemberValueResolvers
{
    public class EntityF1DriverPositiveSalaryMemberValueResolver : IMemberValueResolver<object, object, int, int>
    {
        public int Resolve(object source, object destination, int sourceMember, int destMember, ResolutionContext context)
        {
            // TODO: Check whether only negative salaries should be flipped or positive salaries as well.

            // Calculate positive salary if value is negative (for pay driver), else return 0 (for paid driver)
            return sourceMember < 0 ? Math.Abs(sourceMember) : 0;
        }
    }
}