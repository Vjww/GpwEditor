using App.BaseGameEditor.Domain.Entities;
using App.WindowsForms.Models;
using AutoMapper;

namespace App.WindowsForms.Maps.AutoMapper
{
    public class PersonEntityOnPersonModelProfile : Profile
    {
        public PersonEntityOnPersonModelProfile()
        {
            // Required due to differences between entity and model when mapping as IEnumerable
            CreateMap<F1DriverEntity, F1DriverModel>()
                .ReverseMap();
        }
    }
}