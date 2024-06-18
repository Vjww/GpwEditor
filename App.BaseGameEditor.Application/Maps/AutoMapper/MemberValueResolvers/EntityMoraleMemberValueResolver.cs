using App.BaseGameEditor.Application.Services;
using AutoMapper;
using System;

namespace App.BaseGameEditor.Application.Maps.AutoMapper.MemberValueResolvers
{
    public class EntityMoraleMemberValueResolver : IMemberValueResolver<object, object, int, int>
    {
        private readonly ValueConverterService _service;

        public EntityMoraleMemberValueResolver(ValueConverterService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public int Resolve(object source, object destination, int sourceMember, int destMember, ResolutionContext context)
        {
            return _service.ConvertToOneToFiveStepOne(sourceMember);
        }
    }
}
