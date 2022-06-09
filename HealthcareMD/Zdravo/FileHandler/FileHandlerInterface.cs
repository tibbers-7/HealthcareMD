using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareMD.FileHandler
{
    internal interface FileHandlerInterface
    {
        public List<object> Read();
        public int Write(string[] newLines);
    }
}
