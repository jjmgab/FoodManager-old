using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FoodManager
{
    /// <summary>
    /// The main window class.
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// Flag indicating if the data source in the combobox list of dates was changed.
        /// </summary>
        private bool comboBoxDataSourceChanged = true;

        /// <summary>
        /// Flag indicating if the data source in the combobox list of dates was changed.
        /// </summary>
        public bool ComboBoxDataSourceChanged { get => comboBoxDataSourceChanged; set => comboBoxDataSourceChanged = value; }

        /// <summary>
        /// Target csv file directory.
        /// </summary>
        public static string ResourceDirectory { get; } = @".\rsc";

        /// <summary>
        /// Target csv file name.
        /// </summary>
        public string Filename { get; set; } = "defaultFileName";

        /// <summary>
        /// Context date.
        /// </summary>
        public DateTime WorkingDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Constructor.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            comboBoxWeekFiles.DataSource = MenuFileHelper.GetListOfWeekFiles("????-??-??", ResourceDirectory, ".csv");
            SwapToDate(WorkingDate);
            comboBoxWeekFiles.SelectedIndex = comboBoxWeekFiles.FindString(MenuDateHelper.GetDateOfFirstDayOfTheWeek(WorkingDate).ToShortDateString());

            List<DayMenu> allEntries = MenuFileHelper.GetListOfAllEntries(ResourceDirectory);
        }

        /// <summary>
        /// Changes current date.
        /// </summary>
        /// <param name="date"></param>
        private void SwapToDate(DateTime date)
        {
            WorkingDate = MenuDateHelper.GetDateOfFirstDayOfTheWeek(date);
            Filename = WorkingDate.ToShortDateString();
            MenuCsvHelper.LoadCsvFile(Filename, ResourceDirectory, WorkingDate, dataGridViewMenu, ref comboBoxDataSourceChanged);
            this.Text = Filename;
            dateTimePicker.Value = WorkingDate;
            if (ComboBoxDataSourceChanged)
            {
                ComboBoxDataSourceChanged = false;
                comboBoxWeekFiles.DataSource = MenuFileHelper.GetListOfWeekFiles("????-??-??", ResourceDirectory, ".csv");
            }
            comboBoxWeekFiles.SelectedIndex = comboBoxWeekFiles.FindString(MenuDateHelper.GetDateOfFirstDayOfTheWeek(WorkingDate).ToShortDateString());
        }

        /// <summary>
        /// Saves changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            MenuCsvHelper.SaveCsvFile((List<DayMenu>)dataGridViewMenu.DataSource, Filename, ResourceDirectory);   
        }

        /// <summary>
        /// Change date to one of chosen from the existing dates in the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGoToDateExisting_Click(object sender, EventArgs e)
        {
            SwapToDate(DateTime.Parse(comboBoxWeekFiles.Text));
        }

        /// <summary>
        /// Change date to the one chosen from a DateTimePicker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGoToDateCustom_Click(object sender, EventArgs e)
        {
            SwapToDate(dateTimePicker.Value.Date);
        }

        /// <summary>
        /// Generates a report containing a chosen number of menu entries for upcoming days.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            MenuReport menuReport = new MenuReport(MenuFileHelper.GetListOfAllEntries(ResourceDirectory), Convert.ToInt32(numericUpDownPickNextDays.Value));
            DialogResult result = menuReport.ShowDialog();
        }
    }
}
