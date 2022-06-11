/***********************************************************************
 * Module:  User.cs
 * Author:  Darko
 * Purpose: Definition of the Class Model.User
 ***********************************************************************/

using System;
using HealthcareMD_;

namespace Model
{
   public class User
   {
      private string firstName;
        public string Ime => firstName;
      private string lastName;
        public string Prezime => lastName;
      private int id;
        public int Id => id;
      private string username;
        public string KorisnickoIme => username;
      private string password;
        public string Lozinka => password;
      private string phoneNumber;
        public string BrojTelefona => phoneNumber;
      private DateTime dateOfBirth;
        public DateTime DatumRodjenja=>dateOfBirth;
      private Gender gender;
        public Gender pol => gender;
        private string adress;
        public string Adresa => adress;
      private bool Guest;
        public bool GuestNalog => Guest;
      private string Email;
        public string Mail => Email;
        private AccountType accType;
        public User(string fn,string ln,int i,string un,string pas,string pn,DateTime date, Gender g,string ad,bool gu,string mejl,AccountType accountType)
        {
            firstName = fn;
            lastName = ln;
            id = i;
            username = un;
            password = pas;
            phoneNumber = pn;
            dateOfBirth = date;
            gender = g;
            adress = ad;
            Guest = gu;
            Email = mejl;
            accType = accountType;
        }
        public User(string fn, string ln, int i, string un, string pas, string pn, DateTime date, Gender g, string ad, bool gu, string mejl)
        {
            firstName = fn;
            lastName = ln;
            id = i;
            username = un;
            password = pas;
            phoneNumber = pn;
            dateOfBirth = date;
            gender = g;
            adress = ad;
            Guest = gu;
            Email = mejl;
        }
    }
}