using System;
using GpwEditor.Properties;
using Microsoft.Win32;

namespace GpwEditor.Registry
{
    public class GpwRegistryKeys
    {
        public const string InstallKey = "INSTALL";
        public const string LanguageKey = "LANGUAGE";
        public const string PathKey = "PATH";
        public const string ValidKey = "VALID";

        public string InstallValue { get; set; }
        public int LanguageValue { get; set; }
        public string PathValue { get; set; }
        public int ValidValue { get; set; }
    }

    public class GpwRegistry
    {
        private static RegistryKey CreateGpwSubKey()
        {
            var key = Settings.Default.RegistryKey;
            var subKey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(key);
            if (subKey == null)
            {
                throw new Exception($@"Unable to create registry key HKEY_LOCAL_MACHINE\{key}");
            }
            return subKey;
        }

        private static RegistryKey OpenGpwSubKey()
        {
            var key = Settings.Default.RegistryKey;
            var subKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(key);
            if (subKey == null)
            {
                throw new Exception($@"Unable to open registry key HKEY_LOCAL_MACHINE\{key}");
            }
            return subKey;
        }

        public void CreateKeys()
        {
            var subKey = CreateGpwSubKey();
            subKey.SetValue(GpwRegistryKeys.InstallKey, @"D:");
            subKey.SetValue(GpwRegistryKeys.LanguageKey, 9);
            subKey.SetValue(GpwRegistryKeys.PathKey, @"C:\Program Files\MicroProse\Grand Prix World");
            subKey.SetValue(GpwRegistryKeys.ValidKey, 0);
        }

        public bool DoAnyKeysExist()
        {
            try
            {
                // Open subkey
                var subKey = OpenGpwSubKey();

                // Get key values under subkey
                var installValue = subKey.GetValue(GpwRegistryKeys.InstallKey);
                var languageValue = subKey.GetValue(GpwRegistryKeys.LanguageKey);
                var pathValue = subKey.GetValue(GpwRegistryKeys.PathKey);
                var validValue = subKey.GetValue(GpwRegistryKeys.ValidKey);

                // If any one key is present, assume all keys exist
                return (installValue != null) || (languageValue != null) || (pathValue != null) || (validValue != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public GpwRegistryKeys ReadKeys()
        {
            var subKey = OpenGpwSubKey();
            return new GpwRegistryKeys()
            {
                InstallValue = Convert.ToString(subKey.GetValue(GpwRegistryKeys.InstallKey)),
                LanguageValue = Convert.ToInt32(subKey.GetValue(GpwRegistryKeys.LanguageKey)),
                PathValue = Convert.ToString(subKey.GetValue(GpwRegistryKeys.PathKey)),
                ValidValue = Convert.ToInt32(subKey.GetValue(GpwRegistryKeys.ValidKey))
            };
        }

        public void WriteKeys(GpwRegistryKeys keys)
        {
            var subKey = CreateGpwSubKey();
            subKey.SetValue(GpwRegistryKeys.InstallKey, keys.InstallValue);
            subKey.SetValue(GpwRegistryKeys.LanguageKey, keys.LanguageValue);
            subKey.SetValue(GpwRegistryKeys.PathKey, keys.PathValue);
            subKey.SetValue(GpwRegistryKeys.ValidKey, keys.ValidValue);
        }
    }
}
