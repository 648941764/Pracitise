using System;

namespace _05_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            School A = new School("C大学");
            A.PeopleCount(50, 45);
            A.headcount(10);
            Console.ReadKey();
        }
    }
    public interface SchoolBehavior
    {
        void PeopleCount(int a,int b);
        void headcount(int a);

    }

    class School:SchoolBehavior
    {
        private int _studentCount;
        private int _teacherCount;
        private string _scholName;
        private int _totality;
        public int studentCount => _studentCount;
        public int teacherCount => _teacherCount;
        public School(string schoolName)
        {
            _scholName = schoolName;
            Console.WriteLine("学校已经创建，学校的名字是" + schoolName);
        }
        public void headcount(int a)
        {
            a = studentCount + teacherCount;
            Console.WriteLine("学校的总人数是:"+a);
        }

        public void PeopleCount(int teacher,int student)
        {
            _teacherCount = teacher;
            _studentCount = student;
            Console.WriteLine("学校有老师{0}人,学生{1}人",_teacherCount,_studentCount);
        }
    }


}
