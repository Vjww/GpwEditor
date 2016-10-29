/*
using System;
using System.Diagnostics;
using Common.DataAccess.ExecutableOffsets;
using Common.Enums;
using Common.FileConnection;
using Common.GameObjects;

namespace Common.DataAccess
{
    class FuelFileIo : IFileIo
    {
        private const int stringIdOffset = 4894;

        public IGameObject GetItem(int id)
        {
            Debug.Assert((id >= 0) && (id <= 9), "Id is out of range.");

            Fuel record = new Fuel();
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
            Fuel record = gameObject as Fuel;

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
            Fuel record = dataObject as Fuel;

            try
            {
                connection = new GpwExecutableFileConnection();
                connection.OpenConnection(OpenModeType.Read);

                switch (connection.Version)
                {
                    case ExecutableType.Undefined:
                        throw new ArgumentException("Executable type is undefined.");
                    case ExecutableType.GpwXp:
                        record.Performance = connection.GetValueAsInt(FuelGpwxpOffsets.OffsetBase + (FuelGpwxpOffsets.OffsetStruct * record.Id) + (FuelGpwxpOffsets.OffsetAttribute * 0));
                        record.Tolerance = connection.GetValueAsInt(FuelGpwxpOffsets.OffsetBase + (FuelGpwxpOffsets.OffsetStruct * record.Id) + (FuelGpwxpOffsets.OffsetAttribute * 1));
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
            Fuel record = dataObject as Fuel;

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
            Fuel record = dataObject as Fuel;

            try
            {
                connection = new GpwExecutableFileConnection();
                connection.OpenConnection(OpenModeType.Write);

                switch (connection.Version)
                {
                    case ExecutableType.Undefined:
                        throw new ArgumentException("Executable type is undefined.");
                    case ExecutableType.GpwXp:
                        connection.SetValue(FuelGpwxpOffsets.OffsetBase + (FuelGpwxpOffsets.OffsetStruct * record.Id) + (FuelGpwxpOffsets.OffsetAttribute * 0), record.Performance);
                        connection.SetValue(FuelGpwxpOffsets.OffsetBase + (FuelGpwxpOffsets.OffsetStruct * record.Id) + (FuelGpwxpOffsets.OffsetAttribute * 1), record.Tolerance);
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
            Fuel record = dataObject as Fuel;

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
