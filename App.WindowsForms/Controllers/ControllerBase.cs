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

        protected string ConvertStringArrayToRichText(string[] lines)
        {
            var result = string.Empty;

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var item in lines)
            {
                // Add linebreak after each item
                result += item + @"\line ";
            }

            return result.TrimEnd(@"\line".ToCharArray());
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

        protected Icon GetFormIcon()
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

        protected string GetGameFolderPathFromFolderBrowserDialog(EditorForm view)
        {
            // Configure folder browser dialog
            if (Directory.Exists(Settings.Default.MruGameFolderPath))
            {
                view.SetFolderBrowserDialogSelectedPath(Settings.Default.MruGameFolderPath);
            }
            else
            {
                view.SetFolderBrowserDialogRootFolder(Environment.SpecialFolder.Desktop);
            }

            // Get folder from user
            var dialogResult = view.ShowFolderBrowserDialog();

            // Return if no folder was selected
            if (dialogResult != DialogResult.OK) return null;

            var result = view.GetFolderBrowserDialogSelectedPath();

            // Save selected folder
            Settings.Default.MruGameFolderPath = result;
            Settings.Default.Save();

            return result;
        }

        protected string GetGameExecutablePathFromOpenFileDialog(EditorForm view)
        {
            var result = GetFilePathFromOpenFileDialog(view);

            if (string.IsNullOrEmpty(result)) return null;

            Settings.Default.MruGameExecutablePath = result;
            Settings.Default.Save();

            return result;
        }

        protected string GetEnglishLanguageFilePathFromOpenFileDialog(EditorForm view)
        {
            var result = GetFilePathFromOpenFileDialog(view);

            if (string.IsNullOrEmpty(result)) return null;

            Settings.Default.MruEnglishLanguageFilePath = result;
            Settings.Default.Save();

            return result;
        }

        protected string GetFrenchLanguageFilePathFromOpenFileDialog(EditorForm view)
        {
            var result = GetFilePathFromOpenFileDialog(view);

            if (string.IsNullOrEmpty(result)) return null;

            Settings.Default.MruFrenchLanguageFilePath = result;
            Settings.Default.Save();

            return result;
        }

        protected string GetGermanLanguageFilePathFromOpenFileDialog(EditorForm view)
        {
            var result = GetFilePathFromOpenFileDialog(view);

            if (string.IsNullOrEmpty(result)) return null;

            Settings.Default.MruGermanLanguageFilePath = result;
            Settings.Default.Save();

            return result;
        }

        protected string GetEnglishCommentaryFilePathFromOpenFileDialog(EditorForm view)
        {
            var result = GetFilePathFromOpenFileDialog(view);

            if (string.IsNullOrEmpty(result)) return null;

            Settings.Default.MruEnglishCommentaryFilePath = result;
            Settings.Default.Save();

            return result;
        }

        protected string GetFrenchCommentaryFilePathFromOpenFileDialog(EditorForm view)
        {
            var result = GetFilePathFromOpenFileDialog(view);

            if (string.IsNullOrEmpty(result)) return null;

            Settings.Default.MruFrenchCommentaryFilePath = result;
            Settings.Default.Save();

            return result;
        }

        protected string GetGermanCommentaryFilePathFromOpenFileDialog(EditorForm view)
        {
            var result = GetFilePathFromOpenFileDialog(view);

            if (string.IsNullOrEmpty(result)) return null;

            Settings.Default.MruGermanCommentaryFilePath = result;
            Settings.Default.Save();

            return result;
        }

        private string GetFilePathFromOpenFileDialog(EditorForm view)
        {
            // Configure open file dialog
            var initialDirectory = Directory.Exists(Settings.Default.MruGameFolderPath)
                ? Settings.Default.MruGameFolderPath
                : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            view.SetOpenFileDialogInitialDirectory(initialDirectory);
            view.SetOpenFileDialogFileName(null);

            // Get file from user
            var dialogResult = view.ShowOpenFileDialog();

            // Return null if no file was selected, else return filename of selected file
            return dialogResult != DialogResult.OK ? null : view.GetOpenFileDialogFileName();
        }

        protected string GetLaunchGameExecutablePathFromOpenFileDialog(EditorForm view)
        {
            return GetFilePathFromOpenFileDialog(view);
        }

        protected string GetRegistryGameFolderPathFromFolderBrowserDialog(EditorForm view)
        {
            // Configure folder browser dialog
            if (Directory.Exists(Settings.Default.MruGameFolderPath))
            {
                view.SetFolderBrowserDialogSelectedPath(Settings.Default.MruGameFolderPath);
            }
            else
            {
                view.SetFolderBrowserDialogRootFolder(Environment.SpecialFolder.Desktop);
            }

            // Get folder from user
            var dialogResult = view.ShowFolderBrowserDialog();

            // Return null if no folder was selected else return selected path
            return dialogResult != DialogResult.OK ? null : view.GetFolderBrowserDialogSelectedPath();
        }

        protected string GetUserGameFolderPath()
        {
            return Settings.Default.UserGameFolderPath;
        }

        protected string GetUserGameLaunchCommand()
        {
            return Settings.Default.UserGameLaunchCommand;
        }

        protected string GetDefaultGameFolderPath()
        {
            return Settings.Default.DefaultGameFolderPath;
        }

        protected string GetDefaultGameExecutableName()
        {
            return Settings.Default.DefaultGameExecutableName;
        }

        protected bool GetInitialRun()
        {
            return Settings.Default.InitialRun;
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

        protected void SetInitialRun(bool value)
        {
            Settings.Default.InitialRun = value;
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

        protected bool CloseFormConfirmation(EditorForm view, bool isModified, string message)
        {
            // Return true if there are no unsaved changes 
            if (!isModified)
            {
                return true;
            }

            // Prompt user whether to close form with unsaved changes
            return view.ShowConfirmationBox(message);
        }

        protected string GetGameFolderMruOrDefault()
        {
            var defaultPath = GetValueOrDefaultIfNullOrWhiteSpace(Settings.Default.UserGameFolderPath, Settings.Default.DefaultGameFolderPath);
            return GetValueOrDefaultIfNullOrWhiteSpace(Settings.Default.MruGameFolderPath, defaultPath);
        }

        protected string GetGameExecutableMruOrDefault()
        {
            return GetFileMruOrDefault(Settings.Default.DefaultGameExecutableName, Settings.Default.MruGameExecutablePath);
        }

        protected string GetEnglishLanguageFileMruOrDefault()
        {
            return GetFileMruOrDefault(Settings.Default.DefaultEnglishLanguageFileName, Settings.Default.MruEnglishLanguageFilePath);
        }

        protected string GetFrenchLanguageFileMruOrDefault()
        {
            return GetFileMruOrDefault(Settings.Default.DefaultFrenchLanguageFileName, Settings.Default.MruFrenchLanguageFilePath);
        }

        protected string GetGermanLanguageFileMruOrDefault()
        {
            return GetFileMruOrDefault(Settings.Default.DefaultGermanLanguageFileName, Settings.Default.MruGermanLanguageFilePath);
        }

        protected string GetEnglishCommentaryFileMruOrDefault()
        {
            return GetFileMruOrDefault(Settings.Default.DefaultEnglishCommentaryFileName, "text", Settings.Default.MruEnglishCommentaryFilePath);
        }

        protected string GetFrenchCommentaryFileMruOrDefault()
        {
            return GetFileMruOrDefault(Settings.Default.DefaultFrenchCommentaryFileName, "textf", Settings.Default.MruFrenchCommentaryFilePath);
        }

        protected string GetGermanCommentaryFileMruOrDefault()
        {
            return GetFileMruOrDefault(Settings.Default.DefaultGermanCommentaryFileName, "textg", Settings.Default.MruGermanCommentaryFilePath);
        }

        private string GetFileMruOrDefault(string defaultFileName, string mruFilePath)
        {
            var gameFolderPath = GetGameFolderMruOrDefault();
            var defaultFilePath = Path.Combine(gameFolderPath, defaultFileName);
            return GetValueOrDefaultIfNullOrWhiteSpace(mruFilePath, defaultFilePath);
        }

        private string GetFileMruOrDefault(string defaultFileName, string defaultSubFolder, string mruFilePath)
        {
            var gameFolderPath = GetGameFolderMruOrDefault();
            var defaultFilePath = Path.Combine(gameFolderPath, defaultSubFolder, defaultFileName);
            return GetValueOrDefaultIfNullOrWhiteSpace(mruFilePath, defaultFilePath);
        }

        private static string GetValueOrDefaultIfNullOrWhiteSpace(string value, string @default)
        {
            return string.IsNullOrWhiteSpace(value) ? @default : value;
        }
    }
}