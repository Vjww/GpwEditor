using System;
using System.Collections.Generic;
using App.BaseGameEditor.Application.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Services;
using App.Console.ViewModels;
using App.Console.Views;

namespace App.Console.Controllers
{
    public class SupplierController
    {
        private readonly ApplicationService _service;
        private readonly EngineView _engineView;
        private readonly TyreView _tyreView;
        private readonly FuelView _fuelView;
        private readonly IMapperService _mapper;

        public SupplierController(
            ApplicationService service,
            EngineView engineView,
            TyreView tyreView,
            FuelView fuelView,
            IMapperService mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _engineView = engineView ?? throw new ArgumentNullException(nameof(engineView));
            _tyreView = tyreView ?? throw new ArgumentNullException(nameof(tyreView));
            _fuelView = fuelView ?? throw new ArgumentNullException(nameof(fuelView));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void DisplaySuppliers()
        {
            DisplayEngines();
            DisplayTyres();
            DisplayFuels();
        }

        private void DisplayEngines()
        {
            var entities = _service.DomainModel.Suppliers.GetEngines();
            var viewModel = _mapper.Map<IEnumerable<EngineEntity>, IEnumerable<EngineViewModel>>(entities);
            _engineView.Display(viewModel);
        }

        private void DisplayTyres()
        {
            var entities = _service.DomainModel.Suppliers.GetTyres();
            var viewModel = _mapper.Map<IEnumerable<TyreEntity>, IEnumerable<TyreViewModel>>(entities);
            _tyreView.Display(viewModel);
        }

        private void DisplayFuels()
        {
            var entities = _service.DomainModel.Suppliers.GetFuels();
            var viewModel = _mapper.Map<IEnumerable<FuelEntity>, IEnumerable<FuelViewModel>>(entities);
            _fuelView.Display(viewModel);
        }
    }
}