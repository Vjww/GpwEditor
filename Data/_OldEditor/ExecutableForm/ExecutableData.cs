/*
using Common.GameLogic;
using Common.GameObjects;
using Common.GameObjects.Collections;

namespace ExecutableEditor
{
    class ExecutableData
    {
        public DriverCollection Drivers { get; set; }
        public TeamCollection Teams { get; set; }
        public EngineCollection Engines { get; set; }
        public TyreCollection Tyres { get; set; }
        public FuelCollection Fuels { get; set; }
        public TrackCollection Tracks { get; set; }

        public void Import()
        {
            GetDrivers();
            GetTeams();

            GetEngines();
            GetTyres();
            GetFuels();
            GetTracks();
        }

        public void Export()
        {
            SetDrivers();
            SetTeams();

            SetEngines();
            SetTyres();
            SetFuels();
            SetTracks();
        }

        private void GetDrivers()
        {
            int driverCount = 48;
            DriverManager driverManager = new DriverManager();
            Drivers = new DriverCollection();
            for (int i = 0; i < driverCount; i++)
            {
                Driver record = driverManager.GetItem(i) as Driver;
                Drivers.Add(record);
            }
        }

        private void GetTeams()
        {
            int teamCount = 11;
            TeamManager teamManager = new TeamManager();
            Teams = new TeamCollection();
            for (int i = 0; i < teamCount; i++)
            {
                Team record = teamManager.GetItem(i) as Team;
                Teams.Add(record);
            }
        }

        private void GetEngines()
        {
            int engineCount = 8;
            EngineManager engineManager = new EngineManager();
            Engines = new EngineCollection();
            for (int i = 0; i < engineCount; i++)
            {
                Engine record = engineManager.GetItem(i) as Engine;
                Engines.Add(record);
            }
        }

        private void GetTyres()
        {
            int tyreCount = 3;
            TyreManager tyreManager = new TyreManager();
            Tyres = new TyreCollection();
            for (int i = 0; i < tyreCount; i++)
            {
                Tyre record = tyreManager.GetItem(i) as Tyre;
                Tyres.Add(record);
            }
        }

        private void GetFuels()
        {
            int fuelCount = 9;
            FuelManager fuelManager = new FuelManager();
            Fuels = new FuelCollection();
            for (int i = 0; i < fuelCount; i++)
            {
                Fuel record = fuelManager.GetItem(i) as Fuel;
                Fuels.Add(record);
            }
        }

        private void GetTracks()
        {
            int trackCount = 16;
            TrackManager trackManager = new TrackManager();
            Tracks = new TrackCollection();
            for (int i = 0; i < trackCount; i++)
            {
                Track record = trackManager.GetItem(i) as Track;
                Tracks.Add(record);
            }
        }

        private void SetDrivers()
        {
            int driverCount = 48;
            DriverManager driverManager = new DriverManager();
            for (int i = 0; i < driverCount; i++)
            {
                driverManager.SetItem(Drivers[i]);
            }
        }

        private void SetTeams()
        {
            int teamCount = 11;
            TeamManager teamManager = new TeamManager();
            for (int i = 0; i < teamCount; i++)
            {
                teamManager.SetItem(Teams[i]);
            }
        }

        private void SetEngines()
        {
            int engineCount = 8;
            EngineManager engineManager = new EngineManager();
            for (int i = 0; i < engineCount; i++)
            {
                engineManager.SetItem(Engines[i]);
            }
        }

        private void SetTyres()
        {
            int tyreCount = 3;
            TyreManager tyreManager = new TyreManager();
            for (int i = 0; i < tyreCount; i++)
            {
                tyreManager.SetItem(Tyres[i]);
            }
        }

        private void SetFuels()
        {
            int fuelCount = 9;
            FuelManager fuelManager = new FuelManager();
            for (int i = 0; i < fuelCount; i++)
            {
                fuelManager.SetItem(Fuels[i]);
            }
        }

        private void SetTracks()
        {
            int trackCount = 16;
            TrackManager trackManager = new TrackManager();
            for (int i = 0; i < trackCount; i++)
            {
                trackManager.SetItem(Tracks[i]);
            }
        }
    }
}
*/
