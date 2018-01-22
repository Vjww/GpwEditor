﻿using App.BaseGameEditor.Data.EntityExporters;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryExporters
{
    public class ChassisHandlingRepositoryExporter : RepositoryExporterBase
    {
        public ChassisHandlingRepositoryExporter(ChassisHandlingDataEntityExporter dataEntityExporter) : base(dataEntityExporter)
        {
        }
    }
}