﻿using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class CarNumberDataExportService
    {
        private readonly IRepository<CarNumberDataEntity> _repository;
        private readonly CarNumberRepositoryExporter _service;

        public CarNumberDataExportService(
            IRepository<CarNumberDataEntity> repository,
            CarNumberRepositoryExporter service)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Export()
        {
            _service.Export(_repository.Get());
        }
    }
}