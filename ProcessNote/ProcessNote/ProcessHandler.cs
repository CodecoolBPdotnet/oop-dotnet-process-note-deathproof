using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

        public static string GetProcessDetails(BaseProcess selectedProcess)
        {
            Process[] processes = Process.GetProcesses();
            var CPUcounter = new PerformanceCounter("Process", "% Processor Time", selectedProcess.Name);
            var RAMcounter = new PerformanceCounter("Process", "Working Set", selectedProcess.Name);

            foreach (Process process in processes)
            {
                if (process.Id == selectedProcess.PID)
                {
                    CPUcounter.NextValue();
                    RAMcounter.NextValue();
                }
            }

            Thread.Sleep(1000);
            string result = "";
            for (int i = 0; i < processes.Length; i++)
            {
                if (processes[i].Id == selectedProcess.PID)
                {
                result += ($"process: {processes[i].ProcessName} PID: {processes[i].Id} Ram usage: {Math.Round(RAMcounter.NextValue())} CPU usage: {Math.Round(CPUcounter.NextValue())}");
                }
            }
            return result;
        }
    }
}
