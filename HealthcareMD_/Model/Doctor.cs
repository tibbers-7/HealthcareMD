// File:    Doctor.cs
// Author:  Anja
// Created: Monday, March 28, 2022 2:51:36 PM
// Purpose: Definition of Class Doctor

namespace Model
{
    public class Doctor 
   {
        private int id;
        public int Id => id;
        
        private string name;
        public string Name => name;

        private string lastName;
        public string LastName => lastName;

        private string specialization;
        public string Specialization => specialization;

        public Doctor(int id,string name,string ln,string spec)
        {
            this.id = id;
            this.name = name;
            this.lastName = ln;
            this.specialization = spec;
        }

        public Doctor()
        {
        }
    }
}