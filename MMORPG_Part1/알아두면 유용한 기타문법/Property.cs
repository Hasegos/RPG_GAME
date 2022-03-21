using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.MMORPG_모든지식.MMORPG_Part1.알아두면_유용한_기타_문법
{
    internal class Property
    {
        // 객체지향 -> 은닉성
        class Knight
        {
            //protected int hp = 100;

            public int HP
            {
                //get
                //{
                //    return hp; 
                //}
                //private set
                //{
                //    hp = value;
                //}
                get; set;
            }
            private int hp;

            // Getter Get 함수
            public int GetHP() { return hp; }

            // Setter Set함수
            public void SetHp(int hp) { this.hp = hp; }
        }
        static void Main_Property(string[] args)
        {
            // 프로퍼티 -> 객체지향 은닉성 제공 할수싶을때
            // 이걸 다른언어에서 너무 길어서 줄인거.
            Knight knight = new Knight();
            knight.SetHp(100);

             // knight.HP = 100;
            int hp = knight.HP;
        }
    }
}
