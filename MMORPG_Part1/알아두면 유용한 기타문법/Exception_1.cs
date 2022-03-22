using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.MMORPG_모든지식.MMORPG_Part1.알아두면_유용한_기타_문법
{
    internal class Exception_1
    {
        class TestException : Exception
        {

        }
        static void TestFunc()
        {
            throw new TestException();
        }

        static void Main_Exception(string[] args)
        {    
            // 안에서 일어나는 예외 처리를 받아먹을수있다.
            try
            {
                // 1. 0으로 나눌 때
                // 2. 잘못된 메모리를 참조 (null)
                // 3. 오버플로우
                //int a = 10;
                //int b = 0;
                //int result = a / b;

                TestFunc();
            }
            catch (DivideByZeroException e)
            {

            }
            catch (Exception e) // 최상위 조상.
            {

            }
            finally // 예외 이후에 무조건 실행하는거 
            {
                // DB, 파일 정리 등등
            }
           
            
        }
    }
}
