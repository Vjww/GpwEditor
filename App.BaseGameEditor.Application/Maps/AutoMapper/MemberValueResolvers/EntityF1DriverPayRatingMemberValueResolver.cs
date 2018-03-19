using System;
using App.BaseGameEditor.Domain.Services;
using AutoMapper;

namespace App.BaseGameEditor.Application.Maps.AutoMapper.MemberValueResolvers
{
    public class EntityF1DriverPayRatingMemberValueResolver : IMemberValueResolver<object, object, int, int>
    {
        private readonly PayDriverRatingService _service;

        public EntityF1DriverPayRatingMemberValueResolver(PayDriverRatingService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public int Resolve(object source, object destination, int sourceMember, int destMember, ResolutionContext context)
        {
            // TODO: Check whether only negative salaries should be rated or positive salaries as well.
            return _service.Calculate(sourceMember);
        }
    }
}