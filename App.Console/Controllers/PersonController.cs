using System;
using System.Collections.Generic;
using App.BaseGameEditor.Application.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Services;
using App.Console.ViewModels;
using App.Console.Views;

namespace App.Console.Controllers
{
    public class PersonController
    {
        private readonly ApplicationService _service;
        private readonly F1ChiefCommercialView _f1ChiefCommercialView;
        private readonly F1ChiefDesignerView _f1ChiefDesignerView;
        private readonly F1ChiefEngineerView _f1ChiefEngineerView;
        private readonly F1ChiefMechanicView _f1ChiefMechanicView;
        private readonly F1DriverView _f1DriverView;
        private readonly NonF1ChiefCommercialView _nonF1ChiefCommercialView;
        private readonly NonF1ChiefDesignerView _nonF1ChiefDesignerView;
        private readonly NonF1ChiefEngineerView _nonF1ChiefEngineerView;
        private readonly NonF1ChiefMechanicView _nonF1ChiefMechanicView;
        private readonly NonF1DriverView _nonF1DriverView;
        private readonly IMapperService _mapper;

        public PersonController(
            ApplicationService service,
            F1ChiefCommercialView f1ChiefCommercialView,
            F1ChiefDesignerView f1ChiefDesignerView,
            F1ChiefEngineerView f1ChiefEngineerView,
            F1ChiefMechanicView f1ChiefMechanicView,
            F1DriverView f1DriverView,
            NonF1ChiefCommercialView nonF1ChiefCommercialView,
            NonF1ChiefDesignerView nonF1ChiefDesignerView,
            NonF1ChiefEngineerView nonF1ChiefEngineerView,
            NonF1ChiefMechanicView nonF1ChiefMechanicView,
            NonF1DriverView nonF1DriverView,
            IMapperService mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _f1ChiefCommercialView = f1ChiefCommercialView ?? throw new ArgumentNullException(nameof(f1ChiefCommercialView));
            _f1ChiefDesignerView = f1ChiefDesignerView ?? throw new ArgumentNullException(nameof(f1ChiefDesignerView));
            _f1ChiefEngineerView = f1ChiefEngineerView ?? throw new ArgumentNullException(nameof(f1ChiefEngineerView));
            _f1ChiefMechanicView = f1ChiefMechanicView ?? throw new ArgumentNullException(nameof(f1ChiefMechanicView));
            _f1DriverView = f1DriverView ?? throw new ArgumentNullException(nameof(f1DriverView));
            _nonF1ChiefCommercialView = nonF1ChiefCommercialView ?? throw new ArgumentNullException(nameof(nonF1ChiefCommercialView));
            _nonF1ChiefDesignerView = nonF1ChiefDesignerView ?? throw new ArgumentNullException(nameof(nonF1ChiefDesignerView));
            _nonF1ChiefEngineerView = nonF1ChiefEngineerView ?? throw new ArgumentNullException(nameof(nonF1ChiefEngineerView));
            _nonF1ChiefMechanicView = nonF1ChiefMechanicView ?? throw new ArgumentNullException(nameof(nonF1ChiefMechanicView));
            _nonF1DriverView = nonF1DriverView ?? throw new ArgumentNullException(nameof(nonF1DriverView));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void DisplayPersons()
        {
            DisplayF1ChiefCommercials();
            DisplayF1ChiefDesigners();
            DisplayF1ChiefEngineers();
            DisplayF1ChiefMechanics();
            DisplayF1Drivers();
            DisplayNonF1ChiefCommercials();
            DisplayNonF1ChiefDesigners();
            DisplayNonF1ChiefEngineers();
            DisplayNonF1ChiefMechanics();
            DisplayNonF1Drivers();
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

        private void DisplayNonF1ChiefCommercials()
        {
            var entities = _service.DomainModel.Persons.GetNonF1ChiefCommercials();
            var viewModel = _mapper.Map<IEnumerable<NonF1ChiefCommercialEntity>, IEnumerable<NonF1ChiefCommercialViewModel>>(entities);
            _nonF1ChiefCommercialView.Display(viewModel);
        }

        private void DisplayNonF1ChiefDesigners()
        {
            var entities = _service.DomainModel.Persons.GetNonF1ChiefDesigners();
            var viewModel = _mapper.Map<IEnumerable<NonF1ChiefDesignerEntity>, IEnumerable<NonF1ChiefDesignerViewModel>>(entities);
            _nonF1ChiefDesignerView.Display(viewModel);
        }

        private void DisplayNonF1ChiefEngineers()
        {
            var entities = _service.DomainModel.Persons.GetNonF1ChiefEngineers();
            var viewModel = _mapper.Map<IEnumerable<NonF1ChiefEngineerEntity>, IEnumerable<NonF1ChiefEngineerViewModel>>(entities);
            _nonF1ChiefEngineerView.Display(viewModel);
        }

        private void DisplayNonF1ChiefMechanics()
        {
            var entities = _service.DomainModel.Persons.GetNonF1ChiefMechanics();
            var viewModel = _mapper.Map<IEnumerable<NonF1ChiefMechanicEntity>, IEnumerable<NonF1ChiefMechanicViewModel>>(entities);
            _nonF1ChiefMechanicView.Display(viewModel);
        }

        private void DisplayNonF1Drivers()
        {
            var entities = _service.DomainModel.Persons.GetNonF1Drivers();
            var viewModel = _mapper.Map<IEnumerable<NonF1DriverEntity>, IEnumerable<NonF1DriverViewModel>>(entities);
            _nonF1DriverView.Display(viewModel);
        }
    }
}