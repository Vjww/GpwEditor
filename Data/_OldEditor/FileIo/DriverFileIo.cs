/*
using System;
using System.Diagnostics;
using Common.Enums;
using Common.FileConnection;
using Common.GameObjects;

namespace Common.DataAccess
{
    class DriverFileIo : IFileIo
    {
        private const int stringIdOffset = 5796;
        private int[] idToStringIdMap = new int[48] { 6, 7, 8, 14, 15, 16, 22, 23, 24, 30,
            31, 32, 38, 39, 40, 46, 47, 48, 54, 55, 56, 62, 63, 64, 70, 
            71, 72, 78, 79, 80, 86, 87, 88, 129, 130, 131, 132, 133, 
            134, 135, 136, 137, 138, 139, 200, 201, 202, 203 };

        public IGameObject GetItem(int id)
        {
            Debug.Assert((id >= 0) && (id < idToStringIdMap.Length),
                "Id is out of range.");

            Driver record = new Driver();
            record.Id = id;
            record.NameId = idToStringIdMap[id];
            if (id >= 44)
                record.Type = DriverType.NameOnly;
            else
                record.Type = DriverType.Full;

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
            Driver record = gameObject as Driver;

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
            Driver record = dataObject as Driver;

            try
            {
                connection = new GpwExecutableFileConnection();
                connection.OpenConnection(OpenModeType.Read);

                switch (connection.Version)
                {
                    case ExecutableType.Undefined:
                        throw new ArgumentException("Executable type is undefined.");
                    case ExecutableType.GpwXp:
                        switch (record.Type)
                        {
                            case DriverType.Full:
                                //
                                break;
                            case DriverType.NameOnly:
                                break;
                            default:
                                throw new NotImplementedException("Driver type not implemented.");
                        }
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
            int offset;
            GpwLanguageFileConnection connection = null;
            Driver record = dataObject as Driver;

            try
            {
                connection = new GpwLanguageFileConnection();
                connection.OpenConnection(OpenModeType.Read);

                if (record.Type == DriverType.Full)
                    offset = stringIdOffset + record.NameId - 1;
                else
                    offset = stringIdOffset + 535 + record.NameId - 1;

                record.Name = connection.GetValue(offset);
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
            Driver record = dataObject as Driver;

            try
            {
                connection = new GpwExecutableFileConnection();
                connection.OpenConnection(OpenModeType.Write);

                switch (connection.Version)
                {
                    case ExecutableType.Undefined:
                        throw new ArgumentException("Executable type is undefined.");
                    case ExecutableType.GpwXp:
                        switch (record.Type)
                        {
                            case DriverType.Full:
                                //
                                break;
                            case DriverType.NameOnly:
                                break;
                            default:
                                throw new NotImplementedException("Driver type not implemented.");
                        }
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
            int offset;
            GpwLanguageFileConnection connection = null;
            Driver record = dataObject as Driver;

            try
            {
                connection = new GpwLanguageFileConnection();
                connection.OpenConnection(OpenModeType.Write);

                if (record.Type == DriverType.Full)
                    offset = stringIdOffset + record.NameId - 1;
                else
                    offset = stringIdOffset + 535 + record.NameId - 1;

                connection.SetValue(offset, record.Name);
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
