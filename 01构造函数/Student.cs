using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01构造函数
{
    class Student
    {
       public  string name;
       public  string address;
       public  int age;
       public  string idCard;
        public Student(string arg1, string arg2,int arg3,string arg4)
        {
            Console.WriteLine("学生已经录入");
            name = arg1;
            address = arg2;
            age = arg3;
            idCard = arg4;
        }
         public void show()
        {
            Console.WriteLine(name + " " + address + " " + " " + age + " " + idCard);
        }
     
    }
    
    
}
