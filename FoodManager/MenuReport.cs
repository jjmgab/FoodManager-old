using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodManager
{
    public partial class MenuReport : Form
    {
        private List<DayMenu> DayMenus { get; set; }

        public MenuReport(List<DayMenu> dayMenu, int numberOfDays)
        {
            InitializeComponent();
            // get next 10 days, including today
            DayMenus = dayMenu
                .Where(x => x.Date >= DateTime.Now.Date)
                .OrderBy(x => x.Date)
                .Take(numberOfDays)
                .ToList();
            dataGridViewMenuReport.DataSource = DayMenus;
            dataGridViewMenuReport.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMenuReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMenuReport.Refresh();
        }

        // as default, 10 next days are assumed
        public MenuReport(List<DayMenu> dayMenu) : this(dayMenu, 10) { }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "CSV (Comma Separated Value) files (*.csv)|*.csv";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            saveFileDialog1.AddExtension = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.ValidateNames = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (MenuCsvHelper.SaveCsvFile((List<DayMenu>)dataGridViewMenuReport.DataSource, saveFileDialog1.FileName))
                    this.Close();
            }
        }
    }
}
