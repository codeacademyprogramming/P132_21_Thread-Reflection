using System;
using System.Collections.Generic;
using System.Threading;

namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

            List<Exam> exams = new List<Exam>();

            string check = "y";


            do
            {
                Console.WriteLine("Telebe:");
                string name = Console.ReadLine();

                Console.WriteLine("Fenn:");
                string subject = Console.ReadLine();

                enterPoint:
                Console.WriteLine("Bal:");
                string pointStr = Console.ReadLine();
                byte point;

                if (!byte.TryParse(pointStr, out point))
                    goto enterPoint;


                enterStartDate:
                Console.WriteLine("Baslama tarixi:");
                string startDateStr = Console.ReadLine();
                DateTime startDate;

                if (!DateTime.TryParse(startDateStr, out startDate))
                    goto enterStartDate;



                enterEndDate:
                Console.WriteLine("Bitme tarixi:");
                string endDateStr = Console.ReadLine();
                DateTime endDate;

                if (!DateTime.TryParse(endDateStr, out endDate))
                    goto enterEndDate;

                if (endDate <= startDate)
                {
                    Console.WriteLine("Tarixler yanlis daxil edilib!");
                    goto enterStartDate;
                }


                Exam exam = new Exam()
                {
                    Student = name,
                    Subject = subject,
                    Point = point,
                    StartDate = startDate,
                    EndDate = endDate
                };

                exams.Add(exam);


                enterCheck:
                Console.WriteLine("Yeni imtahan elave etmek isteyirsinizmi? (y/n)");
                check = Console.ReadLine();

                if (check != "y" && check != "n")
                    goto enterCheck;

            } while (check=="y");



            Console.WriteLine("Pointi 50-den yuksek olanlar:");

            foreach (var item in exams.FindAll(ex=>ex.Point>50))
            {
                Console.WriteLine($"{item.Student} - {item.Subject} - {item.Point} - {(item.EndDate-item.StartDate).TotalMinutes}");
            }

            Console.WriteLine("Son 1 heftede olanlar:");

            foreach (var item in exams.FindAll(ex => ex.EndDate.AddDays(7).Date>=DateTime.Now.Date))
            {
                Console.WriteLine($"{item.Student} - {item.Subject} - {item.Point} - {(item.EndDate - item.StartDate).TotalMinutes}");
            }

            Console.WriteLine("1 saatdan uzun ceken imtahanlar:");
            foreach (var item in exams.FindAll(ex =>(ex.EndDate-ex.StartDate).TotalMinutes>60))
            {
                Console.WriteLine($"{item.Student} - {item.Subject} - {item.Point} - {(item.EndDate - item.StartDate).TotalMinutes}");
            }


        }

      
    }
}
