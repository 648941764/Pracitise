using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01构造函数
{
    class Program
    {
        static void Main(string[] args)
        {
            Student wyq = new Student("伍岩强", "成都", 20, "21305030126");
            wyq.show();
            
            Console.ReadKey();
        }
    }
}
