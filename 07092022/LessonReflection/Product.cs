using System;
using System.Collections.Generic;
using System.Text;

namespace LessonReflection
{
    internal class Product
    {
        public Product(int limit)
        {
            Limit = limit;
        }

        public string Name;
        private int Limit;
        public double Price { get; set; }
    }

}
