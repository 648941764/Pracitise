using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal Dog = new Animal();
            Dog.Setdata("狗", 5, 50, 10);
            Animal Cat = new Animal();
            Cat.Setdata("猫", 3, 20, 8);
            Dog.Attack(Cat);
            Cat.ReceiveDamage(Dog);
            Cat.DetaileddeScription(Dog);
            Console.ReadKey();
        }
    }
    public interface AnimalBehavior 
    {
        void Attack(Animal animal);
        void ReceiveDamage(Animal animal);
        void DetaileddeScription(Animal animal);
    }
    public class Animal:AnimalBehavior
    {
        private string _species;
        private int _age, _height, _weight;

        //public string species { get { return _species; } set { } }
        //public int age { get { return _age; } set { } }
        //public int height { get { return _height; } set { } }
        //public int weight { get { return _weight; } set { } }

        public void Setdata(string species,int age,int height,int weight)
        {
            _species = species;
            _age = age;
            _height = height;
            _weight = weight;
        }

        public void Attack(Animal animal)
        {
            Console.WriteLine("{0}攻击了{1}",_species,animal._species);
        }

        public void ReceiveDamage(Animal animal)
        {
            Console.WriteLine("{0}受到了{1}的攻击", _species, animal._species);
        }

        public void DetaileddeScription(Animal animal)
        {
            Console.WriteLine("{0}收到了{1}的{2}Kg的攻击",_species,animal._species,_weight);
        }
    }


}
