using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace LessonThread
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Thread thread1 = new Thread(ShowA);
            //thread1.Start();

            //Thread thread2 = new Thread(ShowB);
            //thread2.Start();

            //Task task = Task.Run(() =>
            //{
            //    for (int i = 0; i < 1000; i++)
            //    {
            //        Console.Write(" "+i);
            //    }
            //});
            //Console.WriteLine("B");
            //Console.WriteLine("C");
            //Console.WriteLine("D");

            //var task = GetGoogleSrc().ContinueWith(x => Console.WriteLine(x.Result));

            //while (!task.IsCompleted)
            //{
            //    Console.WriteLine("Davam edir...");
            //}


            await GetGoogleSrcAsync();

            Console.WriteLine("A");
            Console.WriteLine("B");
            Console.WriteLine("C");
        }

        static Task<string> GetGoogleSrc()
        {
            HttpClient client = new HttpClient();

            var task = client.GetStringAsync("https://google.com");
            return task;
        }

        static async Task GetGoogleSrcAsync()
        {
            HttpClient client = new HttpClient();

            var result = await client.GetStringAsync("https://google.com");

            Console.WriteLine(result);
        }
        static void ShowA()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(50);
                Console.Write(" A");
            }
        }

        static void ShowB()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(50);
                Console.Write(" B");
            }
        }
    }
}
