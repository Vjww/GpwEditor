/*
using System;
using System.Diagnostics;
using Common.DataAccess.ExecutableOffsets;
using Common.Enums;
using Common.FileConnection;
using Common.GameObjects;

namespace Common.DataAccess
{
    class TrackFileIo : IFileIo
    {
        private const int stringIdOffset = 6044;

        public IGameObject GetItem(int id)
        {
            Debug.Assert((id >= 0) && (id <= 16), "Id is out of range.");

            Track record = new Track();
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
            Track record = gameObject as Track;

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
            Track record = dataObject as Track;

            try
            {
                connection = new GpwExecutableFileConnection();
                connection.OpenConnection(OpenModeType.Read);

                switch (connection.Version)
                {
                    case ExecutableType.Undefined:
                        throw new ArgumentException("Executable type is undefined.");
                    case ExecutableType.GpwXp:
                        record.Driver = connection.GetValueAsInt(TrackGpwxpOffsets.OffsetBase + (TrackGpwxpOffsets.OffsetStruct * record.Id) + TrackGpwxpOffsets.OffsetDriver);
                        record.Team = connection.GetValueAsInt(TrackGpwxpOffsets.OffsetBase + (TrackGpwxpOffsets.OffsetStruct * record.Id) + TrackGpwxpOffsets.OffsetTeam);
                        record.Time = connection.GetValueAsInt(TrackGpwxpOffsets.OffsetBase + (TrackGpwxpOffsets.OffsetStruct * record.Id) + TrackGpwxpOffsets.OffsetTime);
                        record.Year = connection.GetValueAsInt(TrackGpwxpOffsets.OffsetBase + (TrackGpwxpOffsets.OffsetStruct * record.Id) + TrackGpwxpOffsets.OffsetYear);
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
            Track record = dataObject as Track;

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
            Track record = dataObject as Track;

            try
            {
                connection = new GpwExecutableFileConnection();
                connection.OpenConnection(OpenModeType.Write);

                switch (connection.Version)
                {
                    case ExecutableType.Undefined:
                        throw new ArgumentException("Executable type is undefined.");
                    case ExecutableType.GpwXp:
                        connection.SetValue(TrackGpwxpOffsets.OffsetBase + (TrackGpwxpOffsets.OffsetStruct * record.Id) + TrackGpwxpOffsets.OffsetDriver, record.Driver);
                        connection.SetValue(TrackGpwxpOffsets.OffsetBase + (TrackGpwxpOffsets.OffsetStruct * record.Id) + TrackGpwxpOffsets.OffsetTeam, record.Team);
                        connection.SetValue(TrackGpwxpOffsets.OffsetBase + (TrackGpwxpOffsets.OffsetStruct * record.Id) + TrackGpwxpOffsets.OffsetTime, record.Time);
                        connection.SetValue(TrackGpwxpOffsets.OffsetBase + (TrackGpwxpOffsets.OffsetStruct * record.Id) + TrackGpwxpOffsets.OffsetYear, record.Year);
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
            Track record = dataObject as Track;

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
