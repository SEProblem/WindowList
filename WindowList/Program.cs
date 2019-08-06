using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// forget which parts of this project is StackOverflow, but thanks!
namespace WindowList
{
    class Program
    {
        static bool flag;
        static void Main(string[] args)
        {
            Debugger debug = new Debugger();
            while (true) {
                flag = false;
                Console.Clear();
                debug.processPrograms();
                foreach (KeyValuePair<IntPtr, string> window in OpenWindowGetter.GetOpenWindows()) {
                    IntPtr handle = window.Key;
                    string title = window.Value;
                    if (!flag) {
                        flag = debug.checkPrograms(title);
                    }
                    Console.WriteLine("{0}: {1}", handle, title);
                }

                try {
                    if (flag)
                        Console.WriteLine("Debugger Present!");
                    Console.WriteLine("Press Enter to Quit");
                    Reader.ReadLine(500);
                    // will not execute normally
                    return;
                }
                catch (TimeoutException) {
                    // absolutely nothing
                }
            }
        }
    }
}
