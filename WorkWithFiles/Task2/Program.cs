using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace Task1


{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input path for folder, that you want to delete: ");
            string path = Console.ReadLine();
            long size = 0;
            var allFiles = 0;
            GetDirectoryFileCount(path, ref allFiles);
            CountFolderSize(path, ref size);

        }
        public static long CountFolderSize(string dirPath, ref long size)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            FileInfo[] fls = dirInfo.GetFiles();
            var folders = dirInfo.GetDirectories();
            try
            {

                foreach (var file in fls)
                {
                    size += file.Length;
                }
                foreach (var folder in folders)
                {
                    size += DirectoryExtension.DirSize(folder);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            return size;

        }
        public static int GetDirectoryFileCount(string dir, ref int fileCount)
        {

            dir = dir + @"/";


            var allFiles = Directory.GetFileSystemEntries(dir);

            foreach (string file in allFiles)
            {

                if (Directory.Exists(file))
                {

                    GetDirectoryFileCount(file, ref fileCount);
                }
                else
                {

                    fileCount++;
                }

            }
            return fileCount;
        }
    }

}
