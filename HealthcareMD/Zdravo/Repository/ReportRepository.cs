using System.Collections.Generic;
using System.Linq;
using FileHandler;
using Model;
using HealthcareMD.FileHandler;

namespace Repository
{
    public class ReportRepository
    {
        private readonly ReportFileHandler fileHandler=new ReportFileHandler();
        private List<Report> reports;

        public ReportRepository()
        {
            InitReports();
        }

        private void InitReports()
        {
            List<object> reportList = fileHandler.Read();
            reports=new List<Report>();
            foreach (object reportObj in reportList)
            {
                Report report = (Report)reportObj;
                reports.Add(report);
            }
        }

        public List<Report> GetReports()
        {
            return reports;
        }

        public Report GetById(int id)
        {
            foreach (Report report in reports)
            {
                if (report.Id == id) return report;
            }
            return null;
        }

        public int AddNew(Report report)
        {
            report.Id = reports.Last().Id + 1;
            int listCount = reports.Count;
            string[] newLines = new string[listCount + 1];
            for (int i = 0; i < listCount; i++)
            {
                newLines[i] = reports[i].ToCSV();
            }
            newLines[listCount] = report.ToCSV();
            int errorCode=fileHandler.Write(newLines);
            InitReports();
            return errorCode;
        }

        internal int Update(Report newReport)
        {
            int listCount = reports.Count;
            string[] newLines = new string[listCount];
            int i = 0;
            foreach (Report report in reports)
            {
                if (newReport.Id != report.Id)
                {
                    newLines[i] = report.ToCSV();
                    
                }
                else newLines[i] = newReport.ToCSV();
                i++;
            }
            int errorCode=fileHandler.Write(newLines);
            InitReports();
            return errorCode;
        }
    }
}
