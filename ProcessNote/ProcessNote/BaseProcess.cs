using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessNote
{
    public class BaseProcess
    {
        public static ObservableCollection<BaseProcess> Processses { get; set; }
        public int PID { get; set; }
        public string Name { get; set; }
        public string CPUUsage { get; set; }
        public string MemoryUsage { get; set; }
        public string RunningTime { get; set; }
        public DateTime StartTime { get; set; }

        public BaseProcess(int pID, string name)
        {
            if (Processses == null)
            {
                Processses = new ObservableCollection<BaseProcess>();
            }
            this.PID = pID;
            this.Name = name;
        }

        public static BaseProcess GetBaseProcessByPID(int PID )
        {
            foreach (var item in BaseProcess.Processses)
            {
                if (item.PID == PID)
                {
                    return item;
                }
            }
            throw new NotImplementedException();
        }
    }
}
