# RPG_GAME
RPG게임만드는 모든지식들.


# BIG-O 표기법

두 알고리즘 A와 B을 비교하려면?<br/>
        1) A가 B보다 "조금","많이"빨라요 => 애매모호<br/>
        2) 프로그램을 짜서  실행 속도 비교? => 환경 의존적<br/>
        3) 입력이 적은 구간과 많은 구간에서 성능이 확연하게 차이가 날 경우는 ?<br/>
<br/>
대안으로 Big-O 표기법을 사용.
<br/>

# BIG-O 표기법 1단계 : 대략적인 계산

<br/>
- 수행되는 연산 (산술,비교 대입 등)의 개수를 '대략적으로'판단<br/>
 "1"<img src="https://user-images.githubusercontent.com/93961708/159437990-ce5731e9-2ea6-42b1-bd16-85372db8d5b8.png"/>
"N + 1"<img src="https://user-images.githubusercontent.com/93961708/159438258-403d4b1d-b01f-402d-8dbc-ad554fd4e764.png"/> 
"N² + 1"<img src="https://user-images.githubusercontent.com/93961708/159438434-f9c28004-3e89-4749-b796-5a82967fe287.png"/> 
<br/>

# BIG-O 표기법 2단계 : 대장만 남긴다

<br/>
규칙1) 영향력이 가장 큰 대표 항목만 남기고 삭제<br/>
규칙2) 상수 무시(ex.2N => N)<br/>
<img src="https://user-images.githubusercontent.com/93961708/159441456-57e647c2-cec2-45ce-87dd-5d77a2e7187f.png"/> O(1 + N + 4 * N² + 1)<br/>
                                                                                                                   = O(4 * N²)<br/>
                                                                                                                   = O(N²)<br/>
                                                                                                                   <br/>
                                                                                                                   * O 는 Order Of라고 읽어요!*
 
 <br/>
 
# BIG-0 표기법의 의의

<br/>
- 입력 N의 크기에 따라 성능이 영향을 받는 정도를 나타냄
<img src ="https://user-images.githubusercontent.com/93961708/159598965-5a4fc9a3-c908-4482-a2e3-22d22ca8984f.png"/>
<img src="https://user-images.githubusercontent.com/93961708/159598987-9be80ed2-325b-49f7-bb68-36504416f05e.png"/>


 
