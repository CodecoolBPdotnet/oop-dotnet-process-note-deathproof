using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ProcessNote
{
    class ProcessHandler
    {
        public static ObservableCollection<BaseProcess> LoadProcesses()
        {
            ObservableCollection<BaseProcess> processes = new ObservableCollection<BaseProcess>();
            foreach (var item in Process.GetProcesses())
            {
                processes.Add(new BaseProcess(item.Id, item.ProcessName));
                BaseProcess.Processses.Add(new BaseProcess(item.Id, item.ProcessName));
            }
            return processes;

        }

        public static string GetProcessDetails(BaseProcess selectedProcess)
        {
            Process originalProc = Process.GetProcessById(selectedProcess.PID);
            BaseProcess proc = BaseProcess.GetBaseProcessByPID(selectedProcess.PID);
            proc.StartTime = originalProc.StartTime;

            var CPUcounter = new PerformanceCounter("Process", "% Processor Time", selectedProcess.Name);
            var RAMcounter = new PerformanceCounter("Process", "Working Set", selectedProcess.Name);

            CPUcounter.NextValue();
            RAMcounter.NextValue();

            Thread.Sleep(100);


            string result = "";
            result += ($"CPU usage: {Math.Round(CPUcounter.NextValue())} " +
                $"%\nMemory usage: {Math.Round(RAMcounter.NextValue() / 1024 / 1024,2)} MB" +
                $"\nRunning time: { (TimeSpan.FromSeconds(Math.Round((DateTime.Now - proc.StartTime).TotalSeconds))).ToString(@"dd\:hh\:mm\:ss") } " +
                $"\nStart time: {proc.StartTime.ToString()} ");

            return result;
        }
    }
}
