using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MovingObject
{

    public int wallDamage = 1; // 플레이어가 벽을 부술 때 적용할 대미지
    public int pointsPerFood = 10;  // 음식 집었을때 주어지는 점수
    public int pointsPerSoda = 20;  // 소다 집었을때 주어지는 점수
    public float restartLevelDelay = 1f;

    private Animator animator; // 에니메이터 변수선언
    private int food; //  해당 레벨 동안의 스코어 저장할 변수 선언
    
    // Player의 Start 구현
    protected override void Start() 
    {
        // 에니메이터 컴포넌트 넣기
        animator = GetComponent<Animator>();

        // food값을 게임메니저에 있는 playerFoodPoints로 설정
        food = GameManager.instance.playerFoodPoints; 

        base.Start();
    }

    private void OnDisable()
    {
        // 레벨 변화할 때 게임메니저에 food 값 저장
        GameManager.instance.playerFoodPoints = food ; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.playersTurn) // player 턴 체크
        {
            return;
        }

        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)(Input.GetAxisRaw("Horizontal")); // Input 메니저로부터 입력 받기
        vertical = (int)(Input.GetAxisRaw("Vertical"));

        if (horizontal != 0)
        {
            vertical = 0;
        }

        if(horizontal != 0  || vertical != 0)
        {
            // 플레이어가 벽에 대면할지도 모르니 wall 타입으로
            AttempMove<Wall>(horizontal, vertical);
        }
    }

    protected override void AttempMove<T>(int xdir, int ydir)
    {
        food--; //음식 점수에 1빼고
        base.AttempMove <T>(xdir, ydir);

        RaycastHit2D hit;

        CheckIfGameOver(); // 끝났는지 체크하고

        GameManager.instance.playersTurn = false; // 플레이어 턴이 끝남을 알림
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Exit") // 만약 충돌 오브젝트가 출구랑 같다면
        {
            Invoke("Restart",restartLevelDelay); // 충돌후 1초뒤에 이함수 호출
            enabled = false; // 레벨이 끝났으므로 false
        }
        else if(other.tag == "Food") // 음식이랑 같다면
        {
            food += pointsPerFood;
            other.gameObject.SetActive(false); // 충돌했으니 GameObject 비활성화
        }
        else if(other.tag == "Soda")
        {
            food += pointsPerSoda;
            other.gameObject.SetActive(false);
        }
    }

    protected override void onCantMove<T>(T component) // 상속받으니 추상 함수를 작성
    {
        Wall hitWall = component as Wall; // 입력받은 component 를 wall로 변환해서 작성
        hitWall.DamageWall(wallDamage); // 우리가 때린 벽의 DamageWall 호출 /  얼마나 대미지 넣을지 wallDamage 넣기
        animator.SetTrigger("playerChop"); // 트리거 발생시키기
    }
    // 다음 레벨로 넘어가기위한 Restart 함수 발생
    private void Restart()
    {
        SceneManager.GetActiveScene();
    }
    public void LoseFood(int loss)
    {
        animator.SetTrigger("playerHit");
        food -= loss;   // 총 음식점수에서 잃은 만큼 빼기
        CheckIfGameOver();  // 음식점수 잃었기 때문에 game끝났는지 확인
    }


    private void CheckIfGameOver()
    {
        if(food <= 0) // 음식점수가 0이하라면
        {
            // GameOver() 함수 부르기
            GameManager.instance.GameOver();
        }
    }
}
