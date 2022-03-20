using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.TextRPG_2
{
    enum MonsterType
    {
        None = 0,
        StoneKiwi =1, // 스톤키위
        SenyabotAlpha = 2, // 세냐보그 알파버전
        SandbladeMarauder = 3 // 모래칼날 약탈꾼
    }
    class Monster : Creature
    {
        MonsterType type;        
        public Monster(MonsterType type) : base(CreatureType.Monster)  // 몬스터 타입 저장.
        {
            this.type = type;
        }
        public MonsterType GETMONSTER()  
        {
            return type;
        }

    }
    class StoneKiwi : Monster // 스톤키위
    {
        public StoneKiwi() : base(MonsterType.StoneKiwi)
        {
            setability(100, 10);
        }
    }

    class SenyabotAlpha : Monster // 세냐보그 알파버전
    {
        public  SenyabotAlpha() : base(MonsterType.StoneKiwi)
        {
            setability(200, 8);
        }
    }

    class SandbladeMarauder : Monster // 모래칼날 약탈꾼
    {
        public  SandbladeMarauder() : base(MonsterType.StoneKiwi)
        {
            setability(50, 20);
        }
    }
}
