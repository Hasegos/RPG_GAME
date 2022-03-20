using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.MMORPG_모든지식
{
    // 객체(OOP Object Oriented Programming)
    // OOP(은닉성/상속성/다형성 polymorphism)  상속 : 필드들이 따라온다.

    // 자동차
    // 핸들 페달 차문을 열고
    // 전기장치 엔진 <->  외부 노출



    // Knight
    // 속성 : hp, attack , pos
    // 기능 : Move , Attack , Die

    // REF 참조 주소로 움직임.
    
    class Player_2  // 부모 / 기반 
    {

        static public int count = 1; // 오로직 한개만 존재
        public int id;
        public int hp;
        public int attack; // public : 공유

        public Player()
        {
            Console.WriteLine("Player 생성자 호출");
        }

        public Player(int hp)
        {
            Console.WriteLine("Player hp 생성자 호출");
        }
        public void Move()
        {
            Console.WriteLine("Player Mover");
        }
        public void Attack()
        {
            Console.WriteLine("Player Attack");
        }


    }

    class Mage_1 : Player // 자식 / 파생
    {


    }
    class Archer_2 : Player
    {

    }
    class Knight_2 : Player
    {

        int c;
        public Knight() : base(100)  // 상위 생성자 호출 할 수도 있음.
        {
            this.c = 10;
            base.hp = 100;
            Console.WriteLine("Knight 생성자 호출");
        }


        // public 같은 경우는 여러곳에서 다다를수있는데.
        // 뭘 알고 클래스에 종속인애가 그 값을 바꾸겠냐.


        static public void Test()  // static 은 static 변수만. 가능
        {
            count++;
        }
        static public Knight CreateKnight()
        {
            Knight knight = new Knight();
            knight.hp = 100;
            knight.attack = 1;
            return knight;
        }


        public Knight() // 반환하는 타입x
        {
            id = count;
            count++;

            hp = 100;
            attack = 10;
            Console.WriteLine("생성자 호출");
        }
        public Knight(int hp) : this() // 해당 함수 호출
        {
            this.hp = hp;
            Console.WriteLine("int 생성자 호출!");
        }

        public Knight(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
            Console.WriteLine("int,int 생성자 호출!");
        }

        public Knight Clone()
        {
            Knight knight = new Knight();
            knight.hp = hp;
            knight.attack = attack;
            return knight;
        }

        public void Move()
        {
            Console.WriteLine("Knight Move");
        }
        public void Attack()
        {
            Console.WriteLine("Knight Attack");
        }


        // 접근 한정자
        // public : 다 공유 protected : 상속 받으면 사용 가능 private :  상속 받아도 함부로 사용 x
        protected int hp;

        public void SrcretFunction(int hp)
        {
            this.hp = hp;
        }

    }
    class SuperKnight_1 : Knight
    {
        void Test()
        {
            hp = 10;
        }

    }


    class Player_1
    {
        public int hp;
        public int attack;

        public virtual void Move()
        {
            Console.WriteLine("Player 이동!");
        }
    }
    class Knight_1 : Player_1
    {

        public override void Move() // sealed 는 나까지만 되고 내밑으로 안된다.
        {
            base.Move();
            Console.WriteLine("Knight 이동!");
        }
    }
    // 오버로딩(함수 이름 재사용) 오버라이딩(다형성)
    class Mage_2 : Player_1
    {
        public int mp;

        public override void Move()
        {
            Console.WriteLine("Mage 이동!");
        }
    }
    class SuperKnight : Knight_1
    {
        public override void Move()
        {
            Console.WriteLine("SuperKnight 이동");
        }
    }



    // 복사
    struct Mage_3
    {
        public int hp;
        public int attack;
    }
    class 객체지향_여행
    {
        static Player FindPlayerByld(int id)
        {
            // id에 해당하는 플레이어를 탐색

            // 못찾으면
            return null;

        }
        static void KillMage(Mage mage)
        {
            mage.hp = 0;
        }
        static void KillKnight(Knight knight)
        {
            //knight.hp = 0;
        }

        static void EnterGame(Player_1 player_1)
        {

            player_1.Move();

            // '없음'
            Mage_2 isMage = (player_1 as Mage_2); // 제일 깔끔한 코드
            if (isMage != null)
            {
                isMage.mp = 10;
                isMage.Move();
            }
            Knight_1 isknight = (player_1 as Knight_1);
            if (isknight != null)
            {
                isknight.Move();
            }

        }

        static void 객체(string[] args)
        {
            {

                Mage mage;
                mage.hp = 100;
                mage.attack = 50;
                KillMage(mage);

                Mage mage2 = mage;
                mage2.hp = 0;


                Knight knight = new Knight(50, 5);
                knight.hp = 100;
                knight.attack = 10;


                Knight knight2 = knight.Clone();
                knight2.hp = 0;

            }
            {
                // 스택 메모리(stack)   힙 메모리(heap)
                /*
                    스택은 불안전함. 
                    stack  vs  heap

                    스택은 요약해서 어떠한 함수를 실행시키기 위한 메모장 같은 개념
                    이제 중요한건  참조(ref) vs  복사(struct) 

                    struct는 스택에 하나하나가 본체로 작용하고

                    ref 는 스택에 주소로 작용하며 이것에 본체는 heap에 있고

                    stack에 할당된것들은 알아서 관리해주는데 heap은 관리를 x 그래서 할당하고 지우고 해야함

                    또한 heap에 무조건 ref 본체가 있는건 아님 stack에 있을 수 있음.
                */
                
            }
            SuperKnight super = new SuperKnight();
            Knight_1 knight_2 = null;
            Knight_1 knight_1 = new Knight_1();
            Mage_2 mage_2 = new Mage_2();

            // Mage 타입  ->  Player 타입
            // Player 타입 -> Mage 타입 ?

            Player magePlayer = mage_2;
            Mage_2 mage2 = (Mage_2)magePlayer;

          
            knight.Move();
            knight.hp = 1;
            knight.SrcretFunction(10);
           
            EnterGame(knight_1);
            
            knight_1.Move();
            mage_2.Move();
            


            string name = "Harry Potter";

            // 1.찾기
            bool found = name.Contains("Harry");
            int index = name.IndexOf("P");

            // 2. 변형
            name = name + "Junior";
            string lowerCaseName = name.ToLower();
            string upperCaseName = name.ToUpper();
            string newName = name.Replace('r', 'l');

            // 3. 분활
            string[] names = name.Split(new char[] { ' ' });
            string subStringName = name.Substring(5);



        }
    }
}

