using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C샵.MMORPG_모든지식
{
  
    class 자료구조맛보기
    {
        // 큰값       
        static int GetHighestScore(int[] scores) 
        {
            // 내방법
            { 
                /*
                int high = 0;
                for(int i = 0; i < scores.Length; i++)
                {
                    if(scores[i] > high)
                    {
                        high = scores[i];
                    }
                }
                return high;
                */
            }

            // 선생님 방법
            {
                int maxValue = 0;
                foreach (int score in scores)
                {
                    if (score > maxValue)
                    {
                        maxValue = score;
                    }
                }
                return maxValue;
            }
        } 
      
        // 평균값      
        static int GetAverageScore(int[] scores)
        {
            // 내 방법
            {/*
             
                int sum = 0;
                for(int i = 0; i < scores.Length; i++)
                {
                    sum += scores[i];
                }
                int reuslt = sum / scores.Length;
                return reuslt;
              */
            }

            // 선생님 방법
            {
                if (scores.Length == 0)
                {
                    return 0;
                }
                int sum = 0;
                foreach(int score in scores)
                {
                    sum += score;
                }            
                return sum / scores.Length;
            }
        }
     
        // 수 찾기       
        static int GetIndexOf(int[] scores,int value)
        {
            // 내 방법
            {
                /*
                for (int j = 0; j < scores.Length; j++)
                {
                    if (scores[j] == value)
                    {
                        return j;
                    }

                }
                return -1;
               */
            }

            // 선생님 방법
            {
                for(int a = 0; a < scores.Length; a++)
                {
                    if(scores[a] == value)
                    {
                        return a +1 ;
                    }
                }
                return -1;
            }           
        }
      
        // 수 정렬하기        
        static void Sort(int[] scores)
        {
            // 내 방법
            {
               
                for (int i = 1; i < scores.Length; i ++)
                {
                    for (int j = 1; j < scores.Length; j++) // 이중적으로 계속바꾸기
                    {
                        if (scores[j - 1] > scores[i])
                        {
                            int temp = scores[i];
                            scores[i] = scores[j - 1];
                            scores[j - 1] = temp;
                        }
                    }              
                }
                for (int j = 0; j < scores.Length; j++)
                {
                    Console.WriteLine(scores[j]);
                }            
                
            }

            // 선생님 방법
            {
                for(int i = 0; i < scores.Length; i++)
                {
                    //[i ~ scores.Length  -1] 제일 작은 숫자가 있는 index를 찾는다
                    int minindex = i;
                    for(int  j = i; j < scores.Length; j++)
                    {
                        if(scores[j] < scores[minindex])
                        {
                            minindex = j;
                        }
                    }

                    // swap
                    int temp = scores[i];
                    scores[i] = scores[minindex];
                    scores[minindex] = temp;
                }

            }
        }
       
        // 다차원 배열       
        class Map
        {
            int[,] tiles = {
                { 1,1,1,1,1,},
                { 1,0,0,0,1,},
                { 1,0,0,0,1,},
                { 1,0,0,0,1,},
                { 1,1,1,1,1}
            };

            public void Render()
            {
                var defaultColor =Console.ForegroundColor;
                for(int y = 0; y < tiles.GetLength(0); y ++)
                {
                    for(int x = 0; x < tiles.GetLength(1);  x++)
                    {
                        if(tiles[y,x] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        //Console.Write('Wu25cf');
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = defaultColor;
            }
        }
       
        static void 자료구조(string[] args)
        {
            // 배열
            {
                int[] scores = { 10, 20, 40, 60, 30 };
                // 내방법
                {
                    
                    Console.WriteLine(GetHighestScore(scores)); // 큰값
                    Console.WriteLine(GetAverageScore(scores)); // 평균값            
                    Console.WriteLine(GetIndexOf(scores, Convert.ToInt32(Console.ReadLine()))); // 값 찾기
                    Sort(scores); // 정렬   문제 다해결
                   
                }
                // 선생님 방법
                {   
                    // 큰값 찾기
                    int highestScore = GetHighestScore(scores);
                    Console.WriteLine(highestScore);

                    // 평균 값
                    int averageScore = GetAverageScore(scores);
                    Console.WriteLine(averageScore);

                    // 수 찾기
                    int index = GetIndexOf(scores, 15);
                    Console.WriteLine(index);

                    // 수 정렬
                    Sort(scores);
                    
                }

                // 0 1 2 3 4
                //scores[0] = 10;
                //scores[1] = 20;
                //scores[2] = 30;
                //scores[3] = 40;
                //scores[4] = 50;

                for(int i = 0; i < scores.Length; i++)
                {
                    Console.WriteLine(scores[i]);
                }
                foreach (int score in scores)  // 기억 해둘것
                {
                    Console.WriteLine(score);
                }
            }

            // 다차원
            {
                // 3층 [.......]
                // 2층 [.......]
                // 1층 [.......]            
                
                Map map = new Map();
                map.Render();
               
            }

            // 가변 배열
            {
                int[][] a = new int[2][];
                a[0] = new int[3];
                a[0] = new int[6];
                a[0] = new int[2];

                a[0][0] = 1;
            }
        }
    }
}
