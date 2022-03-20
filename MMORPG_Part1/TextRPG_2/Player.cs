using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.TextRPG_2
{
    enum PlayerType // 전직 타입
    {
        None = 0,
        nalo = 1,
        sseonkol = 2,
        paenteom = 3
    }
    class Player : Creature
    {        
        PlayerType type = PlayerType.None;
        public Player(PlayerType type) : base( CreatureType.Player) // player 타입 설정
        {
            this.type = type;
        }
        
        public PlayerType GETPLAYERTYPE(){ return type; }    // 이부분 이해하기.       

    }
    class Nalo : Player  // 나로
    {
        public Nalo() : base (PlayerType.nalo)
        {
            setability(50, 150);
        }

    }

    class Sseonkol : Player  // 썬콜
    {
        public Sseonkol() : base(PlayerType.nalo)
        {
            setability(100, 120);
        }
    }

    class Paenteom : Player  // 팬텀
    {
        public Paenteom() : base(PlayerType.nalo)
        {
            setability(50, 100);
        }

    }

}
