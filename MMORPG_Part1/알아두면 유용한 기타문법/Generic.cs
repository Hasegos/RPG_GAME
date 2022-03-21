using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.MMORPG_모든지식.MMORPG_Part1.알아두면_유용한_기타_문법
{
    internal class Generic // 일반화
    {
        class MyList<T> //where T : Monster// 일반화 클래스 들어오는 타입을 조건을 걸수도있음.
        {
            T[] arr = new  T[10];
            public T Getltem (int i)
            {
                return arr[i];      
            }
        }
        static void Test<T>(T input)
        {

        }

        static void Main_Generic(string[] args)
        {
            // 1. 각 타입마다 클래스 생성 - 비효율적
            // 2. object 사용해서 어떠한 타입도 다를수있게 - 비효율적
            // object : 어떤 타입도  소화할수있다. 참조 타입으로 힙을 사용해서 느리다.
            // 3. 일반화 사용 - 효율적
            // 클래스나 함수에 <이름> 을 붙여주면 어떤 타입이든 소화가가능하다.
            object obj = 3;
            object obj2 = "hello world";

            Test<int>(3);
            
            int num = (int)obj;
            string str = (string)obj2;
            
            MyList<int> myList = new MyList<int>();
            MyList<short> myshortList = new MyList<short>();
            MyList<Monster> mymonsterList = new MyList<Monster>();
            int item = myList.Getltem(0);
        }
    }
}
