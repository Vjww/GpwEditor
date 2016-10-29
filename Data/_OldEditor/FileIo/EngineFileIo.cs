/*
using System;
using System.Diagnostics;
using Common.DataAccess.ExecutableOffsets;
using Common.Enums;
using Common.FileConnection;
using Common.GameObjects;

namespace Common.DataAccess
{
    class EngineFileIo : IFileIo
    {
        private const int stringIdOffset = 4886;

        public IGameObject GetItem(int id)
        {
            Debug.Assert((id >= 0) && (id <= 8), "Id is out of range.");

            Engine record = new Engine();
            record.Id = id;

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
            Engine record = gameObject as Engine;

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
            Engine record = dataObject as Engine;

            try
            {
                connection = new GpwExecutableFileConnection();
                connection.OpenConnection(OpenModeType.Read);

                switch (connection.Version)
                {
                    case ExecutableType.Undefined:
                        throw new ArgumentException("Executable type is undefined.");
                    case ExecutableType.GpwXp:
                        record.Fuel = connection.GetValueAsInt(EngineGpwxpOffsets.OffsetBase + (EngineGpwxpOffsets.OffsetStruct * record.Id) + (EngineGpwxpOffsets.OffsetAttribute * 0));
                        record.Heat = connection.GetValueAsInt(EngineGpwxpOffsets.OffsetBase + (EngineGpwxpOffsets.OffsetStruct * record.Id) + (EngineGpwxpOffsets.OffsetAttribute * 1));
                        record.Power = connection.GetValueAsInt(EngineGpwxpOffsets.OffsetBase + (EngineGpwxpOffsets.OffsetStruct * record.Id) + (EngineGpwxpOffsets.OffsetAttribute * 2));
                        record.Reliability = connection.GetValueAsInt(EngineGpwxpOffsets.OffsetBase + (EngineGpwxpOffsets.OffsetStruct * record.Id) + (EngineGpwxpOffsets.OffsetAttribute * 3));
                        record.Response = connection.GetValueAsInt(EngineGpwxpOffsets.OffsetBase + (EngineGpwxpOffsets.OffsetStruct * record.Id) + (EngineGpwxpOffsets.OffsetAttribute * 4));
                        record.Rigidity = connection.GetValueAsInt(EngineGpwxpOffsets.OffsetBase + (EngineGpwxpOffsets.OffsetStruct * record.Id) + (EngineGpwxpOffsets.OffsetAttribute * 5));
                        record.Weight = connection.GetValueAsInt(EngineGpwxpOffsets.OffsetBase + (EngineGpwxpOffsets.OffsetStruct * record.Id) + (EngineGpwxpOffsets.OffsetAttribute * 6));
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
            Engine record = dataObject as Engine;

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
            Engine record = dataObject as Engine;

            try
            {
                connection = new GpwExecutableFileConnection();
                connection.OpenConnection(OpenModeType.Write);

                switch (connection.Version)
                {
                    case ExecutableType.Undefined:
                        throw new ArgumentException("Executable type is undefined.");
                    case ExecutableType.GpwXp:
                        connection.SetValue(EngineGpwxpOffsets.OffsetBase + (EngineGpwxpOffsets.OffsetStruct * record.Id) + (EngineGpwxpOffsets.OffsetAttribute * 0), record.Fuel);
                        connection.SetValue(EngineGpwxpOffsets.OffsetBase + (EngineGpwxpOffsets.OffsetStruct * record.Id) + (EngineGpwxpOffsets.OffsetAttribute * 1), record.Heat);
                        connection.SetValue(EngineGpwxpOffsets.OffsetBase + (EngineGpwxpOffsets.OffsetStruct * record.Id) + (EngineGpwxpOffsets.OffsetAttribute * 2), record.Power);
                        connection.SetValue(EngineGpwxpOffsets.OffsetBase + (EngineGpwxpOffsets.OffsetStruct * record.Id) + (EngineGpwxpOffsets.OffsetAttribute * 3), record.Reliability);
                        connection.SetValue(EngineGpwxpOffsets.OffsetBase + (EngineGpwxpOffsets.OffsetStruct * record.Id) + (EngineGpwxpOffsets.OffsetAttribute * 4), record.Response);
                        connection.SetValue(EngineGpwxpOffsets.OffsetBase + (EngineGpwxpOffsets.OffsetStruct * record.Id) + (EngineGpwxpOffsets.OffsetAttribute * 5), record.Rigidity);
                        connection.SetValue(EngineGpwxpOffsets.OffsetBase + (EngineGpwxpOffsets.OffsetStruct * record.Id) + (EngineGpwxpOffsets.OffsetAttribute * 6), record.Weight);
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
            Engine record = dataObject as Engine;

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
