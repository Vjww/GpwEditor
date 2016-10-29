/*
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;

namespace SaveGameEditor
{
    public partial class MainForm : Form
    {
        // flag for any changes to the form since the last save
        private bool IsModified = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // set form title text
            Text = String.Format(Text, Common.Properties.Settings.Default.ApplicationName) + 
                " - Save Game Editor";

            FormatControls();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ExitProgram())
            {
                // stay in program
                e.Cancel = true;
                return;
            }

            // else exit
            Properties.Settings.Default.Save();
        }

        private void SectionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // when switching panels, assume that the user has modified the data since the last export
            IsModified = true;

            GeneralPanel.Visible = false;
            TeamsPanel.Visible = false;
            EngineeringPanel.Visible = false;
            CommercialPanel.Visible = false;
            RacingPanel.Visible = false;

            int panel = int.Parse((sender as RadioButton).Tag.ToString());
            switch (panel)
            {
                case 1:
                    GeneralPanel.Visible = true;
                    break;
                case 2:
                    TeamsPanel.Visible = true;
                    break;
                case 3:
                    EngineeringPanel.Visible = true;
                    break;
                case 4:
                    CommercialPanel.Visible = true;
                    break;
                case 5:
                    RacingPanel.Visible = true;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveData(false);
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            SaveData(true);
        }

        private bool ExitProgram()
        {
            // show prompt if data on the form has been changed
            if (IsModified)
            {
                // confirm whether to exit the application
                DialogResult result = MessageBox.Show(
                    "Are you sure you wish to exit the application?" +
                    Environment.NewLine + Environment.NewLine +
                    "Any changes that have not been saved will be lost.",
                    "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                return result == DialogResult.Yes ? true : false;
            }

            // else
            return true;
        }

        private void LoadData()
        {
            // prompt user to select file
            DialogResult result;

            ProgramOpenFileDialog.InitialDirectory = Common.Properties.Settings.Default.GpwGameFolderPath;
            ProgramOpenFileDialog.FileName = null;
            result = ProgramOpenFileDialog.ShowDialog();

            // cancel if file was not selected
            if (result != DialogResult.OK)
                return;

            string filePath = Path.GetDirectoryName(ProgramOpenFileDialog.FileName);
            string selectedGpwSaveGameFilePath = ProgramOpenFileDialog.FileName;
            string selectedGpwLanguageFilePath = Path.Combine(filePath, Common.Properties.Settings.Default.GpwLanguageFileName);
            Common.Properties.Settings.Default.GpwSaveGameFilePath = selectedGpwSaveGameFilePath;
            Common.Properties.Settings.Default.GpwLanguageFilePath = selectedGpwLanguageFilePath;

            // abort if required files are missing
            if ((!File.Exists(Common.Properties.Settings.Default.GpwSaveGameFilePath)) ||
                (!File.Exists(Common.Properties.Settings.Default.GpwLanguageFilePath)))
            {
                MessageBox.Show(
                    "Unable to import data from files. Operation aborted." +
                    Environment.NewLine + Environment.NewLine +
                    "Unable to locate one or both of the following files." +
                    Environment.NewLine + Environment.NewLine +
                    Common.Properties.Settings.Default.GpwSaveGameFilePath + Environment.NewLine +
                    Common.Properties.Settings.Default.GpwLanguageFilePath,
                    "Import failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // load data and populate form controls
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SaveGameData data = new SaveGameData();
                data.Import();
                PopulateControls(data);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            // load complete
            MessageBox.Show("Load complete!");
        }

        private void SaveData(bool IsSaveAs)
        {
            string filePath;
            string selectedGpwSaveGameFilePath;
            string selectedGpwLanguageFilePath;

            if (IsSaveAs)
            {
                // prompt user to select file
                DialogResult result;

                ProgramOpenFileDialog.InitialDirectory = Common.Properties.Settings.Default.GpwGameFolderPath;
                ProgramOpenFileDialog.FileName = null;
                result = ProgramOpenFileDialog.ShowDialog();

                // cancel if file was not selected
                if (result != DialogResult.OK)
                    return;
            }

            if (IsSaveAs)
            {
                // get user to indicate which file to save to
                filePath = Path.GetDirectoryName(ProgramOpenFileDialog.FileName);
                selectedGpwSaveGameFilePath = ProgramOpenFileDialog.FileName;
            }
            else
            {
                // else save to the file that was last loaded
                filePath = Path.GetDirectoryName(Common.Properties.Settings.Default.GpwSaveGameFilePath);
                selectedGpwSaveGameFilePath = Common.Properties.Settings.Default.GpwSaveGameFilePath;
            }

            selectedGpwLanguageFilePath = Path.Combine(filePath, Common.Properties.Settings.Default.GpwLanguageFileName);
            Common.Properties.Settings.Default.GpwSaveGameFilePath = selectedGpwSaveGameFilePath;
            Common.Properties.Settings.Default.GpwLanguageFilePath = selectedGpwLanguageFilePath;

            // abort if required files are missing
            if ((!File.Exists(Common.Properties.Settings.Default.GpwSaveGameFilePath)) ||
                (!File.Exists(Common.Properties.Settings.Default.GpwLanguageFilePath)))
            {
                MessageBox.Show(
                    "Unable to export data to files. Operation aborted." +
                    Environment.NewLine + Environment.NewLine +
                    "Unable to locate one or both of the following files." +
                    Environment.NewLine + Environment.NewLine +
                    Common.Properties.Settings.Default.GpwSaveGameFilePath + Environment.NewLine +
                    Common.Properties.Settings.Default.GpwLanguageFilePath,
                    "Export failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // populate records and save data
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SaveGameData data = new SaveGameData();
                PopulateRecords(data);
                data.Export();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            // save complete
            MessageBox.Show("Save complete!");

            IsModified = false;
        }

        private void ConfigureDataGridViewControl(DataGridView control)
        {
            control.Columns[0].FillWeight = 200;
            control.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            control.AllowUserToAddRows = false;
            control.AllowUserToDeleteRows = false;
            control.AllowUserToResizeColumns = false;
            control.AllowUserToResizeRows = false;
            control.MultiSelect = false;
            control.RowHeadersVisible = false;
        }

        private void FormatControls()
        {
            // get panels and put into a list
            Collection<Panel> panelList = new Collection<Panel>();
            panelList.Add(GeneralPanel);
            panelList.Add(TeamsPanel);
            panelList.Add(EngineeringPanel);
            panelList.Add(CommercialPanel);
            panelList.Add(RacingPanel);

            // format data grids
            foreach (var panel in panelList)
            {
                foreach (var item in (panel as TabPage).Controls)
                {
                    if (item is DataGridView)
                        ConfigureDataGridViewControl(item as DataGridView);
                }
            }

            // format read-only columns in data grids
            //EnginesDataGridView.Columns[0].ReadOnly = true;
            //EnginesDataGridView.Columns[0].HeaderText = String.Format(
            //    "{0} (read-only)", EnginesDataGridView.Columns[0].HeaderText);
            //TyresDataGridView.Columns[0].ReadOnly = true;
            //TyresDataGridView.Columns[0].HeaderText = String.Format(
            //    "{0} (read-only)", TyresDataGridView.Columns[0].HeaderText);
            //FuelsDataGridView.Columns[0].ReadOnly = true;
            //FuelsDataGridView.Columns[0].HeaderText = String.Format(
            //    "{0} (read-only)", FuelsDataGridView.Columns[0].HeaderText);
            //FastestLapsDataGridView.Columns[0].ReadOnly = true;
            //FastestLapsDataGridView.Columns[0].HeaderText = String.Format(
            //    "{0} (read-only)", FastestLapsDataGridView.Columns[0].HeaderText);
        }

        private void PopulateControls(SaveGameData data)
        {
            //// populate teams
            //TeamsDataGridView.DataSource = data.Teams;

            //// populate drivers
            //DriversDataGridView.DataSource = data.Drivers;

            //// populate engines
            //EnginesDataGridView.DataSource = data.Engines;

            //// populate tyres
            //TyresDataGridView.DataSource = data.Tyres;

            //// populate fuels
            //FuelsDataGridView.DataSource = data.Fuels;

            //// populate fastest laps
            //FastestLapsDataGridView.DataSource = data.Tracks;
            //FastestLapsDataGridView.Columns["nameDataGridViewTextBoxColumn5"].FillWeight = 150;
            //FastestLapsDataGridView.Columns["driverDataGridViewComboBoxColumn"].FillWeight = 150;
            //// bind combobox column
            //DataGridViewComboBoxColumn flCol1 =
            //    FastestLapsDataGridView.Columns["driverDataGridViewComboBoxColumn"] as DataGridViewComboBoxColumn;
            //flCol1.DataSource = data.Drivers;
            //flCol1.DisplayMember = "Name";
            //flCol1.ValueMember = "NameId";
            //flCol1.ValueType = typeof(string);
            //// bind combobox column
            //DataGridViewComboBoxColumn flCol2 =
            //    FastestLapsDataGridView.Columns["teamDataGridViewComboBoxColumn"] as DataGridViewComboBoxColumn;
            //flCol2.DataSource = data.Teams;
            //flCol2.DisplayMember = "Name";
            //flCol2.ValueMember = "NameId";
            //flCol2.ValueType = typeof(string);
        }

        private void PopulateRecords(SaveGameData data)
        {
            //// populate teams
            //data.Teams = TeamsDataGridView.DataSource as TeamCollection;

            //// populate drivers
            //data.Drivers = DriversDataGridView.DataSource as DriverCollection;

            //// populate engines
            //data.Engines = EnginesDataGridView.DataSource as EngineCollection;

            //// populate tyres
            //data.Tyres = TyresDataGridView.DataSource as TyreCollection;

            //// populate fuels
            //data.Fuels = FuelsDataGridView.DataSource as FuelCollection;

            //// populate fastest laps
            //data.Tracks = FastestLapsDataGridView.DataSource as TrackCollection;
        }
    }
}
*/
