using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.TextRPG_2
{
    class TEXTRPG2
    {
        // 1. player 생성  ,  몬스터생성
        // 2. 게임 들어가기
        // 3. 필드 or 도망
        static void Main(string[] args)
        {
            Game game = new Game();
            while(true)
            {
                game.process();
            }
        }

    }
}
