using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.MMORPG_모든지식.MMORPG_Part1.알아두면_유용한_기타_문법
{
    internal class Interface
    {
        abstract class Monster
        {
            public abstract void Shout();
        }
        interface iFlyable
        {
             void Fly();
        }
        class FlyableOrc : Orc ,iFlyable // 다중 상속은 비추
        {
            public void Fly()
            {

            }
        }
        class Orc :Monster
        {
            public override void Shout()
            {
                Console.WriteLine("록타르 오가르!");
            }
        }
        class Skeleton :Monster // 상속받은 애들은 무조건 오버라이딩을해야한다.
        {
            public override void Shout()
            {
                Console.WriteLine("꾸에에엑!");
            }
        }
        static void DoFly(iFlyable flyable)
        {
            flyable.Fly();
        }
        static void Main_Interface(string[] args)
        {
            // 추상 클래스는 객체 생성 x
            iFlyable flyable = new FlyableOrc();
            DoFly(flyable);

            //List<int>
        }
    }
}
