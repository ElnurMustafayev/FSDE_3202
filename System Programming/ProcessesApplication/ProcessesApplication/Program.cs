using System.Diagnostics;
using System.Linq;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;

namespace ProcessesApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //ParameterizedThreadStart threadStart = obj =>
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine("Hello World!");
            //};
            //Thread thread = new Thread(threadStart)
            //{
            //    IsBackground = true,
            //};

            //Console.WriteLine("Start");
            //thread.Start();


            //var processes = Process.GetProcesses();

            //foreach (var proc in processes)
            //{
            //    Console.WriteLine(proc.ProcessName);
            //}

            //var vs = Process.GetProcessesByName("devenv").FirstOrDefault();

            //foreach (var item in vs.Modules)
            //{
            //    Console.WriteLine(item);
            //}



            //var notepadProc = Process.Start("notepad.exe");

            //Console.WriteLine(notepadProc.HasExited);

            //notepadProc.WaitForExit();

            //Console.WriteLine(notepadProc.HasExited);

            // start process with arguments
            //string filename = @"C:\Users\e.mustafayev\Desktop\new.txt";
            //string applicationPath = @"C:\Program Files\Notepad++\notepad++.exe";

            //var startedProcess = Process.Start(applicationPath, filename);


            // arguments
            //foreach (var arg in args)
            //{
            //    Console.WriteLine(arg);
            //}



            // start process
            //ProcessStartInfo startInfo = new ProcessStartInfo()
            //{
            //    FileName = @"C:\Program Files\Notepad++\notepad++.exe",
            //};

            //var startedProcess = Process.Start(startInfo);


            // kill process
            //var gitbashproc = Process.GetProcessById(12028);
            //gitbashproc.Kill();

            // get all processes
            //var processes = Process.GetProcesses();

            //foreach (var proc in processes)
            //{
            //    Console.WriteLine(proc.Id + " " + proc.ProcessName);
            //}
        }
    }
}
