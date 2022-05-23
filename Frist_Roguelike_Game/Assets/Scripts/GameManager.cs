using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float turnDelay = .1f; // 턴사이 게임이 얼마동안 대기할지 정함

    public static GameManager instance = null; // 다른 클래스에서 GameManager에 접근 가능

    public BoardManager boardScript;           // 레벨을 설정할 BoardManager에 대한 참조를 저장

    private int level = 3;                      // Day1, 게임에서의 현재 레벨 번호

    public int playerFoodPoints = 100;          // 음식 포인트 100 초기화

    [HideInInspector] public bool playersTurn = true;   // HideInInspector : public 변수지만 에디터에서 숨긴다  

    private List<Enemy> enemies; // 적의 위치 추적하고 움직이도록 명령할것.

    private bool enemiesMoving; // 움직일 수 있는 지 판단

    // Awake는 항상 start 함수 전에 호출된다.
    void Awake()
    {
        // instance에 값이 없다면 이스크립트를 넣어주고
        if(instance == null)
        {
            instance = this;
        }
        //  만약 instance가 이 스크립트가 아니라면 gameObject를 삭제하자. 중복 생성 방지하기위해서
        else if(boardScript != this)
        {
            Destroy(gameObject);
        }
        // 다른  씬으로 넘어갈 때 gameObject가 사라지지   않는다.
        DontDestroyOnLoad(gameObject);

        // 동적할 당함
        enemies = new List<Enemy>(); 

        // Call by reference
        // 연결된 BoardManager 스크립트에 대한 구성 요소 참조 가져 오기
        boardScript = GetComponent<BoardManager>();

        // 첫 번째 레벨을 초기화
        InitGame();
    }

    // 각 레벨에 맞게 게임을 초기화
    void InitGame()
    {
        enemies.Clear();
        // 현재 레벨 번호 전달(적이 얼마나 나올지 결정)
        boardScript.SetupScene(level);
    }
    // 게임 메니저 비활성화 할곳
    public void GameOver()
    {
        enabled = false;
    }    
    void Update()
    {
        // 플레이어 이동과 적이동 체크
        if(playersTurn || enemiesMoving)
        {
            return;
        }
        // 이동을안하고있으면 호출
        StartCoroutine(MoveEnemies());  
    }
    // 게임 매니저에 등록후 게임 매니저가 적을 움직일 수 있게 만듦
    public void AddEnemyToList(Enemy script)
    {
        enemies.Add(script);
    }
    IEnumerator MoveEnemies()
    {
        // 적이동 참
        enemiesMoving = true;

        // 대기 시간 0.1초
        yield return new WaitForSeconds(turnDelay);

        // 적이없다는건 플레이어만 있다는 뜻으로 일단 0.1초 대기
        if(enemies.Count == 0)
        {
            yield return new WaitForSeconds(turnDelay);
        }

        // 적 수만큼 반복
        for(int i = 0; i < enemies.Count; i++)
        {
            // 적들마다 이동
            enemies[i].MoveEnemy();

            // 이동할 때마다 다른적은 0.1초 대기
            yield return new WaitForSeconds(enemies[i].moveTime);
        }

        // 끝나면 플레이어 이동가능
        playersTurn = true;

        // 적이동은 끝
        enemiesMoving = false;
    }

}
