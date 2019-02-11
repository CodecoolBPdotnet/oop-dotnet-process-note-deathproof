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
            BaseProcess proc = BaseProcess.GetBaseProcessByPID(selectedProcess.PID);

            var CPUcounter = new PerformanceCounter("Process", "% Processor Time", selectedProcess.Name);
            var RAMcounter = new PerformanceCounter("Process", "Working Set", selectedProcess.Name);
            //PerformanceCounter dataSentCounter = new PerformanceCounter("Network Interface", "Bytes Sent/sec", selectedProcess.Name);
            //PerformanceCounter dataReceivedCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", selectedProcess.Name);

            CPUcounter.NextValue();
            RAMcounter.NextValue();
            //dataSentCounter.NextValue();
            //dataReceivedCounter.NextValue();

            Thread.Sleep(100);

            string result = "";
            result += ($"CPU usage: {Math.Round(CPUcounter.NextValue())} " +
                $"%\nMemory usage: {Math.Round(RAMcounter.NextValue() / 1024 / 1024,2)} MB" +
                //$"\nData sent: {dataSentCounter.NextValue()}" +
                //$"\nData received: {dataReceivedCounter.NextValue()}" +
                $"\nRunning time: { (TimeSpan.FromSeconds(Math.Round((DateTime.Now - proc.originalProcess.StartTime).TotalSeconds))).ToString(@"dd\:hh\:mm\:ss") } " +
                $"\nStart time: {proc.originalProcess.StartTime.ToString()} " + $"\nThreads: {proc.originalProcess.Threads.Count.ToString()}");

            return result;
        }
    }
}
