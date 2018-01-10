//using System;
//using App.SaveGameEditor.Data.Connections;
//using Common.Editor.Data.DataEndpoints;
//using Common.Editor.Data.FileResources;

//namespace App.SaveGameEditor.Data.DataEndpoints
//{
//    public class SaveGameDataEndpoint : IDataEndpoint<SaveGameDataConnection>
//    {
//        public IFileResource SaveGameFileResource { get; }

//        public SaveGameDataEndpoint(IFileResource saveGameFileResource)
//        {
//            SaveGameFileResource = saveGameFileResource ?? throw new ArgumentNullException(nameof(saveGameFileResource));
//        }

//        public void Import(SaveGameDataConnection dataConnection)
//        {
//            if (dataConnection == null) throw new ArgumentNullException(nameof(dataConnection));

//            SaveGameFileResource.Import(dataConnection.SaveGameFilePath);
//        }

//        public void Export(SaveGameDataConnection dataConnection)
//        {
//            if (dataConnection == null) throw new ArgumentNullException(nameof(dataConnection));

//            SaveGameFileResource.Export(dataConnection.SaveGameFilePath);
//        }
//    }
//}