using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.MMORPG_모든지식
{
    
    class 자료구조맛보기_Dictionary
    {
        class Monster
        {
            public int id;
            public Monster(int id)
            {
                this.id = id;
            }
            
        }
        static void Main_Diction(string[] args)
        {
            // ID 식별자
            // 10 103 ID 몬스터

            // Hashtable 기법
            // 아주 큰 박스 [       ...               ] 1만개(1~1만)
            // 박스 여러개를 쏘개 놓는다.[1 ~ 10][11 ~ 20][][][][][][][]  1천개
            // 7777번 공?
            // 메모리 손해
            // [ 메모리를 내주고 , 성능을 취한다 !]
            // key -> value
            // Dictionary

            Dictionary<int, Monster> dic = new Dictionary<int, Monster>();
            for (int i = 0; i < 10000; i++)
            {
                dic.Add(i, new Monster(i));
            }

            Monster mon ;
            bool found = dic.TryGetValue(7777, out mon);

            dic.Remove(7777);
            dic.Clear();
        }
    }
}
