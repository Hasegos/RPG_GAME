using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.TextRPG_2
{
    enum CreatureType
    {
        None,
        Player = 1,
        Monster = 2
    }
    
    class Creature
    {
        CreatureType type;
        public int hp;
        public int attack;

        public Creature(CreatureType type)  // 생물 타입
        {
            this.type = type;
        }       
        public void setability(int hp, int attack) // 능력적용
        {
            this.hp = hp;
            this.attack = attack;
        }
        public  int  GetHP(){ return hp; }   // 체력
        public int GetATTACK() { return attack;  } // 공격
        public bool IsDead() { return hp <= 0; } // hp 떨어진게 참이냐.
        public void DAMAGE(int damage) // 데미지 받기
        {
            hp -= damage;
            if(hp < 0)
            {
                hp = 0;
            }
        }
    }
}
