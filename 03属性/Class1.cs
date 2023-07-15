using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03属性
{
    class Customer
    {
        protected string sex;
        protected string name;
        protected int age;
        protected string ID;
        public Customer(string sex, string name, int age, string ID)
        {
            Console.WriteLine("顾客已经创建");
            this.sex = sex;
            this.name = name;
            this.age = age;
            this.ID = ID;
        } 
        public void CustomerShow()
        {
            Console.WriteLine("名字：{0}年龄：{1}号码：{2}",name,age,ID);
        }
    }
    class Cusomer1 : Customer
    {
        private int height;
      public  Cusomer1(string sex, string name, int age, string ID,int height):base(sex,name,age,ID)
        {
          this.height = height;
        }
    }
}
