using AutoMapper;
using System;

namespace App.BaseGameEditor.Application.Maps.AutoMapper.MemberValueResolvers
{
    public class DataEntityF1DriverPositiveSalaryMemberValueResolver : IMemberValueResolver<object, object, int, int>
    {
        public int Resolve(object source, object destination, int sourceMember, int destMember, ResolutionContext context)
        {
            // Calculate positive salary, if salary value is negative (for pay driver), else return 0 (for paid driver)
            return sourceMember < 0 ? Math.Abs(sourceMember) : 0;
        }
    }
}
