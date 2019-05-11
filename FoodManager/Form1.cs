using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodManager
{
    public partial class Form1 : Form
    {
        private bool comboBoxDataSourceChanged = true;
        public bool ComboBoxDataSourceChanged { get => comboBoxDataSourceChanged; set => comboBoxDataSourceChanged = value; }

        public static string ResourceDirectory { get; } = @".\rsc";
        public string Filename { get; set; } = "defaultFileName";
        public DateTime WorkingDate { get; set; } = DateTime.Now;

        public Form1()
        {
            InitializeComponent();

            comboBoxWeekFiles.DataSource = MenuFileHelper.GetListOfWeekFiles("????-??-??", ResourceDirectory, ".csv");
            SwapToDate(WorkingDate);
            comboBoxWeekFiles.SelectedIndex = comboBoxWeekFiles.FindString(MenuDateHelper.GetDateOfFirstDayOfTheWeek(WorkingDate).ToShortDateString());

            List<DayMenu> allEntries = MenuFileHelper.GetListOfAllEntries(ResourceDirectory);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("All entries: {0}\n", allEntries.Count);
            stringBuilder.AppendFormat("All breakfasts: {0}\n", allEntries.Where(x => x.Breakfast.Length > 0).Count());
            stringBuilder.AppendFormat("All days without entries: {0}\n", allEntries.Where(x => !(x.Breakfast.Length > 0 || x.Dinner.Length > 0 || x.Supper.Length > 0)).Count());
            stringBuilder.AppendFormat("Most eaten breakfast: {0}\n",
                allEntries.Where(x => x.Breakfast.Length > 0)
                .GroupBy(x => x.Breakfast)
                .OrderByDescending(x => x.Count())
                .First().Key);
            MessageBox.Show(stringBuilder.ToString());
        }

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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            MenuCsvHelper.SaveCsvFile((List<DayMenu>)dataGridViewMenu.DataSource, Filename, ResourceDirectory);   
        }

        private void buttonGoToDateExisting_Click(object sender, EventArgs e)
        {
            SwapToDate(DateTime.Parse(comboBoxWeekFiles.Text));
        }

        private void buttonGoToDateCustom_Click(object sender, EventArgs e)
        {
            SwapToDate(dateTimePicker.Value.Date);
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            MenuReport menuReport = new MenuReport(MenuFileHelper.GetListOfAllEntries(ResourceDirectory), Convert.ToInt32(numericUpDownPickNextDays.Value));
            DialogResult result = menuReport.ShowDialog();
        }
    }
}
