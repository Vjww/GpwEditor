using System;
using Microsoft.Win32;

namespace App.WindowsForms.Services
{
    public class GameRegistryKeyService
    {
        private const string InstallKey = "INSTALL";
        private const string LanguageKey = "LANGUAGE";
        private const string PathKey = "PATH";
        private const string ValidKey = "VALID";

        private string _rootKey;

        public string InstallValue { get; set; }
        public int LanguageValue { get; set; }
        public string PathValue { get; set; }
        public int ValidValue { get; set; }

        public void SetRootKey(string rootKey)
        {
            if (string.IsNullOrWhiteSpace(rootKey))
                throw new ArgumentException(@"Value cannot be null or whitespace.", nameof(rootKey));

            _rootKey = rootKey;
        }

        public bool IsRegistryReadable()
        {
            try
            {
                using (OpenKeyForReading())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool IsRegistryWritable()
        {
            try
            {
                using (CreateOrOpenKeyForWriting())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DoKeysExist()
        {
            try
            {
                using (var subKey = OpenKeyForReading())
                {
                    // Get key values under subkey
                    var installValue = subKey.GetValue(InstallKey);
                    var languageValue = subKey.GetValue(LanguageKey);
                    var pathValue = subKey.GetValue(PathKey);
                    var validValue = subKey.GetValue(ValidKey);

                    // If any one key is present, assume all keys exist
                    return installValue != null || languageValue != null || pathValue != null || validValue != null;
                }
            }
            catch
            {
                return false;
            }
        }

        public void CreateKeys()
        {
            WriteKeys(true);
        }

        public void ReadKeys()
        {
            using (var subKey = OpenKeyForReading())
            {
                InstallValue = Convert.ToString(subKey.GetValue(InstallKey));
                LanguageValue = Convert.ToInt32(subKey.GetValue(LanguageKey));
                PathValue = Convert.ToString(subKey.GetValue(PathKey));
                ValidValue = Convert.ToInt32(subKey.GetValue(ValidKey));
            }
        }

        public void WriteKeys()
        {
            WriteKeys(false);
        }

        private void WriteKeys(bool writeDefaultValues)
        {
            using (var subKey = CreateOrOpenKeyForWriting())
            {
                subKey.SetValue(InstallKey, !writeDefaultValues ? InstallValue : @"D:");
                subKey.SetValue(LanguageKey, !writeDefaultValues ? LanguageValue : 9);
                subKey.SetValue(PathKey, !writeDefaultValues ? PathValue : @"C:\Program Files\MicroProse\Grand Prix World");
                subKey.SetValue(ValidKey, !writeDefaultValues ? ValidValue : 0);
            }
        }

        private RegistryKey CreateOrOpenKeyForWriting()
        {
            try
            {
                return Registry.LocalMachine.CreateSubKey(_rootKey);
            }
            catch
            {
                throw new Exception($@"Unable to create or open registry key HKEY_LOCAL_MACHINE\{_rootKey} for writing.");
            }
        }

        private RegistryKey OpenKeyForReading()
        {
            try
            {
                return Registry.LocalMachine.OpenSubKey(_rootKey);
            }
            catch
            {
                throw new Exception($@"Unable to open registry key HKEY_LOCAL_MACHINE\{_rootKey} for reading.");
            }
        }
    }
}