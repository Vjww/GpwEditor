using System;
using Common.Editor.Infrastructure.DataContexts;
using Common.Editor.Infrastructure.FileResources;
using GpwEditor.Infrastructure.DataConnections;

namespace GpwEditor.Infrastructure.DataContexts
{
    public class SaveGameDataContext : IDataContext<SaveGameDataConnection>
    {
        private readonly IFileResourceExporter _fileResourceExporter;
        private readonly IFileResourceImporter _fileResourceImporter;

        public IFileResource SaveGameResource { get; private set; }

        public SaveGameDataContext(
            IFileResourceExporter fileResourceExporter,
            IFileResourceImporter fileResourceImporter,
            IFileResource saveGameResource)
        {
            _fileResourceExporter = fileResourceExporter ?? throw new ArgumentNullException(nameof(fileResourceExporter));
            _fileResourceImporter = fileResourceImporter ?? throw new ArgumentNullException(nameof(fileResourceImporter));
            SaveGameResource = saveGameResource ?? throw new ArgumentNullException(nameof(saveGameResource));
        }

        public void Import(SaveGameDataConnection connection)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));

            SaveGameResource = _fileResourceImporter.Import(connection.SaveGameFilePath);
        }

        public void Export(SaveGameDataConnection connection)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));

            _fileResourceExporter.Export(SaveGameResource, connection.SaveGameFilePath);
        }
    }
}