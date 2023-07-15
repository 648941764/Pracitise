using System;
using static System.Console;


namespace _08_Text4
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveClass driveClass = new DriveClass(10,2,3);

        }
    }
    public class BaseClass
    {
        private int _speed;
        private int _attack;
        public BaseClass()
        {
            Console.WriteLine("BaseClass");
        }
        public BaseClass(int speed,int attack)
        {
            _speed = speed;
            _attack = attack;
        }
    }
    public class DriveClass:BaseClass
    {
       private int _hp;
        public DriveClass(int hp,int speed,int attack):base(hp,attack)
        {
            _hp = hp;
            Console.WriteLine(_hp);
        }
    }
}
