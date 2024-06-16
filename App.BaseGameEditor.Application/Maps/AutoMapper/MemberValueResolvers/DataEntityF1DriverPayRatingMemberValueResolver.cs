using App.BaseGameEditor.Domain.Services;
using AutoMapper;
using System;

namespace App.BaseGameEditor.Application.Maps.AutoMapper.MemberValueResolvers
{
    public class DataEntityF1DriverPayRatingMemberValueResolver : IMemberValueResolver<object, object, int, int>
    {
        private readonly PayDriverRatingService _service;

        public DataEntityF1DriverPayRatingMemberValueResolver(PayDriverRatingService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public int Resolve(object source, object destination, int sourceMember, int destMember, ResolutionContext context)
        {
            // Calculate rating, if salary value is negative (for pay driver), else return 0 (for paid driver)
            return sourceMember < 0 ? _service.Calculate(sourceMember) : 0;
        }
    }
}
