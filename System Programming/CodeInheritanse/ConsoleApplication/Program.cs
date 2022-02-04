using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace ConsoleApplication
{


    public class Program
    {
        // .dll
        [DllImport(@"CppLibrary.dll")]
        public static extern void SayHi(string name);

        [DllImport(@"CppLibrary.dll")]
        static extern int GetSum(int x, int y);

        // Win API
        [DllImport(@"User32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [DllImport(@"User32.dll")]
        static extern int SetWindowText(int hWnd, string lpString);

        static void Main(string[] args)
        {
            // .dll
            if(false)
            {
                var result = GetSum(12, 13);
                Console.WriteLine(result);
                SayHi("Test");
            }
            
            // Win API
            if(false)
            {
                while(true)
                {
                    Thread.Sleep(3000);
                    SetCursorPos(new Random().Next(1920), new Random().Next(1080));
                }
            }

            if(false)
            {
                var notZeroHandlerProcesses = Process.GetProcesses().Where(p => p.MainWindowHandle != IntPtr.Zero);

                foreach (var process in notZeroHandlerProcesses)
                {
                    int windowId = process.MainWindowHandle.ToInt32();
                    SetWindowText(windowId, Guid.NewGuid().ToString());
                }
            }
        }
    }
}