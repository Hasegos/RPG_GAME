using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG_git정리용.MMORPG_Part1.알아두면_유용한_기타_문법
{
    internal class Nullable
    {

        static int Find()
        {
            return 0;
        }
        class Monster
        {
            public int id { get; set; }

        }
        static Monster FindMonster(int id)
        {
            // for()
            // return monster
            return null;
        }
        static void Main_Nullable(string[] args)
        {
            
            // Nullable => Null + able
            int? number = null; // ? 널도 될수있다

            int c = (number != null) ? number.Value : 0;
            int b =number ?? 0; // 널일때 초기값 0을 넣어준다 아니라면 Value가져오고
            Console.WriteLine(b);

            if(number != null)
            {
                int a = number.Value; // Value를 사용해서 꺼내올수있다
                Console.WriteLine(a);
            }
            if(number.HasValue)
            {
                int a = number.Value; // Value를 사용해서 꺼내올수있다
                Console.WriteLine(a);
            }
            Monster monster = null;

            if(monster !=null)
            {
                int monsterid = monster.id;
            }
            int? id = monster?.id; // 널이 아닐 때 값 뽑아오고 널일땐 널 넣기

            if(monster == null)
            {
                id = null;
            }
            else
            {
                id = monster.id;    
            }
        }
    }
}
