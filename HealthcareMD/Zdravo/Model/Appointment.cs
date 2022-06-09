// File:    Appointment.cs
// Author:  Anja
// Created: Monday, March 28, 2022 2:54:34 PM
// Purpose: Definition of Class Appointment

using Controller;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HealthcareMD;
using HealthcareMD.Controller;

namespace Model
{
    public class Appointment
   {
        private int id;
        public int Id { get { return id; } set { id = value; } }
        private TimeOnly time;
        public TimeOnly Time { get { return time; } set { time = value; } }
        private DateOnly date;
        public DateOnly Date { get { return date; } set { date = value; } }
        public string DateString { get { return date.ToString("dd/MM/yyyy"); } set { date = Tools.ParseDate(value); } }
        private int duration;
        public int Duration { get { return duration; } set { duration = value; } }
        private int doctor;
        public int Doctor { get { return doctor; } set { doctor = value; } }
        private int doctorSchedules;
        public int DoctorSchedules { get { return doctorSchedules; } set { doctorSchedules = value; } }
        private int patient;
        public int Patient { get { return patient; } set { patient = value; } }
        private int room;
        public int Room { get { return room; } set { room = value; } }
        private bool emergency;
        public bool Emergency { get { return emergency; } set { emergency = value; } }
        private Status status;
        public Status Status { get { return status; } set { status = value; } }
        public string EmergencyChar { get { if (emergency) return "DA"; else return "NE"; } set { if (value.Equals("DA")) emergency = true; else emergency = false; } }

        private bool hasPassed;
        public bool HasPassed { get { return hasPassed; } set { hasPassed = value; } }
        private List<Report> reports;
        public List<Report> Reports { get { return reports; } set { reports = value; } }
        private char type;
        public char Type { get { return type; } set { type = value; } }

        public Appointment()
        {
            reports = new List<Report>();
        }
        public void FromCSV(GroupCollection csvValues)
        {
            id= int.Parse(csvValues[1].Value);
            patient = int.Parse(csvValues[2].Value);
            room = int.Parse(csvValues[3].Value);
            date = DateOnly.Parse(csvValues[4].Value);
            time = TimeOnly.Parse(csvValues[5].Value);
            duration = int.Parse(csvValues[6].Value);
            doctor = int.Parse(csvValues[7].Value);
            doctorSchedules= int.Parse(csvValues[8].Value);
            type =csvValues[9].Value.ToCharArray()[0];
            if (csvValues[10].Value == "Y") emergency = true; else emergency= false;
            switch (csvValues[11].Value)
            {
                case "A":
                    status = Status.accepted;
                    break;
                case "D":
                    status = Status.denied;
                    break;
                default:
                    status = Status.waiting;
                    break;
            }
 
            DateTime apptDT = date.ToDateTime(time);
            if (apptDT < DateTime.Now) hasPassed = true; else hasPassed = false;

        }

       
        internal string ToCSV()
        {
            //1,3253,38G,2022/01/01,13:00,30,32
            Regex regexObj = new Regex("\\d+:\\d{2}");
            Match matchResult = regexObj.Match(time.ToString());
            string _time=matchResult.Value;
            char _emergency,_status;
            if (emergency) _emergency = 'Y'; else _emergency = 'N';
            switch (status)
            {
                case Status.accepted:
                    _status = 'A';
                    break;
                case Status.denied:
                    _status = 'D';
                    break;
                default:
                    _status = 'W';
                    break;
            }
            string res = id.ToString()+","+patient.ToString() + "," + room + "," + date.ToString() + "," + _time + "," + duration.ToString() + "," + doctor.ToString()+"," +doctorSchedules.ToString()+","+type+","+_emergency+","+_status;
            return res;
        }

        public void AddReport(Report r)
        {
            reports.Add(r);
        }
    }        

}