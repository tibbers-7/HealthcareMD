/***********************************************************************
 * Module:  Patient.cs
 * Author:  Darko
 * Purpose: Definition of the Class FileHandler.Patient
 ***********************************************************************/

using System;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HealthcareMD;
namespace FileHandler
{
    public class PatientFileHandler
   {
        public List<Patient> Load()
        {
            // TODO: implement
            string[] lines = System.IO.File.ReadAllLines(filepath);
            List<Patient> pacijenti = new List<Patient>();
            foreach (var s in lines)
            {
                if (s.Equals("")) break;
                string[] ss = s.Split(',');
                //(string fn, string ln, int i, string un, string pas, string pn, DateTime date, Gender g, string ad, bool gu,int cardNumber)
                //ime prez id
                int id = Int32.Parse(ss[2]);
                DateTime datum;
                datum = Convert.ToDateTime(ss[6]);
                Gender pol;
                if (ss[7].Equals("M")) pol = Gender.male;
                else pol = Gender.female;
                bool guest = false;
                if (ss[9].Equals("true")) guest = true;
                List<int> allergenIds = new List<int>();
                if (ss.Length == 12)
                {
                    String[] ids = ss[11].Split('.');
                    foreach (string stringic in ids)
                    {
                        if (!stringic.Equals(""))
                        {

                            allergenIds.Add(Int32.Parse(stringic));
                        }
                    }
                }
                // darko,filipovic,2
                Patient p = new Patient(ss[0], ss[1], id, ss[3], ss[4], ss[5], datum, pol, ss[8], guest, ss[10], allergenIds);
                pacijenti.Add(p);
            }
            Console.WriteLine("ISPIIIIIIIIS");
            return pacijenti;
        }


        public ObservableCollection<Patient> read()
        {
            
            ObservableCollection<Patient> pacijenti = new ObservableCollection<Patient>();
            string[] lines = System.IO.File.ReadAllLines(filepath);
            foreach (var s in lines)
            {
                string[] ss = s.Split(',');
                //(string fn, string ln, int i, string un, string pas, string pn, DateTime date, Gender g, string ad, bool gu,int cardNumber)
                int id = Int32.Parse(ss[2]);
                DateTime datum;
                datum = Convert.ToDateTime(ss[6]);
                Gender pol;
                if (ss[7].Equals("M")) pol = Gender.male;
                else pol = Gender.female;
                bool guest = false;
                if (ss[9].Equals("true")) guest = true;
                List<int> allergenIds = new List<int>();
                if (ss.Length == 12)
                {
                    String[] ids = ss[11].Split('.');
                    int jedan;
                    foreach (string idJedan in ids)
                    {
                        if (!idJedan.Equals(""))
                        {
                            jedan = Int32.Parse(idJedan);
                            allergenIds.Add(jedan);
                        }
                    }
                }
                
                Patient p = new Patient(ss[0], ss[1], id, ss[3], ss[4], ss[5], datum, pol, ss[8], guest, ss[10], allergenIds);
                pacijenti.Add(p);
            }
            Console.WriteLine("ISPIIIIIIIIS");
            return pacijenti;

        }
        public void deleteById(int id)
        {
            
            string[] lines = System.IO.File.ReadAllLines(filepath);
            string[] newLines = new string[lines.Length - 1];
            int i = 0;
            foreach(var s in lines)
            {
                string[] ss = s.Split(',');
                int idd = Int32.Parse(ss[2]);
                if (idd != id)
                {
                    newLines[i] = s;
                    i++;
                }
                
            }
            System.IO.File.WriteAllText(filepath, "");
            System.IO.File.WriteAllLines(filepath, newLines);
        }
      public void addPatient(Patient p)
        {
            string[] lines = System.IO.File.ReadAllLines(filepath);
            string[] newLines = new string[lines.Length + 1];
            for(int i = 0; i < lines.Length; i++)
            {
                newLines[i] = lines[i];
            }
            string pol = "M";
            string guest = "false";
            if (p.GuestNalog == true) guest = "true";
            if (p.pol == Gender.female) pol = "F";
            newLines[lines.Length] = p.Ime + "," + p.Prezime + "," + p.Id.ToString() + "," + p.KorisnickoIme + "," + p.Lozinka + "," + p.BrojTelefona + "," + p.DatumRodjenja.ToString() + "," + pol + "," + p.Adresa + "," + guest + "," + p.Mail + "," ;
            System.IO.File.WriteAllText(filepath, "");
            System.IO.File.WriteAllLines(filepath, newLines);
        }
        public void updatePatient(Patient p)
        {
            string[] lines = System.IO.File.ReadAllLines(filepath);
            string pol = "M";
            string guest = "false";
            if (p.GuestNalog == true) guest = "true";
            if (p.pol == Gender.female) pol = "F";
            String allergenIds="";
            for(int i = 0; i < p.Allergens.Count; i++)
            {
                if (i != p.Allergens.Count - 1)
                {
                    allergenIds += p.Allergens[i].Id.ToString() + '.';

                }
                else allergenIds += p.Allergens[i].Id.ToString();
            }
            string novaLinija = p.Ime + "," + p.Prezime + "," + p.Id.ToString() + "," + p.KorisnickoIme + "," + p.Lozinka + "," + p.BrojTelefona + "," + p.DatumRodjenja.ToString() + "," + pol + "," + p.Adresa + "," + guest + "," + p.Mail + "," + allergenIds;
            for (int i = 0; i < lines.Length; i++)
            {
               
                string[] ss = lines[i].Split(',');
                int idd = Int32.Parse(ss[2]);
                if (idd == p.Id)
                {
                    lines[i] = novaLinija;
                }

            }
            System.IO.File.WriteAllText(filepath, "");
            System.IO.File.WriteAllLines(filepath, lines);
        }
        public string filepath= "data/Patients.txt";
   
   }
}