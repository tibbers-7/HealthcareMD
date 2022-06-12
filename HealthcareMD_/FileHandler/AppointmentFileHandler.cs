// File:    AppointmentFileHandler.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:35:07 PM
// Purpose: Definition of Class AppointmentFileHandler

using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using HealthcareMD_.FileHandler;

namespace FileHandler
{
    public class AppointmentFileHandler : FileHandlerInterface 
   {
      private static readonly string filePath= "data/appointments.csv";
        private static readonly string regexString = "(\\d+),(\\d+),(\\d*),(\\d*/\\d*/\\d*),(\\d*:\\d* [P|A]M),(\\d+),(\\d*),(\\d+),(O|A),(Y|N),(A|D|W)";
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
                    Appointment ap = new Appointment();
                    ap.FromCSV(matchResult.Groups);
                    list.Add(ap);
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