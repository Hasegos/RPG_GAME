using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C��.MMORPG_�������.MMORPG_Part1.�˾Ƶθ�_������_��Ÿ_����
{
    internal class Reflection
    {
        class Important : System.Attribute // ��ǻ�Ͱ� üũ�Ҽ��ִ� �ּ�
        {
            string message;

            public Important(string message) { this.message = message; }   
        }

        class Monster
        {
            [Important("Very Important")]
            // hp �Դϴ�. �߿��� �����Դϴ�.
            public int hp;
            protected int attack;
            private float speed;
            void Attack()
            {

            }
        }

        static void Main_Reflection(string[] args)
        {
            // Reflection(���÷���) : X-Ray   ��� ������ �������ִ�.
            // ���� ���÷����� ������ ������ �������� �ſ������.. �����������ؾ���
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
