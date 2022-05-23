using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour // abstract : 기능완성은 지금당장하지않고 파생클래스에서 완성할것.
{
    public float moveTime = 0.1f; // 오프젝트 움직일 시간초

    public LayerMask blockingLayer; // 이동할 공간을 열려있고 , 그곳으로 이동시 충돌발생 (충돌 체크하기위해서)

    private BoxCollider2D boxCollider; // BoxCollider2D 변수인 boxCollider 선언.

    private Rigidbody2D rb2D; // Rigibody 변수인 rb2D선언

    private float inverMoveTime; // 움직임을 더효율적으로 계산하기위해서 사용
    
    protected virtual void Start() // 재설정을 위해서(오버라이딩)
    {
        boxCollider = GetComponent<BoxCollider2D>(); // BoxCollider2D  레퍼런스 저장
        rb2D = GetComponent<Rigidbody2D>(); // 마찬가지로 저장
        inverMoveTime = 1f / moveTime;
    }
    // bool 타입과 RaycastHit2D 타입 둘다 반환
    protected bool Move(int xDir, int yDir,out RaycastHit2D hit) // 두개이상을 리턴하기위해서 out 키워드 사용함
    {
        Vector2 start = transform.position; // 현재 오브젝트 위치 저장하기위해서 사용 
                                            // 추가적으로 3차 백터에서 2차로 넘어갈때 z축 삭제 하고넘어감
        Vector2 end = start + new Vector2(xDir, yDir);// 입력받은 방향 값들을 기반으로 끝나는 위치를 계산하는데 사용

        boxCollider.enabled = false;    // 부딪히지않기위해서 해제
        hit = Physics2D.Linecast(start, end, blockingLayer); // 시작지점에서 끝지점까지의 라인가져오기, blockingLayer 와의 충돌검사
        boxCollider.enabled = true;

        if(hit.transform == null) // 만약 없다면 열려있다는것으로 이동가능하고 우리가 end를 입력받은 SmoothMovement 코루틴 시작
        {
            StartCoroutine(SmoothMovement(end));
            return true;
        }
        return false;
    }


    protected IEnumerator SmoothMovement(Vector3 end) // 유닛을 한공간에서 다른 공간 이동할때 사용
    {                                                 // 어디로 이동할건지 표시할 end를 입력으로 받는다.   
                                                      //  남은 거리를 구할것. ( end 위치와 현재위치 차이 벡터에 sqr로 거리를 구하기)
                                                      //  Magintude - 벡터 길이,  sqrMagintude - 벡터길이 제곱  / 속도는 sqr이 더빠르다.
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        while(sqrRemainingDistance > float.Epsilon) // 남은 거리가 0보다 큰지 확인. Epsilon은 0에 극한으로 가까운 수
        {
            // moveTime에 기반해서 적절이 end에 가까운 새로운 위치발견
            Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverMoveTime * Time.deltaTime);

            // 새 지점으로 이동시키기 위해서 사용
            rb2D.MovePosition(newPosition);

            // 이동후 다시 거리 계산
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            //   루프 갱신전 다음 프레임을 기다림
            yield return null; 
        }
    }

    protected virtual void AttempMove<T>(int xdir, int ydir) // 막혔을때 사용할 컴포넌트 타입
        where T : Component // 컴포넌트 종류 가르킨다
    {
        RaycastHit2D hit;
        bool canMove = Move(xdir, ydir,out hit); // out으로 들어갔기때문에 부딫친 transform이 null인지 확인가능

        if(hit.transform == null) // null이라면 안부딫혔기때문에 그냥 끄고
            return;
        T hitcomponent = hit.transform.GetComponent<T>(); // 부딫히면  T타입 컴포넌트 할당        

        if(!canMove && hitcomponent != null)
        {
            onCantMove(hitcomponent);
        }
    }

    protected abstract void onCantMove <T>(T component)   // T형의 component라는 변수로서 받아오기
        where T : Component;
    
   
}
