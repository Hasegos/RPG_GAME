using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C��.MMORPG_�������.MMORPG_Part1.�˾Ƶθ�_������_��Ÿ_����
{
    class InputManager
    {
        public delegate void OnInputKey();
        public event OnInputKey InputKey;

        
        public void Update()
        {
            if(Console.KeyAvailable == false)
            {
                return;
            }
            ConsoleKeyInfo info = Console.ReadKey();
            if(info.Key == ConsoleKey.A)
            {
                // ������� �˷��ش�!
                InputKey();
            }
        }

    }
}
