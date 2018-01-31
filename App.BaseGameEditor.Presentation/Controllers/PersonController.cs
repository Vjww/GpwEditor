using System;
using System.Collections.Generic;
using App.BaseGameEditor.Application.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Services;
using App.BaseGameEditor.Presentation.ViewModels;
using App.BaseGameEditor.Presentation.Views;

namespace App.BaseGameEditor.Presentation.Controllers
{
    public class PersonController
    {
        private readonly ApplicationService _service;
        private readonly F1ChiefCommercialView _f1ChiefCommercialView;
        private readonly IMapperService _mapper;

        public PersonController(
            ApplicationService service,
            F1ChiefCommercialView f1ChiefCommercialView,
            IMapperService mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _f1ChiefCommercialView = f1ChiefCommercialView ?? throw new ArgumentNullException(nameof(f1ChiefCommercialView));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void DisplayPersons()
        {
            DisplayF1ChiefCommercials();
        }

        private void DisplayF1ChiefCommercials()
        {
            var entities = _service.DomainModel.Persons.GetF1ChiefCommercials();
            var viewModel = _mapper.Map<IEnumerable<F1ChiefCommercialEntity>, IEnumerable<F1ChiefCommercialViewModel>>(entities);
            _f1ChiefCommercialView.Display(viewModel);
        }
    }
}