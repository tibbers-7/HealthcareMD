using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Participant
    {
       private string name;

       public string Name => name;

       private string occupation;

       public string Occupation => occupation;

       public Participant(string name,string occupation)
        {
            this.name = name;
            this.occupation = occupation;
        }
    }
}
