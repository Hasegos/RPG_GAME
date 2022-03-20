using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.MMORPG_모든지식
{
    class 데이터갖고놀기
    {
        static void 데이터(string[] args)
        {
            // 비트 연산
            int id = 123;
            int key = 401;

            int a = id ^ key; //  xor 은 중간에 가로채는 걸 방지하기위해 사용함.
            int b = a ^ key;
            Console.WriteLine(a);
            Console.WriteLine(b);

            uint num = 1;

                //<< >> &(and) |(or) ^(xor)_다르면 켜짐 ~(not)  이게  오른쪽으로 갈때 부호가 딸려가는 경우가 생김으로 언사이드로 하자.
            num = num << 3;
            Console.WriteLine(num);
        

            // 데이터 마무리
            int a;
            a = 100;

            int b;
            b = a;

            a = a + 1;  // a += 1;
            a = a - 1;  // a -= 1;
            a = a * 1;  // a *= 1;
            a = a / 1;  // a /= 1;
            a = a % 1;  // a %= 1;
            a = a << 1; // a >>= 1;
            a = a >> 1; // a <<= 1;
            a = a | 1; // a |= 1;
            a = a ^ 1; // a ^= 1;
            

            int a = ((2 + 3) ^ 4); // 괄호를 사용하여 우선순위를 보여주자.

            // 1. ++ --
            // 2. * / %
            // 3. + -
            // 4.  << >>
            // 5. < >
            // 6. == !=
            // 7. &
            // 8. ^
            // 9. |
            // ..
          

            var num = 3;  // int num = 3

            var num2 = "Hello World"; // string num2 = "Hello World"

              

        }
    }
}
