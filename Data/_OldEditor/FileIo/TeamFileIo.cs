/*
using System;
using System.Diagnostics;
using Common.Enums;
using Common.FileConnection;
using Common.GameObjects;

namespace Common.DataAccess
{
    class TeamFileIo : IFileIo
    {
        private const int stringIdOffset = 5697;
        private int[] idToStringIdMap = new int[11] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

        public IGameObject GetItem(int id)
        {
            Debug.Assert((id >= 0) && (id <= 11), "Id is out of range.");

            Team record = new Team();
            record.Id = id;
            record.NameId = idToStringIdMap[id];

            // get data from desired file and get text from language file
            Common.Enums.DataModeType mode =
                (Common.Enums.DataModeType)Common.Properties.Settings.Default.DataMode;
            switch (mode)
            {
                case Common.Enums.DataModeType.Exe:
                    ReadFromExecutable(record);
                    break;
                case Common.Enums.DataModeType.Sav:
                    ReadFromSaveGame(record);
                    break;
                default:
                    throw new NotImplementedException("Data mode type not implemented.");
            }
            ReadFromLanguageFile(record);

            return record;
        }

        public void SetItem(IGameObject gameObject)
        {
            Team record = gameObject as Team;

            // set data to desired file and set text to language file
            Common.Enums.DataModeType mode =
                (Common.Enums.DataModeType)Common.Properties.Settings.Default.DataMode;
            switch (mode)
            {
                case Common.Enums.DataModeType.Exe:
                    WriteToExecutable(record);
                    break;
                case Common.Enums.DataModeType.Sav:
                    WriteToSaveGame(record);
                    break;
                default:
                    throw new NotImplementedException("Data mode type not implemented.");
            }
            WriteToLanguageFile(record);
        }

        private void ReadFromExecutable(object dataObject)
        {
            GpwExecutableFileConnection connection = null;
            Team record = dataObject as Team;

            try
            {
                connection = new GpwExecutableFileConnection();
                connection.OpenConnection(OpenModeType.Read);

                switch (connection.Version)
                {
                    case ExecutableType.Undefined:
                        throw new ArgumentException("Executable type is undefined.");
                    case ExecutableType.GpwXp:
                        //
                        break;
                    default:
                        throw new NotImplementedException("Executable type not implemented.");
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.CloseConnection();
                }
            }
        }

        private void ReadFromLanguageFile(object dataObject)
        {
            GpwLanguageFileConnection connection = null;
            Team record = dataObject as Team;

            try
            {
                connection = new GpwLanguageFileConnection();
                connection.OpenConnection(OpenModeType.Read);

                record.Name = connection.GetValue(stringIdOffset + record.Id);
            }
            finally
            {
                if (connection != null)
                {
                    connection.CloseConnection();
                }
            }
        }

        private void ReadFromSaveGame(object dataObject)
        {
            throw new NotImplementedException();
        }

        private void WriteToExecutable(object dataObject)
        {
            GpwExecutableFileConnection connection = null;
            Team record = dataObject as Team;

            try
            {
                connection = new GpwExecutableFileConnection();
                connection.OpenConnection(OpenModeType.Write);

                switch (connection.Version)
                {
                    case ExecutableType.Undefined:
                        throw new ArgumentException("Executable type is undefined.");
                    case ExecutableType.GpwXp:
                        //
                        break;
                    default:
                        throw new NotImplementedException("Executable type not implemented.");
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.CloseConnection();
                }
            }
        }

        private void WriteToLanguageFile(object dataObject)
        {
            GpwLanguageFileConnection connection = null;
            Team record = dataObject as Team;

            try
            {
                connection = new GpwLanguageFileConnection();
                connection.OpenConnection(OpenModeType.Write);

                connection.SetValue(stringIdOffset + record.Id, record.Name);
            }
            finally
            {
                if (connection != null)
                {
                    connection.CloseConnection();
                }
            }
        }

        private void WriteToSaveGame(object dataObject)
        {
            throw new NotImplementedException();
        }
    }
}
*/
