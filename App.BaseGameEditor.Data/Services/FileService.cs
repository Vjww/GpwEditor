using System;
using System.ComponentModel;
using System.IO;

namespace App.BaseGameEditor.Data.Services
{
    public class FileService
    {
        public Stream Open(string filePath, FileMode fileMode, FileAccess fileAccess)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));
            if (!Enum.IsDefined(typeof(FileMode), fileMode))
                throw new InvalidEnumArgumentException(nameof(fileMode), (int)fileMode, typeof(FileMode));
            if (!Enum.IsDefined(typeof(FileAccess), fileAccess))
                throw new InvalidEnumArgumentException(nameof(fileAccess), (int)fileAccess, typeof(FileAccess));

            return File.Open(filePath, fileMode, fileAccess);
        }
    }
}