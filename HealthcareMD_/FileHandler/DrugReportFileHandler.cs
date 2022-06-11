using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HealthcareMD_.Model;

namespace HealthcareMD_.FileHandler
{
    internal class DrugReportFileHandler : FileHandlerInterface
    {
        private static readonly string filePath = "data/drugReports.csv";
        private static readonly string regexString = "#(\\d+)#(\\d+)#([\\w\\s]*)";
        public List<object> Read()
        {
            // id # drugId # reason
            Regex regexObj = new Regex(regexString);
            List<object> list = new List<object>();

            foreach (string line in File.ReadLines(filePath))
            {
                Match matchResult = regexObj.Match(line);
                if (matchResult.Success)
                {
                    if (line.Equals("")) break;
                    DrugReport drugReport = new DrugReport();
                    drugReport.FromCSV(matchResult.Groups);
                    list.Add(drugReport);
                }
                else
                {
                    if (line.Equals("")) break;
                    throw new ArgumentException("Regex issue");
                }

            }
            return list;
        }

        public int Write(string[] newLines)
        {
            try
            {
                System.IO.File.WriteAllText(filePath, "");
                System.IO.File.WriteAllLines(filePath, newLines);
                return 0;
            }
            catch { return -1; }


        }

    }
}
