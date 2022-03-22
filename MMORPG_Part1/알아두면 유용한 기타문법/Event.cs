using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.MMORPG_모든지식.MMORPG_Part1.알아두면_유용한_기타_문법
{
    internal class Event
    {
        static void OnInputTest()
        {
            Console.WriteLine("Input Received!");
        }
        static void Main_Event(string[] args)
        {
            // 이벤트는  실질적으로 inputkey를 호출하는 행위는 못한다.
            // 유튜브랑 같은 맥락이다. 구독을 취소 더할 수는있어도 특정한걸 호출할순없듯이.
            // 즉 delegate 는 함수 추가, 취소 또한 외부에서 쓸수있으나
            // event 는 구독 추가,취소 하지만 외부에서는 못씀.

            InputManager inputManager = new InputManager();
            inputManager.InputKey += OnInputTest;

            while (true)
            {
                inputManager.Update();
            }
           
        }
    }
}
