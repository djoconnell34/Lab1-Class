using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Support;

namespace Lab1_Class
{
    internal class Program
    {
        
        public static HashMap<string, double> studentNames = new HashMap<string, double>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Math Class");
            int breakOut = 0;
            while (breakOut == 0)
            {
                Console.WriteLine("What Action do you Want to Take");
                Console.WriteLine("A:  See all Grades\nB:  Add a Student\nC:  Add a Grade\nD:  Show Class Average\nE:  Show the Top Grade" +
                "\nF:  Show Bottom Grade\nG:  Remove a Student\nH:  Edit a Grade\nQ:  Quit App");
                char action = char.Parse(Console.ReadLine());

                switch (action)
                {
                    case 'A':
                        Console.Clear();
                        try
                        {
                            foreach (var student in studentNames)
                            {
                                Console.WriteLine($"{student.Key} has a grade of {student.Value}\n");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Add students... Enter B");
                        }
                        
                        break;
                        
                    case 'B':
                        Console.Clear();
                        Console.Write("What is the Student's Name: ");
                        string tempName = Console.ReadLine();
                        studentNames.Add(tempName, 0);
                        Console.WriteLine($"{tempName} is added\n");
                        break;
                    case 'C':
                        Console.Clear();
                        Console.Write("Which Student do you want to add a grade to: "); //ensure only added students can get grade
                        string tempName2 = Console.ReadLine();
                        Console.Write("What grade did he/she get: ");
                        double tempGrade3 = double.Parse(Console.ReadLine());
                        studentNames.Add(tempName2, tempGrade3);
                        Console.WriteLine($"A new grade of {tempGrade3} was added to {tempName2}\n");
                        break;
                    case 'D':
                        Console.Clear();
                        double avg = 0;
                        int count = 1;
                        Console.WriteLine($"The Class average is: {Math.Round(studentNames.Values.Average(), 2)}\n");
                        break;
                    case 'E':
                        Console.Clear();
                        double tempName4 = studentNames.Values.Max();
                        foreach (var student in studentNames) //check for same highest grade
                        {
                            if (tempName4 == student.Value)
                            {
                                Console.WriteLine($"{student.Key} has the highest grade of {student.Value}\n");
                            }
                        }
                        break;
                    case 'F':
                        Console.Clear();
                        double tempName5 = studentNames.Values.Min();
                        foreach (var student in studentNames) //check for same lowest grade
                        {
                            if (tempName5 == student.Value)
                            {
                                Console.WriteLine($"{student.Key} has the lowest grade of {student.Value}\n");
                            }
                        }
                        break;
                    case 'G':
                        Console.Clear();
                        Console.Write("Which Student do you want to Remove: ");
                        string tempName6 = Console.ReadLine();
                        studentNames.Remove(tempName6);
                        Console.WriteLine($"{tempName6} has been remove\n");
                        break;
                    case 'H':
                        Console.Clear();
                        Console.Write("Which Student's Grade do you want to change: ");
                        string tempName7 = Console.ReadLine();
                        Console.Write("What is his/her new Grade: ");
                        double tempName8 = double.Parse(Console.ReadLine());
                        
                        for (int i = 0; i < studentNames.Count; i++)
                        {
                            if(studentNames.Keys.Contains(tempName7))
                            {
                                studentNames.Remove(tempName7);
                                studentNames.Add(tempName7, tempName8);
                            }
                        }
                        Console.WriteLine($"{tempName7} grade has been changed to {tempName8}\n");
                        break;
                    case 'Q':
                        Console.Clear();
                        Console.WriteLine("Goodbye");
                        breakOut = 1;
                        break;
                }
            }
            
        }
    }
}
