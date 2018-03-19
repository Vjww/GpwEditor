using System;
using AutoMapper;

namespace App.BaseGameEditor.Application.Maps.AutoMapper.MemberValueResolvers
{
    public class EntityF1DriverPositiveSalaryMemberValueResolver : IMemberValueResolver<object, object, int, int>
    {
        public int Resolve(object source, object destination, int sourceMember, int destMember, ResolutionContext context)
        {
            // TODO: Check whether positive salaries should duplicate to this property or 0.
            return Math.Abs(sourceMember);
        }
    }
}