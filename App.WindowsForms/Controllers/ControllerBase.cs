using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using App.Shared.Infrastructure.Services;
using App.WindowsForms.Properties;
using App.WindowsForms.Views;

namespace App.WindowsForms.Controllers
{
    public abstract class ControllerBase
    {
        protected readonly IMapperService MapperService;

        protected ControllerBase(IMapperService mapperService)
        {
            MapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public string GetApplicationName()
        {
            return Settings.Default.ApplicationName;
        }

        public string GetApplicationVersion()
        {
            if (Debugger.IsAttached)
            {
                return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            }

            return System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed
                ? System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(2)
                : FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
        }

        public Icon GetFormIcon()
        {
            return Resources.icon1;
        }

        public string GetGameName()
        {
            return Settings.Default.GameName;
        }

        public string GetGameRegistryKey()
        {
            return string.Concat(@"HKEY_LOCAL_MACHINE\", Settings.Default.RegistryKey);
        }

        // TODO: Duplicated in EditorForm, this entry takes precedence
        public string GetGameFolderPathFromFolderBrowserDialog(FolderBrowserDialog folderBrowserDialog)
        {
            // Configure folder browser dialog
            if (Directory.Exists(Settings.Default.MruGameFolderPath))
            {
                folderBrowserDialog.SelectedPath = Settings.Default.MruGameFolderPath;
            }
            else
            {
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            }

            // Get folder from user
            var dialogResult = folderBrowserDialog.ShowDialog();

            // Return if no folder was selected
            if (dialogResult != DialogResult.OK) return null;

            // Save selected folder
            Settings.Default.MruGameFolderPath = folderBrowserDialog.SelectedPath;
            Settings.Default.Save();

            return Settings.Default.MruGameFolderPath;
        }

        // TODO: Duplicated in EditorForm, this entry takes precedence
        public string GetGameExecutablePathFromOpenFileDialog(OpenFileDialog openFileDialog)
        {
            var result = GetFilePathFromOpenFileDialog(openFileDialog);

            if (string.IsNullOrEmpty(result)) return null;

            Settings.Default.MruGameExecutablePath = result;
            Settings.Default.Save();

            return result;
        }

        // TODO: Duplicated in EditorForm, this entry takes precedence
        private static string GetFilePathFromOpenFileDialog(FileDialog openFileDialog)
        {
            // Configure open file dialog
            openFileDialog.InitialDirectory = Directory.Exists(Settings.Default.MruGameFolderPath)
                ? Settings.Default.MruGameFolderPath
                : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.FileName = null;

            // Get file from user
            var dialogResult = openFileDialog.ShowDialog();

            // Return null if no file was selected, else return filename of selected file
            return dialogResult != DialogResult.OK ? null : openFileDialog.FileName;
        }

        public string GetUserGameFolderPath()
        {
            return Settings.Default.UserGameFolderPath;
        }

        public string GetUserGameLaunchCommand()
        {
            return Settings.Default.UserGameLaunchCommand;
        }

        public void SetUserGameFolderPath(string path)
        {
            Settings.Default.UserGameFolderPath = path;
            Settings.Default.Save();
        }

        public void SetUserGameLaunchCommand(string command)
        {
            Settings.Default.UserGameLaunchCommand = command;
            Settings.Default.Save();
        }

        protected void ShowView(Form parentView, EditorForm childView)
        {
            childView.FormClosing += delegate { parentView.Show(); };
            childView.Show(parentView);
            parentView.Hide();
        }

        protected TU UpdateModelFromService<T, TU>(Func<T> service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));

            var entities = service.Invoke();
            return MapperService.Map<T, TU>(entities);
        }

        protected void UpdateServiceFromModel<T, TU>(Action<TU> service, T model)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entities = MapperService.Map<T, TU>(model);
            service.Invoke(entities);
        }
    }
}