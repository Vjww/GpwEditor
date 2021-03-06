﻿using System;
using App.Core.Repositories;
using App.LanguageFileEditor.Data.DataEntities;
using App.Shared.Data.Services;

namespace App.LanguageFileEditor.Data.Services
{
    public class DataService
    {
        private readonly IRepositoryExportService<LanguageDataEntity> _languageRepositoryExportService;
        private readonly IRepositoryImportService<LanguageDataEntity> _languageRepositoryImportService;

        public IRepository<LanguageDataEntity> Languages { get; }

        public DataService(
            IRepositoryExportService<LanguageDataEntity> languageRepositoryExportService,
            IRepositoryImportService<LanguageDataEntity> languageRepositoryImportService,
            IRepository<LanguageDataEntity> languageRepository)
        {
            _languageRepositoryExportService = languageRepositoryExportService ?? throw new ArgumentNullException(nameof(languageRepositoryExportService));
            _languageRepositoryImportService = languageRepositoryImportService ?? throw new ArgumentNullException(nameof(languageRepositoryImportService));

            Languages = languageRepository ?? throw new ArgumentNullException(nameof(languageRepository));
        }

        public void Export()
        {
            _languageRepositoryExportService.Export();
        }

        public void Import()
        {
            _languageRepositoryImportService.Import(7173);
        }
    }
}