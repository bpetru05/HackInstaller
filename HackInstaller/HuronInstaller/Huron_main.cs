using System;
using System.Management;
using iPatch;
namespace HuronInstaller
{
    class Huron_main
    {
        private static void ScanForHardware()
        {
            //TODO Finish Hardware scanner
            //TODO Add DSDT/SSDT patching
            string[] toScan ={"Win32_Processor","Win32_VideoController","Win32_NetworkAdapter","Win32_SoundDevice","Win32_Battery"
            };//stuff to scan for
            foreach(var option in toScan)
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + option);//get devices
            }
        }
        static void Main(string[] args)
        {
            

        }
    }
}
