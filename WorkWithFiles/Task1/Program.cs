using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input path for folder, that you want to delete: ");
            string path = Console.ReadLine();
            Delete(path);
        }
        static void Delete(string dirPath)
        {

            if (Directory.Exists(dirPath) && Directory.GetLastWriteTimeUtc(dirPath).AddMinutes(30) <= DateTime.Now)
            {
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
                    foreach (var dir in dirInfo.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    foreach (var file in dirInfo.GetFiles())
                    {

                        file.Delete();
                    }

                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }
    }
}