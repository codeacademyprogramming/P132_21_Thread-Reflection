using System;
using System.Reflection;

namespace LessonReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product pr = new Product(40)
            {
                Name = "Cola",
                Price = 2.5
            };


            var assembly = Assembly.GetExecutingAssembly();

            foreach (var type in assembly.GetTypes())
            {
                bool isProduct = type == typeof(Product);
                Console.WriteLine(type.Name);
                Console.WriteLine(" - Fields:");
                foreach (var item in type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    if(item.Name == "Limit")
                    {
                        item.SetValue(pr, 55);
                    }
                        Console.WriteLine(" - - " + item.Name + (isProduct?  " - " +  item.GetValue(pr):""));
                }

                Console.WriteLine(" - Properties:");
                foreach (var item in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    Console.WriteLine(" - - " + item.Name);
                }

                Console.WriteLine(" - Methods:");
                foreach (var item in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    Console.WriteLine(" - - " + item.Name);
                }
            }

            var prType = typeof(Product);

        }
    }
}
