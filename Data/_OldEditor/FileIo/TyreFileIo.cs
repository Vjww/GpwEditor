/*
using System;
using System.Diagnostics;
using Common.DataAccess.ExecutableOffsets;
using Common.Enums;
using Common.FileConnection;
using Common.GameObjects;

namespace Common.DataAccess
{
    class TyreFileIo : IFileIo
    {
        private const int stringIdOffset = 4883;

        public IGameObject GetItem(int id)
        {
            Debug.Assert((id >= 0) && (id <= 3), "Id is out of range.");

            Tyre record = new Tyre();
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
            Tyre record = gameObject as Tyre;

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
            Tyre record = dataObject as Tyre;

            try
            {
                connection = new GpwExecutableFileConnection();
                connection.OpenConnection(OpenModeType.Read);

                switch (connection.Version)
                {
                    case ExecutableType.Undefined:
                        throw new ArgumentException("Executable type is undefined.");
                    case ExecutableType.GpwXp:
                        PopulateRecordFromExecutableGpwxp(record, connection);
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
            Tyre record = dataObject as Tyre;

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
            Tyre record = dataObject as Tyre;

            try
            {
                connection = new GpwExecutableFileConnection();
                connection.OpenConnection(OpenModeType.Write);

                switch (connection.Version)
                {
                    case ExecutableType.Undefined:
                        throw new ArgumentException("Executable type is undefined.");
                    case ExecutableType.GpwXp:
                        PopulateExecutableGpwxpFromRecord(record, connection);
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
            Tyre record = dataObject as Tyre;

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

        private void PopulateRecordFromExecutableGpwxp(Tyre record, GpwExecutableFileConnection connection)
        {
            #region code template
            //record.DryHardGrip =             connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 0));
            //record.DryHardResilience =       connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 1));
            //record.DryHardStiffness =        connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 2));
            //record.DryHardTemperature =      connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 3));
            //record.DrySoftGrip =             connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 0));
            //record.DrySoftResilience =       connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 1));
            //record.DrySoftStiffness =        connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 2));
            //record.DrySoftTemperature =      connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 3));
            //record.IntermediateGrip =        connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 0));
            //record.IntermediateResilience =  connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 1));
            //record.IntermediateStiffness =   connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 2));
            //record.IntermediateTemperature = connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 3));
            //record.WetWeatherGrip =          connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 0));
            //record.WetWeatherResilience =    connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 1));
            //record.WetWeatherStiffness =     connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 2));
            //record.WetWeatherTemperature =   connection.GetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 3));
            //record.DryHardGrip =             connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 0));
            //record.DryHardResilience =       connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 1));
            //record.DryHardStiffness =        connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 2));
            //record.DryHardTemperature =      connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 3));
            //record.DrySoftGrip =             connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 0));
            //record.DrySoftResilience =       connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 1));
            //record.DrySoftStiffness =        connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 2));
            //record.DrySoftTemperature =      connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 3));
            //record.IntermediateGrip =        connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 0));
            //record.IntermediateResilience =  connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 1));
            //record.IntermediateStiffness =   connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 2));
            //record.IntermediateTemperature = connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 3));
            //record.WetWeatherGrip =          connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 0));
            //record.WetWeatherResilience =    connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 1));
            //record.WetWeatherStiffness =     connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 2));
            //record.WetWeatherTemperature =   connection.GetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 3));
            //record.DryHardGrip =             connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 0));
            //record.DryHardResilience =       connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 1));
            //record.DryHardStiffness =        connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 2));
            //record.DryHardTemperature =      connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 3));
            //record.DrySoftGrip =             connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 0));
            //record.DrySoftResilience =       connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 1));
            //record.DrySoftStiffness =        connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 2));
            //record.DrySoftTemperature =      connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 3));
            //record.IntermediateGrip =        connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 0));
            //record.IntermediateResilience =  connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 1));
            //record.IntermediateStiffness =   connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 2));
            //record.IntermediateTemperature = connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 3));
            //record.WetWeatherGrip =          connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 0));
            //record.WetWeatherResilience =    connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 1));
            //record.WetWeatherStiffness =     connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 2));
            //record.WetWeatherTemperature =   connection.GetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 3));
            #endregion

            switch (record.Id)
            {
                case 0:
                    record.DryHardGrip = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 0));
                    record.DryHardResilience = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 1));
                    record.DryHardStiffness = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 2));
                    record.DryHardTemperature = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 3));
                    record.DrySoftGrip = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 0));
                    record.DrySoftResilience = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 1));
                    record.DrySoftStiffness = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 2));
                    record.DrySoftTemperature = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 3));
                    record.IntermediateGrip = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 0));
                    record.IntermediateResilience = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 1));
                    record.IntermediateStiffness = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 2));
                    record.IntermediateTemperature = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 3));
                    record.WetWeatherGrip = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 0));
                    record.WetWeatherResilience = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 1));
                    record.WetWeatherStiffness = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 2));
                    record.WetWeatherTemperature = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 3));
                    break;
                case 1:
                    record.DryHardGrip = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 0));
                    record.DryHardResilience = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 1));
                    record.DryHardStiffness = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 2));
                    record.DryHardTemperature = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 3));
                    record.DrySoftGrip = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 0));
                    record.DrySoftResilience = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 1));
                    record.DrySoftStiffness = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 2));
                    record.DrySoftTemperature = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 3));
                    record.IntermediateGrip = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 0));
                    record.IntermediateResilience = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 1));
                    record.IntermediateStiffness = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 2));
                    record.IntermediateTemperature = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 3));
                    record.WetWeatherGrip = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 0));
                    record.WetWeatherResilience = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 1));
                    record.WetWeatherStiffness = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 2));
                    record.WetWeatherTemperature = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 3));
                    break;
                case 2:
                    record.DryHardGrip = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 0));
                    record.DryHardResilience = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 1));
                    record.DryHardStiffness = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 2));
                    record.DryHardTemperature = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 3));
                    record.DrySoftGrip = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 0));
                    record.DrySoftResilience = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 1));
                    record.DrySoftStiffness = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 2));
                    record.DrySoftTemperature = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 3));
                    record.IntermediateGrip = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 0));
                    record.IntermediateResilience = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 1));
                    record.IntermediateStiffness = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 2));
                    record.IntermediateTemperature = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 3));
                    record.WetWeatherGrip = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 0));
                    record.WetWeatherResilience = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 1));
                    record.WetWeatherStiffness = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 2));
                    record.WetWeatherTemperature = connection.GetValueAsInt(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 3));
                    break;
                default:
                    throw new NotImplementedException("Invalid record id.");
            }
        }

        private void PopulateExecutableGpwxpFromRecord(Tyre record, GpwExecutableFileConnection connection)
        {
            #region code template
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 0), record.DryHardGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 1), record.DryHardResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 2), record.DryHardStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 3), record.DryHardTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 0), record.DrySoftGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 1), record.DrySoftResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 2), record.DrySoftStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 3), record.DrySoftTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 0), record.IntermediateGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 1), record.IntermediateResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 2), record.IntermediateStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 3), record.IntermediateTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 0), record.WetWeatherGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 1), record.WetWeatherResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 2), record.WetWeatherStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 3), record.WetWeatherTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 0) + (TyreGpwxpOffsets.OffsetAttribute1b * 0), record.DryHardGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 0) + (TyreGpwxpOffsets.OffsetAttribute1b * 1), record.DryHardResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 0) + (TyreGpwxpOffsets.OffsetAttribute1b * 2), record.DryHardStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 0) + (TyreGpwxpOffsets.OffsetAttribute1b * 3), record.DryHardTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 1) + (TyreGpwxpOffsets.OffsetAttribute1b * 0), record.DrySoftGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 1) + (TyreGpwxpOffsets.OffsetAttribute1b * 1), record.DrySoftResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 1) + (TyreGpwxpOffsets.OffsetAttribute1b * 2), record.DrySoftStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 1) + (TyreGpwxpOffsets.OffsetAttribute1b * 3), record.DrySoftTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 2) + (TyreGpwxpOffsets.OffsetAttribute1b * 0), record.IntermediateGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 2) + (TyreGpwxpOffsets.OffsetAttribute1b * 1), record.IntermediateResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 2) + (TyreGpwxpOffsets.OffsetAttribute1b * 2), record.IntermediateStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 2) + (TyreGpwxpOffsets.OffsetAttribute1b * 3), record.IntermediateTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 3) + (TyreGpwxpOffsets.OffsetAttribute1b * 0), record.WetWeatherGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 3) + (TyreGpwxpOffsets.OffsetAttribute1b * 1), record.WetWeatherResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 3) + (TyreGpwxpOffsets.OffsetAttribute1b * 2), record.WetWeatherStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 3) + (TyreGpwxpOffsets.OffsetAttribute1b * 3), record.WetWeatherTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 0), record.DryHardGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 1), record.DryHardResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 2), record.DryHardStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 3), record.DryHardTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 0), record.DrySoftGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 1), record.DrySoftResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 2), record.DrySoftStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 3), record.DrySoftTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 0), record.IntermediateGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 1), record.IntermediateResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 2), record.IntermediateStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 3), record.IntermediateTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 0), record.WetWeatherGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 1), record.WetWeatherResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 2), record.WetWeatherStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 3), record.WetWeatherTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 0) + (TyreGpwxpOffsets.OffsetAttribute2b * 0), record.DryHardGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 0) + (TyreGpwxpOffsets.OffsetAttribute2b * 1), record.DryHardResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 0) + (TyreGpwxpOffsets.OffsetAttribute2b * 2), record.DryHardStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 0) + (TyreGpwxpOffsets.OffsetAttribute2b * 3), record.DryHardTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 1) + (TyreGpwxpOffsets.OffsetAttribute2b * 0), record.DrySoftGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 1) + (TyreGpwxpOffsets.OffsetAttribute2b * 1), record.DrySoftResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 1) + (TyreGpwxpOffsets.OffsetAttribute2b * 2), record.DrySoftStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 1) + (TyreGpwxpOffsets.OffsetAttribute2b * 3), record.DrySoftTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 2) + (TyreGpwxpOffsets.OffsetAttribute2b * 0), record.IntermediateGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 2) + (TyreGpwxpOffsets.OffsetAttribute2b * 1), record.IntermediateResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 2) + (TyreGpwxpOffsets.OffsetAttribute2b * 2), record.IntermediateStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 2) + (TyreGpwxpOffsets.OffsetAttribute2b * 3), record.IntermediateTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 3) + (TyreGpwxpOffsets.OffsetAttribute2b * 0), record.WetWeatherGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 3) + (TyreGpwxpOffsets.OffsetAttribute2b * 1), record.WetWeatherResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 3) + (TyreGpwxpOffsets.OffsetAttribute2b * 2), record.WetWeatherStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 3) + (TyreGpwxpOffsets.OffsetAttribute2b * 3), record.WetWeatherTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 0), record.DryHardGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 1), record.DryHardResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 2), record.DryHardStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 3), record.DryHardTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 0), record.DrySoftGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 1), record.DrySoftResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 2), record.DrySoftStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 3), record.DrySoftTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 0), record.IntermediateGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 1), record.IntermediateResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 2), record.IntermediateStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 3), record.IntermediateTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 0), record.WetWeatherGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 1), record.WetWeatherResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 2), record.WetWeatherStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 3), record.WetWeatherTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 0) + (TyreGpwxpOffsets.OffsetAttribute3b * 0), record.DryHardGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 0) + (TyreGpwxpOffsets.OffsetAttribute3b * 1), record.DryHardResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 0) + (TyreGpwxpOffsets.OffsetAttribute3b * 2), record.DryHardStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 0) + (TyreGpwxpOffsets.OffsetAttribute3b * 3), record.DryHardTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 1) + (TyreGpwxpOffsets.OffsetAttribute3b * 0), record.DrySoftGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 1) + (TyreGpwxpOffsets.OffsetAttribute3b * 1), record.DrySoftResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 1) + (TyreGpwxpOffsets.OffsetAttribute3b * 2), record.DrySoftStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 1) + (TyreGpwxpOffsets.OffsetAttribute3b * 3), record.DrySoftTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 2) + (TyreGpwxpOffsets.OffsetAttribute3b * 0), record.IntermediateGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 2) + (TyreGpwxpOffsets.OffsetAttribute3b * 1), record.IntermediateResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 2) + (TyreGpwxpOffsets.OffsetAttribute3b * 2), record.IntermediateStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 2) + (TyreGpwxpOffsets.OffsetAttribute3b * 3), record.IntermediateTemperature);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 3) + (TyreGpwxpOffsets.OffsetAttribute3b * 0), record.WetWeatherGrip);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 3) + (TyreGpwxpOffsets.OffsetAttribute3b * 1), record.WetWeatherResilience);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 3) + (TyreGpwxpOffsets.OffsetAttribute3b * 2), record.WetWeatherStiffness);
            //connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 3) + (TyreGpwxpOffsets.OffsetAttribute3b * 3), record.WetWeatherTemperature);
            #endregion

            switch (record.Id)
            {
                case 0:
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 0), record.DryHardGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 1), record.DryHardResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 2), record.DryHardStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 0) + (TyreGpwxpOffsets.OffsetAttribute1a * 3), record.DryHardTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 0), record.DrySoftGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 1), record.DrySoftResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 2), record.DrySoftStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 1) + (TyreGpwxpOffsets.OffsetAttribute1a * 3), record.DrySoftTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 0), record.IntermediateGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 1), record.IntermediateResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 2), record.IntermediateStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 2) + (TyreGpwxpOffsets.OffsetAttribute1a * 3), record.IntermediateTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 0), record.WetWeatherGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 1), record.WetWeatherResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 2), record.WetWeatherStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1a + (TyreGpwxpOffsets.OffsetStruct1a * 3) + (TyreGpwxpOffsets.OffsetAttribute1a * 3), record.WetWeatherTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 0) + (TyreGpwxpOffsets.OffsetAttribute1b * 0), record.DryHardGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 0) + (TyreGpwxpOffsets.OffsetAttribute1b * 1), record.DryHardResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 0) + (TyreGpwxpOffsets.OffsetAttribute1b * 2), record.DryHardStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 0) + (TyreGpwxpOffsets.OffsetAttribute1b * 3), record.DryHardTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 1) + (TyreGpwxpOffsets.OffsetAttribute1b * 0), record.DrySoftGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 1) + (TyreGpwxpOffsets.OffsetAttribute1b * 1), record.DrySoftResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 1) + (TyreGpwxpOffsets.OffsetAttribute1b * 2), record.DrySoftStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 1) + (TyreGpwxpOffsets.OffsetAttribute1b * 3), record.DrySoftTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 2) + (TyreGpwxpOffsets.OffsetAttribute1b * 0), record.IntermediateGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 2) + (TyreGpwxpOffsets.OffsetAttribute1b * 1), record.IntermediateResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 2) + (TyreGpwxpOffsets.OffsetAttribute1b * 2), record.IntermediateStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 2) + (TyreGpwxpOffsets.OffsetAttribute1b * 3), record.IntermediateTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 3) + (TyreGpwxpOffsets.OffsetAttribute1b * 0), record.WetWeatherGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 3) + (TyreGpwxpOffsets.OffsetAttribute1b * 1), record.WetWeatherResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 3) + (TyreGpwxpOffsets.OffsetAttribute1b * 2), record.WetWeatherStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase1b + (TyreGpwxpOffsets.OffsetStruct1b * 3) + (TyreGpwxpOffsets.OffsetAttribute1b * 3), record.WetWeatherTemperature);
                    break;
                case 1:
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 0), record.DryHardGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 1), record.DryHardResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 2), record.DryHardStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 0) + (TyreGpwxpOffsets.OffsetAttribute2a * 3), record.DryHardTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 0), record.DrySoftGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 1), record.DrySoftResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 2), record.DrySoftStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 1) + (TyreGpwxpOffsets.OffsetAttribute2a * 3), record.DrySoftTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 0), record.IntermediateGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 1), record.IntermediateResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 2), record.IntermediateStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 2) + (TyreGpwxpOffsets.OffsetAttribute2a * 3), record.IntermediateTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 0), record.WetWeatherGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 1), record.WetWeatherResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 2), record.WetWeatherStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2a + (TyreGpwxpOffsets.OffsetStruct2a * 3) + (TyreGpwxpOffsets.OffsetAttribute2a * 3), record.WetWeatherTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 0) + (TyreGpwxpOffsets.OffsetAttribute2b * 0), record.DryHardGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 0) + (TyreGpwxpOffsets.OffsetAttribute2b * 1), record.DryHardResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 0) + (TyreGpwxpOffsets.OffsetAttribute2b * 2), record.DryHardStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 0) + (TyreGpwxpOffsets.OffsetAttribute2b * 3), record.DryHardTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 1) + (TyreGpwxpOffsets.OffsetAttribute2b * 0), record.DrySoftGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 1) + (TyreGpwxpOffsets.OffsetAttribute2b * 1), record.DrySoftResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 1) + (TyreGpwxpOffsets.OffsetAttribute2b * 2), record.DrySoftStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 1) + (TyreGpwxpOffsets.OffsetAttribute2b * 3), record.DrySoftTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 2) + (TyreGpwxpOffsets.OffsetAttribute2b * 0), record.IntermediateGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 2) + (TyreGpwxpOffsets.OffsetAttribute2b * 1), record.IntermediateResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 2) + (TyreGpwxpOffsets.OffsetAttribute2b * 2), record.IntermediateStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 2) + (TyreGpwxpOffsets.OffsetAttribute2b * 3), record.IntermediateTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 3) + (TyreGpwxpOffsets.OffsetAttribute2b * 0), record.WetWeatherGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 3) + (TyreGpwxpOffsets.OffsetAttribute2b * 1), record.WetWeatherResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 3) + (TyreGpwxpOffsets.OffsetAttribute2b * 2), record.WetWeatherStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase2b + (TyreGpwxpOffsets.OffsetStruct2b * 3) + (TyreGpwxpOffsets.OffsetAttribute2b * 3), record.WetWeatherTemperature);
                    break;
                case 2:
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 0), record.DryHardGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 1), record.DryHardResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 2), record.DryHardStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 0) + (TyreGpwxpOffsets.OffsetAttribute3a * 3), record.DryHardTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 0), record.DrySoftGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 1), record.DrySoftResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 2), record.DrySoftStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 1) + (TyreGpwxpOffsets.OffsetAttribute3a * 3), record.DrySoftTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 0), record.IntermediateGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 1), record.IntermediateResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 2), record.IntermediateStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 2) + (TyreGpwxpOffsets.OffsetAttribute3a * 3), record.IntermediateTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 0), record.WetWeatherGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 1), record.WetWeatherResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 2), record.WetWeatherStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3a + (TyreGpwxpOffsets.OffsetStruct3a * 3) + (TyreGpwxpOffsets.OffsetAttribute3a * 3), record.WetWeatherTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 0) + (TyreGpwxpOffsets.OffsetAttribute3b * 0), record.DryHardGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 0) + (TyreGpwxpOffsets.OffsetAttribute3b * 1), record.DryHardResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 0) + (TyreGpwxpOffsets.OffsetAttribute3b * 2), record.DryHardStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 0) + (TyreGpwxpOffsets.OffsetAttribute3b * 3), record.DryHardTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 1) + (TyreGpwxpOffsets.OffsetAttribute3b * 0), record.DrySoftGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 1) + (TyreGpwxpOffsets.OffsetAttribute3b * 1), record.DrySoftResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 1) + (TyreGpwxpOffsets.OffsetAttribute3b * 2), record.DrySoftStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 1) + (TyreGpwxpOffsets.OffsetAttribute3b * 3), record.DrySoftTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 2) + (TyreGpwxpOffsets.OffsetAttribute3b * 0), record.IntermediateGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 2) + (TyreGpwxpOffsets.OffsetAttribute3b * 1), record.IntermediateResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 2) + (TyreGpwxpOffsets.OffsetAttribute3b * 2), record.IntermediateStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 2) + (TyreGpwxpOffsets.OffsetAttribute3b * 3), record.IntermediateTemperature);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 3) + (TyreGpwxpOffsets.OffsetAttribute3b * 0), record.WetWeatherGrip);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 3) + (TyreGpwxpOffsets.OffsetAttribute3b * 1), record.WetWeatherResilience);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 3) + (TyreGpwxpOffsets.OffsetAttribute3b * 2), record.WetWeatherStiffness);
                    connection.SetValue(TyreGpwxpOffsets.OffsetBase3b + (TyreGpwxpOffsets.OffsetStruct3b * 3) + (TyreGpwxpOffsets.OffsetAttribute3b * 3), record.WetWeatherTemperature);
                    break;
                default:
                    throw new NotImplementedException("Invalid record id.");
            }
        }
    }
}
*/
 