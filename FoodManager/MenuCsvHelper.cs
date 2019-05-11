using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodManager
{
    /// <summary>
    /// A helper class for csv file handling specific for menu entries.
    /// </summary>
    static class MenuCsvHelper
    {
        /// <summary>
        /// Debug mode for message boxes showing file progress.
        /// </summary>
        public static bool DebugMode { get; set; } = false;

        /// <summary>
        /// Loads a csv file.
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="rdir"></param>
        /// <param name="workingDate"></param>
        /// <param name="dataGridView"></param>
        /// <param name="newFileCreated"></param>
        /// <returns></returns>
        public static bool LoadCsvFile(string fname, string rdir, DateTime workingDate, DataGridView dataGridView, ref bool newFileCreated)
        {
            // check if file exists
            if (File.Exists(String.Format(@".\{0}\{1}.csv", rdir, fname)))
            {
                try
                {
                    // opening file
                    using (StreamReader reader = new StreamReader(String.Format(@"{0}\{1}.csv", rdir, fname)))
                    using (CsvReader csv = new CsvReader(reader))
                    {
                        List<DayMenu> records = csv.GetRecords<DayMenu>().ToList();
                        if (DebugMode)
                            MessageBox.Show(String.Format("File \"{0}.csv\" was loaded successfully!", fname), "CSV loading success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView.DataSource = records;
                        dataGridView.Columns[0].ReadOnly = true;
                        dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView.Columns[1].ReadOnly = true;
                        dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView.Refresh();
                    }
                    return true;
                }
                catch (IOException)
                {
                    // file possibly open using any other application
                    if (DebugMode)
                        MessageBox.Show(String.Format("Filename \"{0}\" is unavailable.", fname), "CSV loading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // file does not exist; creating new one...
                List<DayMenu> dayMenus = MenuDateHelper.CreateWeekMenuList(workingDate);
                dataGridView.DataSource = dayMenus;
                dataGridView.Columns[0].ReadOnly = true;
                dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Columns[1].ReadOnly = true;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Refresh();

                // try to save new file
                if (SaveCsvFile(dayMenus, workingDate.ToShortDateString(), rdir))
                {
                    MessageBox.Show(String.Format("File \"{0}.csv\" did not exist. It was created and loaded successfully.", fname), "CSV create success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    newFileCreated = true;
                    return true;
                }
                else
                {
                    MessageBox.Show(String.Format("File \"{0}.csv\" did not exist and could not be created.", fname), "CSV create error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        /// <summary>
        /// Saves a list of menu entries to a csv file in given directory.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="fname"></param>
        /// <param name="rdir"></param>
        /// <returns></returns>
        public static bool SaveCsvFile(List<DayMenu> source, string fname, string rdir)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(String.Format(@"{0}\{1}.csv", rdir, fname)))
                using (CsvWriter csvWriter = new CsvWriter(writer))
                {
                    csvWriter.WriteRecords(source.AsEnumerable());
                    writer.Flush();
                    MessageBox.Show(String.Format("File \"{0}.csv\" was saved successfully!", fname), "CSV saving success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(String.Format("Filename \"{0}\" is unavailable.", fname), "CSV saving error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.StackTrace);
            }
            return false;
        }

        /// <summary>
        /// Saves a list of menu entries to a csv file.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="fname"></param>
        /// <param name="rdir"></param>
        /// <returns></returns>
        public static bool SaveCsvFile(List<DayMenu> source, string path)
        {
            if (path.Substring(path.LastIndexOf("."), 4) == ".csv")
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(path))
                    using (CsvWriter csvWriter = new CsvWriter(writer))
                    {
                        csvWriter.WriteRecords(source.AsEnumerable());
                        writer.Flush();
                        MessageBox.Show(String.Format("File \"{0}.csv\" was saved successfully!", path.Substring(path.LastIndexOf(@"\")+1)), "CSV saving success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return true;
                }
                catch (IOException ex)
                {
                    MessageBox.Show(String.Format("Filename \"{0}\" is unavailable.", path.Substring(path.LastIndexOf(@"\")+1)), "CSV saving error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.StackTrace);
                }
            }
            else
                MessageBox.Show(String.Format("Filename \"{0}\" must have \"*.csv\" extension.", path.Substring(path.LastIndexOf(@"\") + 1)), "CSV saving error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;

        }
    }
}
