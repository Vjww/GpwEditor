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

        public void ChangeGameFolder()
        {
            try
            {
                // Prompt user to select game folder and store original/changed selection
                var result = GetGameFolderPathFromFolderBrowserDialog(_view);
                _view.GameFolderText = string.IsNullOrEmpty(result) ? _view.GameFolderText : result;

                // Update service
                SetUserGameFolderPath(_view.GameFolderText);
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeLaunchGame()
        {
            try
            {
                // Prompt user to select game executable and store original/changed selection
                var result = GetLaunchGameExecutablePathFromOpenFileDialog(_view);
                _view.LaunchGameText = string.IsNullOrEmpty(result) ? _view.LaunchGameText : result;

                // Update service
                SetUserGameLaunchCommand(_view.LaunchGameText);
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeRegistryGameFolder()
        {
            try
            {
                if (!_gameRegistryKeyService.IsRegistryWritable())
                {
                    _view.ShowErrorBox("Unable to alter the registry key values due to insufficient permissions.");
                    return;
                }

                // Prompt user to select game folder and store original/changed selection
                var result = GetRegistryGameFolderPathFromFolderBrowserDialog(_view);
                _view.RegistryPathValueText = string.IsNullOrEmpty(result) ? _view.RegistryPathValueText : result;

                // Update service
                UpdateRegistryServiceFromViewModel();
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void InstallRegistryKeys()
        {
            try
            {
                // Install keys
                _gameRegistryKeyService.CreateKeys();

                // Update viewmodel
                UpdateRegistryViewModelFromService();

                // Change context to display installed keys
                _view.HideRegistryKeysInstallPanel();
                _view.ShowRegistryKeysPanel();
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void LoadView()
        {
            _view.SetFormIcon(GetFormIcon());
            _view.SetFormText($"{GetApplicationName()} - Settings");
            _view.SetRichTextBoxRichText(ConvertStringArrayToRichText(_view.GetRichTextBoxLines()));

            _view.GameFolderText = GetUserGameFolderPath();
            _view.LaunchGameText = GetUserGameLaunchCommand();
            _view.RegistryKeyText = GetGameRegistryKey();

            _view.FormatGameFolderDescriptionLabelText(GetApplicationName());
            _view.FormatLaunchGameDescriptionLabelText(GetApplicationName());
            _view.FormatRegistryKeysDescriptionLabelText(GetApplicationName(), GetGameName(), GetGameRegistryKey());

            // Determine context to display
            if (DoGameRegistryKeysExist())
            {
                UpdateRegistryViewModelFromService();
                _view.ShowRegistryKeysPanel();
            }
            else
            {
                _view.ShowRegistryKeysInstallPanel();
            }
        }

        public void ResetRegistryKeys()
        {
            try
            {
                if (!_gameRegistryKeyService.IsRegistryWritable())
                {
                    _view.ShowErrorBox("Unable to alter the registry key values due to insufficient permissions.");
                    return;
                }

                // Reset keys
                _gameRegistryKeyService.CreateKeys();

                // Update viewmodel
                UpdateRegistryViewModelFromService();
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void Run(Form parentView)
        {
            _view = _formFactory.Create<SettingsEditorForm>();
            _view.SetController(this);
            ShowView(parentView, _view);
        }

        private bool DoGameRegistryKeysExist()
        {
            return _gameRegistryKeyService.IsRegistryReadable() && _gameRegistryKeyService.DoKeysExist();
        }

        private void UpdateRegistryViewModelFromService()
        {
            _gameRegistryKeyService.ReadKeys();

            _view.RegistryInstallValueText = _gameRegistryKeyService.InstallValue;
            _view.RegistryLanguageValueText = _gameRegistryKeyService.LanguageValue.ToString();
            _view.RegistryPathValueText = _gameRegistryKeyService.PathValue;
            _view.RegistryValidValueText = _gameRegistryKeyService.ValidValue.ToString();
        }

        private void UpdateRegistryServiceFromViewModel()
        {
            _gameRegistryKeyService.InstallValue = _view.RegistryInstallValueText;
            _gameRegistryKeyService.LanguageValue = Convert.ToInt32(_view.RegistryLanguageValueText);
            _gameRegistryKeyService.PathValue = _view.RegistryPathValueText;
            _gameRegistryKeyService.ValidValue = Convert.ToInt32(_view.RegistryValidValueText);

            _gameRegistryKeyService.WriteKeys();
        }
    }
}