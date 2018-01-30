﻿using App.BaseGameEditor.Data.DataEntityExporters;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryExporters
{
    public class CarNumberRepositoryExporter : RepositoryExporterBase
    {
        public CarNumberRepositoryExporter(CarNumberDataEntityExporter dataEntityExporter) : base(dataEntityExporter)
        {
        }
    }
}