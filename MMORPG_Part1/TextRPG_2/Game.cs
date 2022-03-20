using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.TextRPG_2
{
    // 로비 필드 도망(마을) 싸우기
    enum GameType
    {
        None,
        Lobby,
        Feild,
        Town
    }
    class Game 
    {
        Random rand = new Random(); // 몬스터 랜덤 숫자
        GameType mode = GameType.Lobby; // 게임 모드 
        Player player = null; // 플레이어 타입 x
        Monster monster = null; // 몬스터 타입 x
        
        public void process() // 게임 선택
        {
           switch(mode)
            {
                case GameType.Lobby:
                    Lobby();
                    break;
                case GameType.Town:
                    TOWN();
                    break;
                case GameType.Feild:
                    feild();
                    break;
                default:
                    break;
            }
        }
        public void TOWN() // 마을 가기
        {
            Console.WriteLine("마을에 도착했습니다.");
            Console.WriteLine("[1] 필드로 이동");
            Console.WriteLine("[2] 로비로 이동");

            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    mode = GameType.Feild;
                    break;
                case "2":
                    mode = GameType.Lobby;
                    break;
                default:
                    break;
            }

        }
        public void Lobby() // 로비 가기
        {
             // 직업 선택
            
                Console.WriteLine("메이플월드에 오신걸 환영합니다.");
                Console.WriteLine("직업을 선택하세요!");
                Console.WriteLine("[1] 나로");
                Console.WriteLine("[2] 썬콜");
                Console.WriteLine("[3] 팬텀");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        player = new Nalo();
                        mode = GameType.Town;
                        break;
                    case "2":
                        player = new Sseonkol();
                        mode = GameType.Town;
                        break;
                    case "3":
                        player = new Paenteom();
                        mode = GameType.Town;
                        break;
                    default:
                        Console.WriteLine("오류입니다.");
                        break;
            }

        }

        public void feild() // 필드
        {
            Console.WriteLine("필드에 입장하셨습니다.");
            Console.WriteLine("[1] 싸우기!");
            Console.WriteLine("[2]도망치기!");
            string input = Console.ReadLine();
            Creatmonster();
            switch (input)
            {
                case "1":
                    Fight();
                    break;
                case "2":
                    escape();
                    break;
                default:
                    break;
            }
           
        }
        public void Fight() // 싸우기
        {
            while (true)
            {
                int damage = player.GetATTACK();
                monster.DAMAGE(damage);
                if (monster.IsDead())
                {
                    Console.WriteLine($"현재 남은 체력{player.hp}");
                    Console.WriteLine("승리하였습니다.");
                    break;
                }
                damage = monster.GetATTACK();
                player.DAMAGE(damage);
                if (player.IsDead())
                {
                    Console.WriteLine("패배하였습니다.");
                    break;
                }
                Console.WriteLine($"공격을 받고 남은 체력 {player.hp}");
            }

        }
        public void Creatmonster() // 몬스터 생성
        {
            int randvalue = rand.Next(1, 4);
            switch (randvalue)
            {
                case 1:                    
                    Console.WriteLine("스톤키위가 등장했습니다.");
                    monster = new StoneKiwi();
                    break;
                case 2:                    
                    Console.WriteLine("세냐보그 알파버전이 등장했습니다.");
                    monster = new SenyabotAlpha();
                    break;
                case 3:
                    Console.WriteLine("모래칼날 약탈꾼이 등장했습니다.");
                    monster = new SandbladeMarauder();
                    break;
                default:
                    break;
            }
        }

        public void escape() // 도망
        {
            int RAND = rand.Next(1, 101);

            if(RAND <= 33)
            {
                Console.WriteLine("무사히 도망갔습니다!!");
                mode = GameType.Town;           
            }
            else
            {
                Console.WriteLine("도망가지 못했습니다 ㅠㅠ");
                Fight();
            }

        }
    }
    
    
}
