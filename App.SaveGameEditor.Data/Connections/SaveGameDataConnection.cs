// TODO: Review this is still in line with BaseGameEditor

//using System;
//using Common.Editor.Data.DataConnections;

//namespace App.SaveGameEditor.Data.Connections
//{
//    public class SaveGameDataConnection : IDataConnection
//    {
//        public string SaveGameFilePath { get; private set; }

//        public void Initialise(string saveGameFilePath)
//        {
//            if (string.IsNullOrWhiteSpace(saveGameFilePath))
//                throw new ArgumentException("Value cannot be null or whitespace.", nameof(saveGameFilePath));

//            SaveGameFilePath = saveGameFilePath;
//        }
//    }
//}