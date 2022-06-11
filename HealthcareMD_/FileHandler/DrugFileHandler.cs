using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Model;

namespace HealthcareMD_.FileHandler
{
    internal class DrugFileHandler : FileHandlerInterface
    {
        private static readonly string filePath = "data/drugs.csv";
        private static readonly string regexString = "#(\\d+)#(\\w+)#([\\w\\s]+)#(A|D|W|R)#([\\w\\s;]*)#([\\w\\s.,;\"()-]*)#(\\d*)";
                                                      // id  # ime  #    tip    #  status #  sastojci  #   opis
        public List<object> Read()
        {
            
            Regex regexObj = new Regex(regexString);
            List<object> list = new List<object>();

            foreach (string line in File.ReadLines(filePath))
            {
                Match matchResult = regexObj.Match(line);
                if (matchResult.Success)
                {
                    if (line.Equals("")) break;
                    Drug drug = new Drug();
                    drug.FromCSV(matchResult.Groups);
                    list.Add(drug);
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
            } catch { return -1; }
        }
    }
}
