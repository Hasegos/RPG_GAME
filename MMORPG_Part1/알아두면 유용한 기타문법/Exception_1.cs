using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C��.MMORPG_�������.MMORPG_Part1.�˾Ƶθ�_������_��Ÿ_����
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
            // �ȿ��� �Ͼ�� ���� ó���� �޾Ƹ������ִ�.
            try
            {
                // 1. 0���� ���� ��
                // 2. �߸��� �޸𸮸� ���� (null)
                // 3. �����÷ο�
                //int a = 10;
                //int b = 0;
                //int result = a / b;

                TestFunc();
            }
            catch (DivideByZeroException e)
            {

            }
            catch (Exception e) // �ֻ��� ����.
            {

            }
            finally // ���� ���Ŀ� ������ �����ϴ°� 
            {
                // DB, ���� ���� ���
            }
           
            
        }
    }
}
