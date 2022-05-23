using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Sprite dmgSprite; // 플레이어가 벽을 성공적으로 때린걸 확인
    public int hp = 4;       // 벽의 체력을 hp로 선언

    private SpriteRenderer spriteRenderer; 

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // spriteRenderer 컴포넌트 저장   
    }

    //  벽에 데미지준걸 확인하기위한 함수
    public void DamageWall(int loss)
    {
        spriteRenderer.sprite = dmgSprite; //   벽을 성공적으로 공격했을 때 시각적인 변화를 줄것
        hp -= loss;
        if(hp <= 0)
        {
            // 만약 hp가 0이라면 gameObject활성화 x
            gameObject.SetActive(false); 
        }

    }
}
