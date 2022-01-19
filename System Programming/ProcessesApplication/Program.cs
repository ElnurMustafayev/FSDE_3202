using System.Diagnostics;
using System.Linq;
using System;
using System.Threading;

namespace ProcessesApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // thread syntax
            if(false) {
                // create thread code block
                ParameterizedThreadStart threadStart = obj =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("Hello World!");
                };

                // create thread
                Thread thread = new Thread(threadStart)
                {
                    IsBackground = false,   // by default (parent thread waits will then end)
                };

                Console.WriteLine("Start"); // 1

                // exec thread
                thread.Start();             // 3

                Console.WriteLine("End");   // 2
            }

            // get process modules (libraries)
            if (false) {
                var vs = Process.GetProcessesByName("devenv").FirstOrDefault();

                foreach (var item in vs.Modules)
                {
                    Console.WriteLine(item);
                }
            }

            // add synch waiting child process end
            if (false) {
                // start child process
                var childProc = Process.Start("notepad.exe");

                // add action in onexit event
                childProc.Exited += (s, e) => Console.WriteLine("HEY!");

                // wait child process end
                childProc.WaitForExit();

                // write info after
                if (childProc.HasExited)
                    Console.WriteLine($"Process exited with code {childProc.ExitCode}");
            }

            // start process with arguments
            if (false) {
                string filename = @"Assets/test.txt";           // relative
                string applicationName = @"notepad.exe";

                // open text file with notepad
                var startedProcess = Process.Start(applicationName, filename);

                // open browser with site
                //string browserPath = @"path/browser.exe";     // absolute
                //Process.Start(browserPath, "https://facebook.com");
            }

            // start process
            if (false) {
                ProcessStartInfo startInfo = new ProcessStartInfo()
                {
                    FileName = @"notepad.exe",
                };

                // use static method
                var startedProcess = Process.Start(startInfo);

                // create object
                var proc = new Process()
                {
                    StartInfo = startInfo,
                }.Start();
            }

            // kill process
            if (false) {
                Process calcProcess = Process.Start("notepad.exe");
                Thread.Sleep(5000);
                calcProcess.Kill();
                Console.WriteLine($"Process has been killed with code {calcProcess.ExitCode}");
            }

            // get all processes
            if (false) {
                var processes = Process.GetProcesses();

                foreach (var proc in processes)
                {
                    Console.Write($"{proc.Id}\t{proc.ProcessName}");
                    try
                    {
                        Console.WriteLine($"- {proc.PriorityClass}");
                    }
                    catch
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}