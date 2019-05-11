using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManager
{
    static class MenuFileHelper
    {
        /// <summary>
        /// Returns a list of filenames in descending order of all files with given extension,
        /// in given directory, satisfying provided pattern.
        /// </summary>
        /// <param name="fname">filename pattern</param>
        /// <param name="rdir">directory path</param>
        /// <param name="ext">file extension</param>
        /// <returns>list of filenames in descending order</returns>
        public static List<string> GetListOfWeekFiles(string fname, string rdir, string ext)
        {
            return System.IO.Directory.EnumerateFiles(rdir, fname + ext)
                .Select(x => x.Substring(x.Length - (fname + ext).Length, fname.Length))
                .OrderByDescending(x => x)
                .ToList();
        }

        public static List<DayMenu> GetListOfAllEntries(string rdir)
        {
            List<string> allFilenames = MenuFileHelper.GetListOfWeekFiles("????-??-??", rdir, ".csv");
            List<DayMenu> allEntries = new List<DayMenu>();

            foreach (string filename in allFilenames)
            {
                try
                {
                    // opening file
                    using (StreamReader reader = new StreamReader(String.Format(@"{0}\{1}.csv", rdir, filename)))
                    using (CsvReader csv = new CsvReader(reader))
                    {
                        allEntries.AddRange(csv.GetRecords<DayMenu>());
                    }
                }
                catch (IOException)
                {
                    // file possibly open using any other application
                }
            }

            return allEntries;
        }
    }
}
