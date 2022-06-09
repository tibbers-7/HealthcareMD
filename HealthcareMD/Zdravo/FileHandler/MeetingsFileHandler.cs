using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Model;

namespace FileHandler
{
    public class MeetingsFileHandler
    {
        private const string filepath= "data/meetings.txt";
        public ObservableCollection<Meeting> Load()
        {

            ObservableCollection<Meeting> meetings = new ObservableCollection<Meeting>();
            string[] lines = System.IO.File.ReadAllLines(filepath);
            foreach (var line in lines)
            {
                string[] parameters = line.Split(',');
                int id=int.Parse(parameters[0]);
                string description=parameters[1];
                string date = parameters[2];
                ObservableCollection<string> users = new ObservableCollection<string>();
                string time = parameters[3];
                if(parameters.Length > 4)
                {
                    string[] usersParameter=parameters[4].Split('.');
                    foreach(string userString in usersParameter)
                    {
                        users.Add(userString);
                    }
                }
                Meeting meeting = new Meeting(id,description, date, time, users);
                meetings.Add(meeting);

            }
            return meetings;
        }
        public void addNewMeeting(Meeting newMeeting){
            string[] lines = System.IO.File.ReadAllLines(filepath);
            string[] newLines = new string[lines.Length + 1];
            for (int i = 0; i < lines.Length; i++)
            {
                newLines[i] = lines[i];
            }
            newLines[lines.Length] = newMeeting.Id.ToString() + "," + newMeeting.Description + "," + newMeeting.Date + "," + newMeeting.Time+",";
            System.IO.File.WriteAllText(filepath, "");
            System.IO.File.WriteAllLines(filepath, newLines);
        }
        public void addParticipant(Participant participant,int id) {
            string[] lines = System.IO.File.ReadAllLines(filepath);
            for (int i = 0; i < lines.Length; i++)
            {

                string[] parameters = lines[i].Split(',');
                int idFromFile = int.Parse(parameters[0]);
                if (idFromFile == id)
                {
                    lines[i] = lines[i] + participant.Name+".";
                }

            }
            System.IO.File.WriteAllText(filepath, "");
            System.IO.File.WriteAllLines(filepath, lines);
        }
    }
}
