using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG_git������.MMORPG_Part1.�˾Ƶθ�_������_��Ÿ_����
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
            int? number = null; // ? �ε� �ɼ��ִ�

            int c = (number != null) ? number.Value : 0;
            int b =number ?? 0; // ���϶� �ʱⰪ 0�� �־��ش� �ƴ϶�� Value��������
            Console.WriteLine(b);

            if(number != null)
            {
                int a = number.Value; // Value�� ����ؼ� �����ü��ִ�
                Console.WriteLine(a);
            }
            if(number.HasValue)
            {
                int a = number.Value; // Value�� ����ؼ� �����ü��ִ�
                Console.WriteLine(a);
            }
            Monster monster = null;

            if(monster !=null)
            {
                int monsterid = monster.id;
            }
            int? id = monster?.id; // ���� �ƴ� �� �� �̾ƿ��� ���϶� �� �ֱ�

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
