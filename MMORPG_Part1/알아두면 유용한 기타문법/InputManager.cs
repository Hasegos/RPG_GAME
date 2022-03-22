using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.MMORPG_모든지식.MMORPG_Part1.알아두면_유용한_기타_문법
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
                // 모두한테 알려준다!
                InputKey();
            }
        }

    }
}
