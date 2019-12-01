using System;
using System.Management;
namespace HuronInstaller
{
    class Huron_main
    {
        private static void ScanForHardware()
        {
            string[] toScan ={"Win32_Processor","Win32_VideoController","Win32_NetworkAdapter","Win32_SoundDevice","Win32_Battery"
            };
            foreach(var option in toScan)
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + option);
               
            }
        }
        static void Main(string[] args)
        {
            
        }
    }
}
