using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryInformation
{
    public class Program
    {
        static void Main(string[] args)
        {
            GetDirectoryInfo();
            //CreateDirectories();
            //DeleteDirectories();
            GetFilesInDirectories();
        }

        static void GetDirectoryInfo()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("****** Directory Info ******");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
            Console.WriteLine("***************************\n");
        }

        static void CreateDirectories()
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            dir.CreateSubdirectory("MyFolder");
            DirectoryInfo MyDataFolder = dir.CreateSubdirectory(@"MyFolder2\Data");
            Console.WriteLine("New Folder is: {0}", MyDataFolder);
        }

        static void DeleteDirectories()
        {
            DirectoryInfo dir = new DirectoryInfo(@".\Myfolder");
            dir.Delete();

            dir = new DirectoryInfo(@".\MyFolder2");
            dir.Delete(true);
        }

        static void GetFilesInDirectories()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");

            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            Console.WriteLine("Found {0} *.jpg files \n", imageFiles.Length);

            foreach (FileInfo f in imageFiles)
            {
                Console.WriteLine("**********************");
                Console.WriteLine("File Name: {0}", f.Name);
                Console.WriteLine("File Size: {0}", f.Length);
                Console.WriteLine("creation: {0}", f.CreationTime);
                Console.WriteLine("Attributes: {0}", f.Attributes);
                Console.WriteLine("**********************");
            }
        }
    }
}
