// File:    DoctorRepository.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:57:38 PM
// Purpose: Definition of Class DoctorRepository

using FileHandler;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Repository
{
   public class DoctorRepository
   {
      private ObservableCollection<Doctor> doctors;

    public DoctorRepository()
        {
            DoctorFileHandler fileHandler = new DoctorFileHandler();
            this.doctors = fileHandler.Load();
        }
       
      public Doctor getById(int id)
        {
            
            foreach(Doctor doctor in doctors)
            {
                if(doctor.Id == id)return doctor;
            }
            return null;
        }
        public ObservableCollection<Doctor> getAll()
        {
            DoctorFileHandler fileHandler = new DoctorFileHandler();
            this.doctors = fileHandler.Load();
            return this.doctors;
        }

        internal Doctor FindBySpecialization(string doctorSpecialty)
        {
            foreach(Doctor doctor in doctors)
            {
                if (doctor.Specialization.Equals(doctorSpecialty))
                {
                    return doctor;
                }
            }

            return null;
        }

        internal List<string> GetAllSpetializations()
        {
            List<string> spetializations=new List<string>();
            foreach (Doctor doctor in doctors)
            {
                if(!spetializations.Contains(doctor.Specialization)) spetializations.Add(doctor.Specialization);
            }
            return spetializations;
        }

        public string GetDoctorInfo(int doctorId)
        {
            Doctor doctor = getById(doctorId);
            string res = doctor.Name + " " + doctor.LastName + ", " + doctor.Specialization;
            return res;
        }

        internal string GetDoctorProfession(int doctorId)
        {
            Doctor doctor=getById(doctorId);
            return doctor.Specialization;
        }

        internal string GetDoctorName(int doctorId)
        {
            Doctor doctor = getById(doctorId);
            string res=doctor.Name+" "+doctor.LastName;
            return res;
        }
    }
}