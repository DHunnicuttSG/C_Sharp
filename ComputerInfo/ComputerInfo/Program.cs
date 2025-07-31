using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerInfo
{
    public class Program
    {
        static void Main(string[] args)
        {
            DriveInfo oneDrive = new DriveInfo("C");
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (var drive in allDrives)
            {
                // [1] Print Sizes.
                Console.WriteLine(drive.AvailableFreeSpace);
                Console.WriteLine(drive.TotalFreeSpace);
                Console.WriteLine(drive.TotalSize);
                Console.WriteLine();

                // [2] Format and type.
                Console.WriteLine(drive.DriveFormat);
                Console.WriteLine(drive.DriveType);
                Console.WriteLine();

                // [3] Name and directories
                Console.WriteLine(drive.Name);
                Console.WriteLine(drive.RootDirectory);
                Console.WriteLine(drive.VolumeLabel);
                Console.WriteLine();

                Console.WriteLine(drive.IsReady);
                Console.WriteLine("-----------");
            }
        }
    }
}
