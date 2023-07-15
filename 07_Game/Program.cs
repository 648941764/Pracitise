using System;
using static System.Console;

namespace _07_Game
{
    class Program
    {

        static void Main(string[] args)
        {
            //返回对话类型,在写完这个逻辑后才学会了，所以里面有很多的WriteLine,懒得改了，但是会用了;
            string introduce = " ";
           Game game = new Game();
            Player A = new Player(3, "玩家", 100, 3, -2,10);
            Npc B = new Npc(1, "史莱姆", 100, 3, 4,20);
            Cat C = new Cat(0, "猫咪", 10, 1, 7);
            Dog D = new Dog(2, "旺财", 20, 1, 10);
            Shop shop = new Shop("百货商店", 13, "大剑", "药水瓶");
            game.Introduce(introduce);//此函数法做测试用,有更好的写法（懒得改了）
            int CurrentVector2 = A.vector2;
            while (true)
            {
                string S = ReadLine();
                if (S == "D")
                {
                  Console.WriteLine("主角正在移动......");
                  A.vector2 += A.speed;
                  if (A.vector2 == B.vector2)
                    {
                        //WriteLine(A.name+"和"+B.name+"相遇了");
                        WriteLine("{0}和{1}相遇了", A.name, B.name);
                        Console.WriteLine("战斗开始。按下F键释放大招");
                        while (true)
                        {
                            string F = ReadLine();
                            if (F == "F")
                            {
                                A.PlayerSkill();
                                B.GetSkillHurt(A);
                                if (B.hp <= 0)
                                {
                                    Console.WriteLine("{0}已经被消灭，战斗成功", B.name);
                                    A.Defeat(B);
                                    A.gold += B.gold;
                                    Console.WriteLine("当前金币为：{0}",A.gold);
                                    break;
                                }
                            }

                        }

                    }
                    else if (A.vector2 == C.vector2)
                    {
                        while (true)
                        {
                            Console.WriteLine("{0}正在尝试和{1}对话，按下K键开始对话", A.name, C.name);
                            string K = ReadLine();

                            if (K == "K")
                            {
                                A.Dialogue(C);
                                C.Dialogue(A);
                                break;
                            }
                        }
                    }
                    else if (A.vector2 == D.vector2)
                    {
                        Console.WriteLine("{0}和{1}相遇了", A.name, D.name);
                        D.Dialogue(D);
                        Console.WriteLine("是否收养{0}做宠物", D.name);
                        Console.WriteLine("按下O键和{0}绑定宠物系统", D.name);
                        string O = Convert.ToString(ReadLine());
                        if (O == "O")
                        {
                            Console.WriteLine("{0}已经和{1}绑定宠物系统", A.name, D.name);

                        }
                    }
                    else if (A.vector2 == shop.vector2)
                    {
                        while (true)
                        {
                            Console.WriteLine("欢迎来到{0}", shop.name);
                            Console.WriteLine("{0}:请问需要购买一些什么..注意只能选一个哦", shop.name);
                            Console.WriteLine("按下L购买{0}花费20金币，按下S购买{1}花费50金币", shop._liquidMedicineBottle, shop._sword);
                            string buyWhat = ReadLine();
                            if (buyWhat == "L" && A.gold >= 20)
                            {
                                A.hp += 20;
                                Console.WriteLine("购买成功，{0}最大生命值已经提升，当前血量为{1}", A.name, A.hp);
                                A.gold -= 20;
                                Console.WriteLine("当前金币{0}",A.gold);
                                break;
                            }
                            else if (buyWhat == "S" && A.gold >= 50)
                            {
                                A.attack += 5;
                                Console.WriteLine("购买成功，{0}最大攻击力已经提升，当前攻击为{1}", A.name, A.attack);
                                A.gold -= 20;
                                Console.WriteLine("当前金币{0}", A.gold);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("金币不足是否购买金币？输入：“作者好帅”即可购买,按下F取消购买并且离开商店");
                                string BuyGold = ReadLine();
                                if (BuyGold=="作者好帅")
                                {
                                    A.gold = 999;
                                    Console.WriteLine("当前金币{0}", A.gold);
                                }
                                else if(BuyGold == "F")
                                {
                                    Console.WriteLine(".....你会后悔的");
                                    Console.WriteLine("离开商店");
                                    break;
                                }
                            }
                        }
                    }
                  

                }
                else if (S == "Z")
                {
                    break;
                }
                else if (S=="M")
                {
                    A.Transfer(A);
                    A.vector2 = CurrentVector2;
                    Console.WriteLine("当前位置{0}",A.vector2);
                }
              
            }
            ReadKey();
          
        }
    }
    public interface GameBehavior
    {
        void Attack(Game game);
      
        void GetHurt(Game game);
        void GetSkillHurt(Game game);
        void PrintHealth();
        void Dialogue(Game game);
        void Defeat(Game game);
        string Introduce(string a);
        //int[] GetVector2(int a,int b);
    }
   
  
   public class Game :GameBehavior
    {
        private int _attack;
        private int _skillAttack;
        private string _name;
        private int _hp;
        private int _speed;
        private int _vector2;
        private string _talk;
        private int _gold;
        
        public int gold { get { return _gold; }set { _gold = value; } }
        public int attack { get { return _attack; } set { _attack = value; } }
        public string  name { get { return _name; }set { _name = value; } }
        public int hp { get { return _hp; }set { _hp = value; } }
        public int speed { get { return _speed; }set { _speed = value; } }
        public int vector2 { get { return _vector2; }set { _vector2 = value; } }
        public int skillAttack { get { return _skillAttack; }set { _skillAttack = value; } }
        public string talk { get {return _talk; } set { _talk = value; } }

        public void Attack(Game game)
        {
            Console.WriteLine("{0}攻击了{1}",name,game.name); 
        }

        public void Defeat(Game loser)
        {
            
            Console.WriteLine("{0}击败了{1}获得了{2}金币",name,loser.name,loser.gold);
        }

        public virtual void Dialogue(Game game)
        {
            Console.WriteLine("{0}尝试和{1}对话", name, game.name);
            
        }

        public void GetHurt(Game game)
        {
            int harm = game.attack;
            Console.WriteLine("{0}受到了{1}的{2}点伤害",name,game.name,harm);
            
        }
        public void GetSkillHurt(Game game)
        {
            int harm = game.skillAttack;
            Console.WriteLine("{0}受到了{1}的{2}点技能伤害", name, game.name, harm);
            hp -= harm;
            hp = Math.Max(hp, 0);
            Console.WriteLine(name+"剩余血量"+hp);
        }

        public string Introduce(string a)
        {
           a = "按下Z键结束游戏\n按下D键开始游戏\n开始游戏后按下M传送回起点";
            WriteLine(a);
            return a;
        }

        public void PrintHealth()
        {
           
        }



        //public int[] GetVector2(int a,int b)
        //{
        //    int[] Vector2;
        //    Vector2 = new int[2] { a, b };
        //    return Vector2;
        //}
    }
   public  class Player : Game 
    {
       
        public Player(int attack,string name,int hp,int speed,int Vector2,int gold)
        {
            this.gold = gold;
            this.attack = attack;
            this.name = name;
            this.hp = hp;
            this.speed = speed;
            this.vector2 = Vector2;
        }
        public void Transfer(Game destination)//提醒自己不要忘记这个写法！！！
        {
            Console.WriteLine("已经重置位置");
            this.vector2 = destination.vector2;
        }
        public override void Dialogue(Game game)
        {
            Console.WriteLine(name+":你好啊小{0}",game.name);
          
        }

        public void PlayerSkill()
        {
            skillAttack = attack*4;
            Console.WriteLine("主角正在释放大招,伤害是{0}",skillAttack);
            
        }
    }
   public class Npc:Game
    {
        public Npc(int attack, string name, int hp, int speed,int Vector2,int value)
        {
            this.gold = value;
            this.attack = attack;
            this.name = name;
            this.hp = hp;
            this.speed = speed;
            this.vector2 = Vector2;
        }
       
    }
    public class Cat:Game
    {
        public Cat(int attack, string name, int hp, int speed,int Vector2)
        {
            this.attack = attack;
            this.name = name;
            this.hp = hp;
            this.speed = speed;
            this.vector2 = Vector2;
        }
        public override void Dialogue(Game game)
        {
            
            Console.WriteLine(name+":......");
            Console.WriteLine("看起来{0}特别嫌弃{1}",name,game.name);
            Console.WriteLine("{0}走远了",name);
        }
    }
    public class Dog : Game
    {
        public Dog(int attack, string name, int hp, int speed, int Vector2)
        {
            this.attack = attack;
            this.name = name;
            this.hp = hp;
            this.speed = speed;
            this.vector2 = Vector2;
        }
        public override void Dialogue(Game game)
        {
            Console.WriteLine("{0}看起来对你挺感兴趣的",name);
        }
    }
    public class Shop : Game 
    {
       public string _sword;
       public string _liquidMedicineBottle;

        public Shop(string name,int Vector2,string sword,string liquidMedicineBottle)
        {
            this.vector2 = Vector2;
            this.name = name;
            this._sword = sword;
            this._liquidMedicineBottle = liquidMedicineBottle;
        }
        public string ReturnString()
        {
            
            string a;
            a = "MyClass";
            return a;
        }

    }



}
