using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessNote
{
    class ProcessHandler
    {
        public static List<BaseProcess> LoadProcesses()
        {
            List<BaseProcess> processes = new List<BaseProcess>();
            foreach (var item in Process.GetProcesses())
            {
                processes.Add(new BaseProcess(item.Id, item.ProcessName));
            }
            return processes;

        }
    }
}
