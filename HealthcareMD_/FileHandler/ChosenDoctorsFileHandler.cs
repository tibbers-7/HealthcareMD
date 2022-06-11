using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HealthcareMD_.FileHandler
{
    internal class ChosenDoctorsFileHandler : FileHandlerInterface
    {
        private static readonly string filePath = "data/chosenDoctors.csv";
        private static readonly string regexString = "(\\d+),{(\\d+,\\d+,\\d+,\\d+,\\d+,\\d+,\\d+)}";
        //                                              INT id,INT patientId,INT room,DATEONLY date,TIMEONLY time,INT duration,INT doctorId,INT scheduledDoctorId,CHAR type,CHAR emergency,CHAR status


        public List<object> Read()
        {

            Regex regexObj = new Regex(regexString);
            List<object> list = new List<object>();

            foreach (string line in File.ReadLines(filePath))
            {
                Match matchResult = regexObj.Match(line);
                if (matchResult.Success)
                {
                    ChosenDoctors doctors = new ChosenDoctors();
                    doctors.FromCSV(matchResult.Groups);
                    list.Add(doctors);
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
            throw new NotImplementedException();
        }

        
    }
}
