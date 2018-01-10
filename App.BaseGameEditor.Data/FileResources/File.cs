using System;
using System.ComponentModel;
using System.IO;

namespace App.BaseGameEditor.Data.FileResources
{
    public class File : IFile
    {
        public Stream Open(string filePath, FileMode fileMode, FileAccess fileAccess)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));
            if (!Enum.IsDefined(typeof(FileMode), fileMode))
                throw new InvalidEnumArgumentException(nameof(fileMode), (int)fileMode, typeof(FileMode));
            if (!Enum.IsDefined(typeof(FileAccess), fileAccess))
                throw new InvalidEnumArgumentException(nameof(fileAccess), (int)fileAccess, typeof(FileAccess));

            return System.IO.File.Open(filePath, fileMode, fileAccess);
        }
    }
}