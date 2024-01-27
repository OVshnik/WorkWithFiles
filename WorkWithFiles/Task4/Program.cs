using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Task4;

namespace Task4
{
    internal class Program
    {

        static void Main(string[] args)
        {

            string path1 = @"C:/Users/MSI/Desktop/Обучение/Task4/students.dat";
            string path2 = @"C:/Users/MSI/Desktop/Students";


            List<Student> students = ReadValues(path1);

            foreach (Student studentProp in students)
            {
                Console.WriteLine(studentProp.Name + " " + studentProp.Group + " " + studentProp.DateOfBirth + " " + studentProp.AverageScore);
            }

            foreach (Student studentProp in students)
            {
                using (File.Create(path2 + "/" + studentProp.Group + ".txt")) ;
            }

            WriteValues(students, path2);

        }
        static List<Student> ReadValues(string path)
        {
            List<Student> result = new();

            using var fs = new FileStream(path, FileMode.Open);

            using (StreamReader sr = new(fs))
            {

                fs.Position = 0;

                BinaryReader br = new(fs);

                while (fs.Position < fs.Length)
                {
                    Student student = new();
                    student.Name = br.ReadString();
                    student.Group = br.ReadString();
                    long dt = br.ReadInt64();
                    student.DateOfBirth = DateTime.FromBinary(dt);
                    student.AverageScore = br.ReadDecimal();
                    result.Add(student);
                }
                br.Close();
            }

            fs.Close();
            return result;
        }
        static void WriteValues(List<Student> students, string path)
        {
            foreach (Student student in students)
            {
                using StreamWriter sw = new(path + "/" + student.Group + ".txt");
                sw.Write(student.Name);
                sw.Write(student.DateOfBirth);
                sw.Write(student.AverageScore);
            }
        }
    }

}
