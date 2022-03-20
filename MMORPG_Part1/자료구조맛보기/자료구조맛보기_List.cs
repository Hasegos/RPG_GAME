using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.MMORPG_모든지식
{
    class 자료구조맛보기_List
    {
        static void List(string[] args)
        {
            // List <- 동적 배열  List = 결국 class 개념 즉 참조라서 객체생성 필요
            // [0 1 2 3 4 ]
            List<int> list = new List<int>();
            for(int i = 0; i < 5; i++)
                list.Add(i);

            // 삽입 삭제
            list.Insert(2, 999);  // 삽입

            // 삭제
            list.RemoveAt(0);
            bool success = list.Remove(3);

            // 전체 삭제
            list.Clear();

            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);

            foreach(int num in list)
                Console.WriteLine(num);
        }
    }
}
