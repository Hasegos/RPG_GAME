using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.MMORPG_모든지식
{
    class 코드의_흐름_제어
    {
        // Method Function  함수
        // 한정자 반환형식 이름(매개변수목록)
        //{

        //}   
        // 메소드 함수
        static void HelloWorld()
        {
            Console.WriteLine("Hello World");
        }
        // 덧셈 함수
        static int ADD(int a, int b)
        {
            int result = a + b;
            return result;
        }
        static void ADDONE_1(int number) // 참조로 넘긴다. 즉 주소 자체를 건든다.
        {
            number += 1;
        }
        static void ADDONE_2(ref int number)
        {
            number += 1;
        }
        static int ADDONE_3(int number)
        {
            return number += 1;
        }
        static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void Divide(int a, int b, out int result1, out int result2)
        {
            result1 = a / b;
            result2 = a % b;
        }
        enum Choice
        {
            Rock = 1,  // 아무것도아니면 0 부터 1 씩 증가
            Paper = 2,
            Scissors = 0
        }

        // 함수 이름의 재사용
        static int Add(int a, int b)
        {
            Console.WriteLine("Add int 호출");
            return a + b;
        }
        static int Add(int a, int b, int c = 0) // c 는 기본값 0 사용 받으면 받은 값 적용
        {
            Console.WriteLine("Add int 호출");
            return a + b + c;
        }
        static float Add(float a, float b)
        {
            Console.WriteLine("Add float 호출");
            return a + b;
        }
        static int Factorial(int n)
        {
            int sum = 1;
            for (int i = n; i >= 1; i--)
            {
                sum *= i;
            }
            return sum;
        }
        static int Factorial_1(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            return n * Factorial_1(n - 1);

        }

        static void 흐름제어(string[] args)
        {
            {
                // if else
                int hp = 10;
                bool isDead = (hp <= 0);

                if (isDead)
                {
                    Console.WriteLine("You are dead!");
                }
                else
                {
                    Console.WriteLine("You are alive");
                }

                int choice = 1; // 0 : 가위  1: 바위 2 : 보

                if (choice == 0)
                {
                    Console.WriteLine("가위입니다");
                }
                else if (choice == 1)
                {
                    Console.WriteLine("바위입니다");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("보입니다");
                }
                else
                {
                    Console.WriteLine("치트키입니다");
                }
            }

            // switch
            //int choice = 0;
            {
                /*
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("가위입니다");
                        break;
                    case 1:
                        Console.WriteLine("바위입니다");
                        break;
                    case 2:
                        Console.WriteLine("보입니다");
                        break;
                    case 3:
                        Console.WriteLine("치트키입니다");
                        break;
                    default:
                        Console.WriteLine("다 실패했습니다");
                        break;
                }
                */
            }

            // 삼항연산자 (조건 ? 맞을때 : 틀릴때);
            {
                int number = 25;
                bool isPair = ((number % 2) == 0 ? true : false);
                if ((number % 2) == 0)
                {
                    isPair = true;
                }
                else
                {
                    isPair = false;
                }
            }

            // 0 : 가위 1 : 바위 2 : 보
            {
                Random rand = new Random();
                int aiChoice = rand.Next(0, 3); //  0 ~ 2 사이의 랜덤 값

                int choice = Convert.ToInt32(Console.ReadLine()); // 콘솔창에서 enter 누를 때까지 기다림.

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("당신의 선택은 가위입니다.");
                        break;
                    case 1:
                        Console.WriteLine("당신의 선택은 바위입니다.");
                        break;
                    case 2:
                        Console.WriteLine("당신의 선택은 보입니다.");
                        break;
                }
                switch (aiChoice)
                {
                    case 0:
                        Console.WriteLine("컴퓨터의 선택은 가위입니다.");
                        break;
                    case 1:
                        Console.WriteLine("컴퓨터의 선택은 바위입니다.");
                        break;
                    case 2:
                        Console.WriteLine("컴퓨터의 선택은 보입니다.");
                        break;
                }

                // 승리 무승부 패배 (내 방법)
                switch (aiChoice - choice)
                {
                    case 0:
                        Console.WriteLine("무승부입니다.");
                        break;
                    case 1:
                        Console.WriteLine("컴퓨터의 승리입니다.");
                        break;
                    case -2:
                        Console.WriteLine("컴퓨터의 승리입니다.");
                        break;
                    default:
                        Console.WriteLine("당신의 승리입니다.");
                        break;
                }
                // 승리 무승부 패배(선생님 방법)_1
                if (choice == 0)
                {
                    if (aiChoice == 0)
                    {
                        Console.WriteLine("무승부입니다.");
                    }
                    else if (aiChoice == 1)
                    {
                        Console.WriteLine("컴퓨터 승리입니다.");
                    }
                    else
                    {
                        Console.WriteLine("당신의 승리입니다.");
                    }
                }
                else if (choice == 1)
                {
                    if (aiChoice == 0)
                    {
                        Console.WriteLine("당신의 승리입니다.");
                    }
                    else if (aiChoice == 1)
                    {
                        Console.WriteLine("무승부입니다.");
                    }
                    else
                    {
                        Console.WriteLine("컴퓨터 승리입니다.");
                    }
                }
                else // choice == 2
                {
                    if (aiChoice == 0)
                    {
                        Console.WriteLine("컴퓨터 승리입니다.");
                    }
                    else if (aiChoice == 1)
                    {
                        Console.WriteLine("당신의 승리입니다.");
                    }
                    else
                    {
                        Console.WriteLine("무승부입니다.");
                    }
                }


                // 승리 무승부 패배(선생님 방법)_2
                if (choice == aiChoice)
                {
                    Console.WriteLine("무승부입니다.");
                }
                else if (choice == 0 && aiChoice == 2)
                {
                    Console.WriteLine("당신의 승리입니다.");
                }
                else if (choice == 1 && aiChoice == 0)
                {
                    Console.WriteLine("당신의 승리입니다.");
                }
                else if (choice == 2 && aiChoice == 1)
                {
                    Console.WriteLine("당신의 승리입니다.");
                }
                else
                {
                    Console.WriteLine("컴퓨터의 승리입니다.");
                }


                // 가위 바위 보 개선 사항  다 바꿔치기 _ 1
                // Switch 에서는 변수가 아닌 고정값으로 되어야한다. 문제점.
                // 해결점 : const << 상수

                /*
                const int ROCK = 1;
                const int RPAPER = 2;
                const int SCISSORS = 0;
                */

                switch (choice)
                {
                    case (int)Choice.Scissors:
                        Console.WriteLine("당신의 선택은 가위입니다.");
                        break;
                    case (int)Choice.Rock:
                        Console.WriteLine("당신의 선택은 바위입니다.");
                        break;
                    case (int)Choice.Paper:
                        Console.WriteLine("당신의 선택은 보입니다.");
                        break;
                }
            }

            // while 반복문
            {
                int count = 5;

                while (count > 0)
                {
                    Console.WriteLine("Hello World");
                    count--; // count -= 1;
                }

                // 거울아 거울아~
                string answer;
                do
                {
                    Console.WriteLine("강사님은 잘 생겼나요? (y / n) :");
                    answer = Console.ReadLine();
                } while (answer != "y");

                Console.WriteLine("정답입니다!");

                // for(초기화식; 조건식; 반복식)
                //{

                //}
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Hello World");
                }

                // break  continue
                // 특정 조건
                int num = 97;

                bool isPrime = true;
                while (true)
                {
                    break;
                }
                for (int i = 2; i < num; i++)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;
                        Console.WriteLine("소수가 아닙니다.");
                        break;
                    }
                    if (isPrime)
                        Console.WriteLine("소수입니다.");
                    else
                        Console.WriteLine("소수가 아닙니다.");
                }

                for (int j = 1; j <= 100; j++)
                {
                    if ((j % 3) == 0)
                    {
                        continue;
                    }
                    Console.WriteLine($"3으로 나뉘는 숫자 발견 : {j}");
                }
            }


            // 함수
            {
                HelloWorld();

                // 이름으로 들어갈 값을 정하면안된다.
                int a = 4;
                int b = 5;
                // 4, 5 => 9
                int result = ADD(a, b);
                Console.WriteLine(result);

                // 복사(짭퉁) 참조(진퉁)
                int c = 0;

                ADDONE_1(c);  //  복사 개념
                Console.WriteLine(c);

                ADDONE_2(ref c);  //  주소 개념
                Console.WriteLine(c);
            }

            // ref ,  out
            {
                int c = 0;
                c = ADDONE_3(c);
                Console.WriteLine(c);


                int num1 = 10, num2 = 3;
                swap(ref num1, ref num2);
                Console.WriteLine(num1);
                Console.WriteLine(num2);

                //  10 / 3 = 3 * 3 + 1
                int result1, result2;
                Divide(10, 3, out result1, out result2);

                Console.WriteLine(result1);
                Console.WriteLine(result2);
            }

            // 오버로딩 =  함수 이름 재사용
            {
                int ret = Add(2, 3);
                float ret2 = Add(2.0f, 3.0f);
            }
            //Console.WriteLine(ret);
            //Console.WriteLine(ret2);
            // 연습문제 feat.구구단  EZ
            for (int i = 2; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}");
                }
            }

            // 연습문제 feat .별찍기 EZ
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            // 연습문제 feat. 팩토리얼 n!  EZ  스택 오버플로우 = 무한으로 호출
            {
                int ret = Factorial(5);
                Console.WriteLine(ret);
            }
            // 선생님 방법.  재귀 메소드
            {
                int ret = Factorial_1(1);
                Console.WriteLine(ret);
            }
        }
    }
}
