using System;
using System.Windows.Forms;
using App.Shared.Infrastructure.Services;
using App.WindowsForms.Factories;
using App.WindowsForms.Properties;
using App.WindowsForms.Services;
using App.WindowsForms.Views;

namespace App.WindowsForms.Controllers
{
    public class SettingsEditorController : ControllerBase
    {
        private SettingsEditorForm _view;

        private readonly FormFactory _formFactory;
        private readonly GameRegistryKeyService _gameRegistryKeyService;

        public SettingsEditorController(
            IMapperService mapperService,
            FormFactory formFactory,
            GameRegistryKeyService gameRegistryKeyService)
            : base(mapperService)
        {
            _formFactory = formFactory ?? throw new ArgumentNullException(nameof(formFactory));
            _gameRegistryKeyService = gameRegistryKeyService ?? throw new ArgumentNullException(nameof(gameRegistryKeyService));

            _gameRegistryKeyService.SetRootKey(Settings.Default.RegistryKey);
        }

        public void Run(Form parentView)
        {
            _view = _formFactory.Create<SettingsEditorForm>();
            _view.SetController(this);
            ShowView(parentView, _view);
        }

        public bool DoGameRegistryKeysExist()
        {
            return _gameRegistryKeyService.IsRegistryReadable() && _gameRegistryKeyService.DoKeysExist();
        }

        public void InstallRegistryKeys()
        {
            _gameRegistryKeyService.CreateKeys();
        }

        public bool IsRegistryWritable()
        {
            return _gameRegistryKeyService.IsRegistryWritable();
        }

        public void UpdateRegistryModelFromRegistryValues()
        {
            _gameRegistryKeyService.ReadKeys();

            _view.InstallValue = _gameRegistryKeyService.InstallValue;
            _view.LanguageValue = _gameRegistryKeyService.LanguageValue.ToString();
            _view.PathValue = _gameRegistryKeyService.PathValue;
            _view.ValidValue = _gameRegistryKeyService.ValidValue.ToString();
        }

        public void UpdateRegistryValuesFromRegistryModel()
        {
            _gameRegistryKeyService.InstallValue = _view.InstallValue;
            _gameRegistryKeyService.LanguageValue = Convert.ToInt32(_view.LanguageValue);
            _gameRegistryKeyService.PathValue = _view.PathValue;
            _gameRegistryKeyService.ValidValue = Convert.ToInt32(_view.ValidValue);

            _gameRegistryKeyService.WriteKeys();
        }
    }
}