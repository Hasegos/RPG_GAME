using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csw02.Desktop.RPG_GAME_나의것
{
    public class TextRPG
    {
        enum ClassType  // 캐릭터 선택 열거
        {
            None = 0,
            knight = 1,
            Archer =2,
            Mage =3
        }
        struct Player // 캐릭터 체력
        {
            public int hp;
            public int attack;
        }
        enum MonsterType // 몬스터 종류
        {
            None= 0,
            Slime = 1,
            Orc = 2,
            Skeleton = 3
        }
        struct Monster // 몬스터 체력
        {
           public int hp;
           public int attack;
        }
        static  ClassType selectType()  // 캐릭터 선택창.
        {
            
            System.Console.WriteLine("캐릭터 선택창 입니다.");
            System.Console.WriteLine("[1] 기사");
            System.Console.WriteLine("[2] 궁수");
            System.Console.WriteLine("[3] 법사");
            
            ClassType choice =  ClassType.None;
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    choice = ClassType.knight;
                    break;
                case "2":
                    choice = ClassType.Archer;
                    break;
                case "3":
                    choice = ClassType.Mage;
                    break;
            }
            return choice;
            
        }
        static void CreatePlayer(ClassType choice ,out Player player) // 캐릭터 체력,공격력 생성
        {
            // 기사 (100 / 10)  궁수 (75 /15)  법사 (50 / 30)
            switch(choice)
            {
                case ClassType.knight:
                  {
                    player.hp = 100;
                    player.attack = 10;
                    break;
                  }  
                case ClassType.Archer:
                  {
                    player.hp = 75;
                    player.attack = 15;
                    break;
                  } 
                case ClassType.Mage:
                  {
                    player.hp = 50;
                    player.attack = 30;
                    break;
                  } 
                default:
                    player.hp = 0;
                    player.attack =0;
                    break;
            }
        }
        static void CreateRandomMonster(out Monster monster)  // 랜덤 몬스터 생성.
        {
            Random random = new Random();
            int input = random.Next(1,4); // 1 ~ 3
            switch(input)
            {
                case (int)MonsterType.Skeleton:
                    System.Console.WriteLine("스켈레톤이 스폰되었습니다.");
                    monster.hp = 50;
                    monster.attack = 10;
                    break;
                case (int)MonsterType.Orc:
                    System.Console.WriteLine("오크가 스폰되었습니다.");
                    monster.hp = 100;
                    monster.attack = 5;
                    break;
                case (int)MonsterType.Slime:
                    System.Console.WriteLine("슬라임이 스폰되었습니다.");
                    monster.hp = 20;
                    monster.attack = 15;
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }
        static void GoField(ref Player player , ref Monster monster )  // 2. 필드 사냥 하다가 물약 먹기
        {
            int  liquid = 1000;
            while(true)
            {
                monster.hp -= player.attack;
                System.Console.WriteLine($"몬스터의 체력 : {monster.hp}");
                if(monster.hp < 0)
                {
                    System.Console.WriteLine("승리하였습니다!!");
                    break;
                }
                player.hp -= monster.attack;
                System.Console.WriteLine($"당신의 체력 : {player.hp}");
                System.Console.WriteLine("물약을 먹겠습니까? [1] : 예 [2] : 아니오");
                string input = Console.ReadLine();
                switch(input) // 물약 먹기.
                {
                    case "1":
                        if(liquid == 0)
                        {
                            System.Console.WriteLine("물약이 다 떨어졌습니다. 어서소비창에 물약을 추가해주세요!"); // 추가하는 방법 추가.
                            break;
                        }
                        System.Console.WriteLine($"물약을 먹었습니다. 소비창에 있는 물약 개수 : {liquid}");
                        player.hp += 10;
                        liquid -= 1;
                        break;
                    case "2":
                        System.Console.WriteLine("물약을 먹지 않았습니다..");
                        break;
                }                
                if(player.hp < 0)
                {
                    System.Console.WriteLine("패배하였습니다..");
                    break;
                }
            }
        }

        static void EnterGame(ref Player player) // 게임 속으로 들어가기
        {
            while(true)
            {
                Monster monster;
                CreateRandomMonster(out monster);
                System.Console.WriteLine("[1] 필드로 들어가기");
                System.Console.WriteLine("[2] 일정 확률로 도망가기");

                string input = Console.ReadLine();
                if(input == "1")
                {
                    GoField(ref player, ref monster);
                }
                else if(input == "2")
                {
                    Random random =  new Random();
                    int index  = random.Next(1,101);
                    if(index <= 33)
                    {
                        System.Console.WriteLine("도주에 성공했습니다."); // 3. 도망가기
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("도주에 실패했습니다. 그리고 죽었습니다.");
                        break;
                    }
                }
                else
                {
                    System.Console.WriteLine("범위를 초과 했습니다.");
                }
            }
        }   
                static void Main(string[] args)
        {
            System.Console.WriteLine("TEXT_RPG 세계로 온것을 환영합니다.");
            while(true)
            {
                ClassType choice = selectType();  // 1.직업 선택
                if(choice == ClassType.None)
                    continue;
                Player player;
                CreatePlayer(choice ,out player);
                System.Console.WriteLine("["+choice+"]");
                System.Console.WriteLine($"HP : {player.hp}  Attack : {player.attack}");
                EnterGame(ref player);    
            }

           
           
            
        }
    }
}