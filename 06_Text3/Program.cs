using System;
using static System.Console;

namespace _06_Text3
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle A = new Rectangle();
            A.SetWidth(5);
            A.SetWeight(6);

            Console.WriteLine("面积是{0}：", A.Area());
            ReadKey();
        }
        public interface GetCost
        {
            int cost();
        }
        class Shape
        {
            protected int _Width;
            protected int _weight;
            public void SetWidth(int width)
            {
                _Width = width;
            }
            public void SetWeight(int weight)
            {
                _weight = weight;
            }
        }
        class Rectangle : Shape, GetCost
        {

            public int Area()
            {
                return (_Width * _weight);
            }

            public int cost()
            {
                return Area() * 30;
            }
        }

    }
}
