using System;
using App.BaseGameEditor.Infrastructure.Services;
using AutoMapper;

namespace App.ObjectMapping.Maps.AutoMapper
{
    public class DataEntityMoraleMemberValueResolver : IMemberValueResolver<object, object, int, int>
    {
        private readonly ValueConverterService _service;

        public DataEntityMoraleMemberValueResolver(ValueConverterService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public int Resolve(object source, object destination, int sourceMember, int destMember, ResolutionContext context)
        {
            return _service.ConvertToTwentyToHundredStepTwenty(sourceMember);
        }
    }
}