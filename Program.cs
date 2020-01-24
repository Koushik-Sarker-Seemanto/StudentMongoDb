using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace StudentMongoDB
{
    class Program
    {
        
        static void Main(string[] args)
        {
            TeacherConsole teacherConsole = new TeacherConsole();
            StudentConsole studentConsole = new StudentConsole();
            Console.WriteLine("Hello World!");
            while (true)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("|    For Teacher            select 1|");
                Console.WriteLine("|    For Student            select 2|");
                Console.WriteLine("|    For Quit               select 0|");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("    Enter the Option:");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 0)
                {
                    break;
                }
                switch (option)
                {
                    case 1:
                        teacherConsole.TeacherTask();
                        break;
                    case 2:
                        studentConsole.StudentTask();
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            }
        }
    }
}