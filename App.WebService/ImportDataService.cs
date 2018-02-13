using System;
using App.BaseGameEditor.Application.Services;

namespace App.WebService
{
    // TODO: Temporary solution
    public class ImportDataService
    {
        private readonly ApplicationService _service;
        private const string GameFolder = @"C:\gpw";
        private bool _isImported;

        public ImportDataService(ApplicationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Import()
        {
            if (_isImported)
            {
                return;
            }

            _service.Import(
                $@"{GameFolder}",
                $@"{GameFolder}\gpw.exe",
                $@"{GameFolder}\english.txt",
                $@"{GameFolder}\french.txt",
                $@"{GameFolder}\german.txt",
                $@"{GameFolder}\text\comme.txt",
                $@"{GameFolder}\textf\commf.txt",
                $@"{GameFolder}\textg\commg.txt");

            _isImported = true;
        }
    }
}