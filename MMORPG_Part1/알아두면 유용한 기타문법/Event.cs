using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C��.MMORPG_�������.MMORPG_Part1.�˾Ƶθ�_������_��Ÿ_����
{
    internal class Event
    {
        static void OnInputTest()
        {
            Console.WriteLine("Input Received!");
        }
        static void Main_Event(string[] args)
        {
            // �̺�Ʈ��  ���������� inputkey�� ȣ���ϴ� ������ ���Ѵ�.
            // ��Ʃ��� ���� �ƶ��̴�. ������ ��� ���� �����־ Ư���Ѱ� ȣ���Ҽ�������.
            // �� delegate �� �Լ� �߰�, ��� ���� �ܺο��� ����������
            // event �� ���� �߰�,��� ������ �ܺο����� ����.

            InputManager inputManager = new InputManager();
            inputManager.InputKey += OnInputTest;

            while (true)
            {
                inputManager.Update();
            }
           
        }
    }
}
