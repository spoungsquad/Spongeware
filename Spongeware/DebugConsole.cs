using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Spongeware
{
    class DebugConsole
    {
        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);

        private const int ATTACH_PARENT_PROCESS = -1;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        static bool init = false;

        static StreamWriter writer;

        private static void Allocate()
        {
            AllocConsole();

            var stdout = Console.OpenStandardOutput();

            writer = new StreamWriter(stdout)
            {
                AutoFlush = true
            };

            AttachConsole(ATTACH_PARENT_PROCESS);
            init = true;
        }

        public static bool IsDevEnvironment()
        {
            Process[] DevEnvIndex = Process.GetProcessesByName("devenv");
            if (DevEnvIndex.Length != 0)
            {
                return true;
            }
            return false;
        }

        public static void Write(string text)
        {
            if (!init && IsDevEnvironment())
            {
                Allocate();
            } // only allocates a console if visual studio is found

            if (init)
            {
                writer.WriteLine(text);
                Console.WriteLine(text);
            }
        }
    }
}