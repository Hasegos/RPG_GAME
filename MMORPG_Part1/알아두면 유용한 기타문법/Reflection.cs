using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C샵.MMORPG_모든지식.MMORPG_Part1.알아두면_유용한_기타_문법
{
    internal class Reflection
    {
        class Important : System.Attribute // 컴퓨터가 체크할수있는 주석
        {
            string message;

            public Important(string message) { this.message = message; }   
        }

        class Monster
        {
            [Important("Very Important")]
            // hp 입니다. 중요한 정보입니다.
            public int hp;
            protected int attack;
            private float speed;
            void Attack()
            {

            }
        }

        static void Main_Reflection(string[] args)
        {
            // Reflection(리플렉션) : X-Ray   모든 정보를 빼낼수있다.
            // 만약 리플렉션이 없으면 정보를 꺼내오기 매우힘들다.. 간접적으로해야함
            Monster monster = new Monster();

            Type type = monster.GetType();
            var fields = type.GetFields(System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Instance);
            foreach(FieldInfo field in fields)
            {
                string access = "protected";
                if(field.IsPublic)
                {
                    access = "public";
                }
                else if(field.IsPrivate)
                {
                    access = "private";
                }
                var attributes = field.GetCustomAttributes();
                Console.WriteLine($"{access}{field.FieldType.Name}{field.Name}");
            }


        }
    }
}
