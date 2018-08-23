using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessNote
{
    public class BaseProcess
    {
        public int PID { get; set; }
        public string Name { get; set; }

        public BaseProcess(int pID, string name)
        {
            this.PID = pID;
            this.Name = name;
        }
    }
}
