using System;
using System.IO;
using System.Security.Cryptography;

namespace Data
{
    public class ExecutableVerification
    {
        // Officially released versions
        private const string Sha256ChecksumOfficialGpwV100F = "DB-91-3C-BD-6F-13-81-E4-CF-BA-8F-68-F2-75-59-DC-40-F8-E0-FA-2F-F5-7C-51-0C-82-2E-FA-4D-05-FB-79";
        private const string Sha256ChecksumOfficialGpwV101B = "A3-E3-9B-E1-67-90-AA-F5-25-FA-25-47-8E-62-CE-34-11-53-4C-96-49-C9-EE-40-66-06-F1-65-87-BD-3E-8F";
        private const string Sha256ChecksumOfficialGpwxpV100F = "FD-06-19-87-9D-FC-43-CA-39-AF-AC-B7-75-DC-AD-63-36-DD-5F-46-AE-1E-58-C9-42-F2-44-3A-C6-54-DE-8C";

        // Unofficially released cracked versions
        // TODO find these versions and calculate sha-256 checksums

        // Unofficially released versions via DxWnd development
        private const string Sha256ChecksumUnofficialGpwxpV102F = "90-5B-F1-A9-99-CD-40-40-1C-37-9E-99-C7-B2-96-1D-7C-A3-CE-97-4D-BB-67-55-D4-55-E8-6E-E7-C1-D3-BB";
        private const string Sha256ChecksumUnofficialGpwxpV103F = "24-A7-7D-D8-73-62-EB-19-ED-E1-3A-E4-0C-AC-12-D8-EC-CB-33-EA-81-82-AD-D8-19-76-99-8A-E4-9D-84-77";

        // Unofficially released versions via GPRaceGames development
        private const string Sha256ChecksumUnofficialGpwV102B = "7E-17-EA-13-00-71-50-97-7F-C5-FC-17-AE-B3-6D-42-34-E6-50-6E-AA-87-DB-A7-CB-36-13-59-AD-20-7C-9C";
        private const string Sha256ChecksumUnofficialGpwV103B = "7D-DA-30-B4-65-74-A1-33-D3-6E-A9-F6-D2-F9-FE-0B-25-6C-8B-22-3A-E6-63-77-E5-63-FF-EF-93-1E-AD-29";
        private const string Sha256ChecksumUnofficialGpwV103B251815 = "E5-CB-F0-B8-74-CB-1B-D8-3C-A1-D0-01-3F-71-30-5C-F2-F9-F0-C9-1A-53-F8-A5-70-D1-05-C7-E8-B0-8D-CC";
        private const string Sha256ChecksumUnofficialGpwV103F1064 = "81-C8-EE-F5-C0-EC-84-9E-D8-F6-6C-C8-BF-44-BC-1C-AD-B9-95-02-12-D5-9C-C0-1E-69-2D-0C-DE-DB-E3-74";
        private const string Sha256ChecksumUnofficialGpwV103F1086 = "C4-70-D6-58-1B-A8-53-ED-E0-4D-26-18-2F-CF-29-A5-5B-0F-AD-86-4B-68-7F-93-2B-BE-40-21-F6-A9-D2-1B";
        private const string Sha256ChecksumUnofficialGpwV103F251815 = "EC-C0-C6-D3-C7-3F-0E-ED-31-98-48-E1-96-40-D9-C8-68-F5-26-AF-F8-58-06-A5-9A-51-F0-A7-4B-76-AF-58";
        private const string Sha256ChecksumUnofficialGpwV103FRpc1064 = "74-66-6E-14-87-12-73-22-C9-4E-95-A0-21-5E-08-D9-A5-42-78-B5-5D-3A-EB-DD-AF-B5-55-01-5D-91-3B-F5";
        private const string Sha256ChecksumUnofficialGpwV103FRpc251815 = "9C-0B-BC-53-0A-D3-D0-88-60-80-D0-83-D5-07-BD-5C-CD-6B-CD-9E-0B-E1-84-9A-03-B4-9D-AB-00-36-F4-F2";

        // Filesize of supported executable version, official gpw.exe v1.01b
        private const long SupportedFileSize = 3004928;

        public bool IsGameExecutableSupported(string filePath, out string message)
        {
            var isIdentified = true;
            var isOfficial = false;
            var fileName = string.Empty;
            var version = string.Empty;

            // Attempt to identity by checksum
            var checksum = GetSha256Checksum(filePath);
            switch (checksum)
            {
                case Sha256ChecksumOfficialGpwV100F:
                    isOfficial = true;
                    fileName = "gpw.exe";
                    version = "v1.00";
                    break;
                case Sha256ChecksumOfficialGpwV101B:
                    isOfficial = true;
                    fileName = "gpw.exe";
                    version = "v1.01b";
                    break;
                case Sha256ChecksumOfficialGpwxpV100F:
                    isOfficial = true;
                    fileName = "gpwxp.exe";
                    version = "v1.00";
                    break;
                case Sha256ChecksumUnofficialGpwV102B:
                    fileName = "gpw.exe";
                    version = "v1.02b";
                    break;
                case Sha256ChecksumUnofficialGpwV103B:
                case Sha256ChecksumUnofficialGpwV103B251815:
                    fileName = "gpw.exe";
                    version = "v1.03b";
                    break;
                case Sha256ChecksumUnofficialGpwV103F1064:
                case Sha256ChecksumUnofficialGpwV103F1086:
                case Sha256ChecksumUnofficialGpwV103F251815:
                case Sha256ChecksumUnofficialGpwV103FRpc1064:
                case Sha256ChecksumUnofficialGpwV103FRpc251815:
                    fileName = "gpw.exe";
                    version = "v1.03";
                    break;
                case Sha256ChecksumUnofficialGpwxpV102F:
                    fileName = "gpwxp2.exe";
                    version = "v1.00";
                    break;
                case Sha256ChecksumUnofficialGpwxpV103F:
                    fileName = "gpwxp3.exe";
                    version = "v1.00";
                    break;
                default:
                    isIdentified = false;
                    break;
            }

            // Identified
            if (isIdentified)
            {
                var isOfficialText = isOfficial ? "official" : "unofficial";
                message = $"The selected game executable file has been identified as {isOfficialText} version {fileName} {version}.";

                // Return whether identified version is the supported executable version
                return string.Equals(checksum, Sha256ChecksumOfficialGpwV101B);
            }

            // Attempt to identity by file length
            var fileLength = new FileInfo(filePath).Length;
            if (fileLength == SupportedFileSize)
            {
                // TODO add further validation of changed bytes to confirm this program supports the executable
                // TODO as any file matching this length could be anything but the expected executable version
                // TODO possibly do a byte comparison of the code shifting for teams/chiefs/drivers to confirm

                fileName = "gpw.exe";
                version = "v1.01b";
                message = $"The selected game executable file has been identified as a supported version of {fileName} {version}.";
                return true;
            }

            // Unidentified
            message = "The selected game executable file was unable to be identified as a valid game executable.";
            return false;
        }

        private static string GetSha256Checksum(string filePath)
        {
            using (var checksum = SHA256.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    return BitConverter.ToString(checksum.ComputeHash(stream));
                }
            }
        }
    }
}