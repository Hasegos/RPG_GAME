using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.MMORPG_모든지식.MMORPG_Part1.알아두면_유용한_기타_문법
{
    internal class Delegate
    {
        // 업체 사장 - 사장님의 비서
        // 우리의 연락처/ 용건 거꾸로 -> 연락을 달라고


        delegate int OnClicked();
        // delegate -> 형식은 형식인데 , 함수 자체를 인자로 넘겨주는 그런 형식
        // 반환 : int 입력 : void 
        // OnClicked 이 delegate 형식의 이름이다!

        // UI
        static void ButtonPressed(OnClicked clickedFunction/* 함수 자체를 인자로 넘겨주고*/)
        {
            // PlayerAttack();
            // 함수를 호출();
            clickedFunction();
        }
        // [10 20 30 40 50 60]
        static int TestDelegate()
        {
            Console.WriteLine("Hello Delegate");
            return 0;
        }
        static int TestDelegate2()
        {
            Console.WriteLine("Hello Delegate 2");
            return 0;
        }
        static void Main_Delegate(string[] args)
        {
            // delegate (대리자)  중요!
            // delegate를 사용해서 함수자체를 인자로 넘겨줘서 그 함수를 호출하는 방식
            // 문제 1. 게임 로직과 UI 로직은 분리를 해둬야한다.
            // 문제 2. cw 처럼 만들어진걸 수정할수 없을경우가 많기때문에 각 함수를 따로
            // 두고 인자로 넘겨주면 각 함수부분만 수정하면되서 문제점이 해결된다.

            OnClicked clicked = new OnClicked(TestDelegate);
            clicked();
            clicked += TestDelegate2;
            ButtonPressed(clicked/* */);
        }
    }
}
