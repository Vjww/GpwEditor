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
        private readonly F1ChiefDesignerView _f1ChiefDesignerView;
        private readonly F1ChiefEngineerView _f1ChiefEngineerView;
        private readonly F1ChiefMechanicView _f1ChiefMechanicView;
        private readonly F1DriverView _f1DriverView;
        private readonly IMapperService _mapper;

        public PersonController(
            ApplicationService service,
            F1ChiefCommercialView f1ChiefCommercialView,
            F1ChiefDesignerView f1ChiefDesignerView,
            F1ChiefEngineerView f1ChiefEngineerView,
            F1ChiefMechanicView f1ChiefMechanicView,
            F1DriverView f1DriverView,
            IMapperService mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _f1ChiefCommercialView = f1ChiefCommercialView ?? throw new ArgumentNullException(nameof(f1ChiefCommercialView));
            _f1ChiefDesignerView = f1ChiefDesignerView ?? throw new ArgumentNullException(nameof(f1ChiefDesignerView));
            _f1ChiefEngineerView = f1ChiefEngineerView ?? throw new ArgumentNullException(nameof(f1ChiefEngineerView));
            _f1ChiefMechanicView = f1ChiefMechanicView ?? throw new ArgumentNullException(nameof(f1ChiefMechanicView));
            _f1DriverView = f1DriverView ?? throw new ArgumentNullException(nameof(f1DriverView));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void DisplayPersons()
        {
            DisplayF1ChiefCommercials();
            DisplayF1ChiefDesigners();
            DisplayF1ChiefEngineers();
            DisplayF1ChiefMechanics();
            DisplayF1Drivers();
        }

        private void DisplayF1ChiefCommercials()
        {
            var entities = _service.DomainModel.Persons.GetF1ChiefCommercials();
            var viewModel = _mapper.Map<IEnumerable<F1ChiefCommercialEntity>, IEnumerable<F1ChiefCommercialViewModel>>(entities);
            _f1ChiefCommercialView.Display(viewModel);
        }

        private void DisplayF1ChiefDesigners()
        {
            var entities = _service.DomainModel.Persons.GetF1ChiefDesigners();
            var viewModel = _mapper.Map<IEnumerable<F1ChiefDesignerEntity>, IEnumerable<F1ChiefDesignerViewModel>>(entities);
            _f1ChiefDesignerView.Display(viewModel);
        }

        private void DisplayF1ChiefEngineers()
        {
            var entities = _service.DomainModel.Persons.GetF1ChiefEngineers();
            var viewModel = _mapper.Map<IEnumerable<F1ChiefEngineerEntity>, IEnumerable<F1ChiefEngineerViewModel>>(entities);
            _f1ChiefEngineerView.Display(viewModel);
        }

        private void DisplayF1ChiefMechanics()
        {
            var entities = _service.DomainModel.Persons.GetF1ChiefMechanics();
            var viewModel = _mapper.Map<IEnumerable<F1ChiefMechanicEntity>, IEnumerable<F1ChiefMechanicViewModel>>(entities);
            _f1ChiefMechanicView.Display(viewModel);
        }

        private void DisplayF1Drivers()
        {
            var entities = _service.DomainModel.Persons.GetF1Drivers();
            var viewModel = _mapper.Map<IEnumerable<F1DriverEntity>, IEnumerable<F1DriverViewModel>>(entities);
            _f1DriverView.Display(viewModel);
        }
    }
}