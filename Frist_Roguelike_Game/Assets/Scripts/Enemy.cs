using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject
{
    public int playerDamage;    // 적이 플레이어를 공격할 때 뺄셈할 음식 포인트

    private Animator animator;  // animator 컴포넌트 저장할 곳
    private Transform target;   // 플레이어 위치 저장하고, 적이 어디로 이동할지 
    private bool skipMove;      // 적이 턴마다 움직이게 하는데 사용

    protected override void Start()
    {
        GameManager.instance.AddEnemyToList(this); // 자기 자신을 게임 매니저 리스트에  더하기
        animator = GetComponent<Animator>(); 
        target = GameObject.FindGameObjectWithTag("Player").transform;  // 플레이어의 transform 저장
        base.Start();
    }      
    
    // 적이 상호작용 할것으로 예상되는 플레이어 입력
    protected override void AttempMove<T>(int xdir, int ydir)
    {
        // 만약 움직일 턴이아니라면
        if(skipMove)
        {
            skipMove = false;
            return;
        }
        // 이동할 x방향과 y방향을 입력받음
        base.AttempMove<T>(xdir, ydir);

        // 적이 이동했으니 skipMov에 참으로
        skipMove = true;
    }

    // 적들을 움직이려 할때 게임 매니저에 의해 호출됨
    public void MoveEnemy()
    {
        int xDir = 0;
        int yDir = 0;

        // 대충 위치가 같은 지 확인 (우리의 적과 플레이어가 같은 열에 속한다는것)
        if(Mathf.Abs (target.position.x - transform.position.x) < float.Epsilon)
        {
            // 같은 열에 있고 y좌표가 더크면 (플레이어 위치) 위로 작으면 아래로 이동
            yDir = target.position.y > transform.position.y ? 1 : -1;
        }
        else 
            // 수평 이동 x좌표(플레이어 위치)가 크면 오른쪽 이동 아니면 왼쪽 이동
            xDir = target.position.x > transform.position.x ? 1 : -1;
        // 플레이어 이동 방향 넣기
        AttempMove <Player>(xDir, yDir);
    }
    // 플레이어가 점거중인 공간으로 적이 이동하려고 할때 호출됨
    protected override void onCantMove<T>(T component)
    {
        Player hitPlayer = component as Player;

        // 적이 공격하는 트리거 발생
        animator.SetTrigger("enemyAttack");

        hitPlayer.LoseFood(playerDamage); // LoseFood에 플레이어가 받은 데미지로 음식점수 잃어버림
    }
}
