## 35. 서페이스 이펙터 2D 사용하기

### 01 플레이 시 베리에게 공처럼 물리법칙이 적용되지 않음(멈춰버림)
add component > [Surface Effector 2D] > Edge Collider 2D의 Used By Effector 적용

### 02 플레이 시 베리가 너무 느림
![](https://velog.velcdn.com/images/dong9rami/post/19ee57c5-a9b5-4c07-8920-c96cfef10894/image.png)

Suface Effector 2D의 하위항목[Force]에서 물리적 설정

[Force] 
Speed : - 0 + 
Speed Variation
Force Scale : 오르막길을 오르게 해줌

### 03 이펙터 작동 시 충돌영역 오류
Barry > Rigidbody 2D > Collision Detection > Continuous

## 36. 회전_AddTorque

### 01 플레이어 회전 시키기

01) C# 스크립트 생성
![](https://velog.velcdn.com/images/dong9rami/post/1bf9aa47-69af-4467-a204-f972ce7edcdf/image.png)

02) 왼쪽 방향키/오른쪽 방향키를 누르면 회전할 수 있도록 코딩

![](https://velog.velcdn.com/images/dong9rami/post/c2315156-6f1e-42e9-8d1e-9429ab1c854b/image.png)

03) PlayerController Script를 배리에게 추가
- Torque Amount 값 조정
![](https://velog.velcdn.com/images/dong9rami/post/73bc632c-dd61-41b2-8ba6-4d5a939532ed/image.png)

### 02 변수 값 조정

![](https://velog.velcdn.com/images/dong9rami/post/0c60b554-abee-4324-ad08-15a028f0c7a5/image.png)

- Angular Drag : 회전을 할 때 얼마나 마찰을 줄 것인가
- Linear Drag : 앞/뒤로 갈 때 얼마나 마찰을 줄 것인가
- Angular Drag 와 Torque Amount(회전시키는 속도)는 서로 연관됨

## 37. Triggers To Restart Level

### 01 플레이어 FinishLine 통과 감지 

01) C# 스크립트 생성

![](https://velog.velcdn.com/images/dong9rami/post/4b2071dc-a06c-4caa-bfb3-56a60319c431/image.png)

02) Create Empty

시각적으로 보이는 대상이 필요하긴 하지만 상위오브젝트에 영향을 주지 않기 위해 

![](https://velog.velcdn.com/images/dong9rami/post/9b67de0d-9073-49d5-a13e-566ba6319d82/image.png)

03) Finish Line 생성

![](https://velog.velcdn.com/images/dong9rami/post/709fa45d-b1c2-48e0-b43f-307aa331015b/image.png)

04) 충돌 영역 지정

Box Collider 2D를 이용하여 충돌영역 지정

![](https://velog.velcdn.com/images/dong9rami/post/7e6634de-2882-4270-8e44-91778a316248/image.png)

Barry를 Player로 태그

![](https://velog.velcdn.com/images/dong9rami/post/97faf766-7d90-4233-8c35-6734b2affb97/image.png)

코딩

![](https://velog.velcdn.com/images/dong9rami/post/cf137835-94d4-40fe-bfd2-d4f995f7a978/image.png)

결과

![](https://velog.velcdn.com/images/dong9rami/post/d6895634-9632-47e7-98c4-80af253161bc/image.png)

### 02 플레이어 충돌 감지

태그

![](https://velog.velcdn.com/images/dong9rami/post/0d700f4c-2869-4ae9-8d31-3671e110a7b3/image.png)

코딩

![](https://velog.velcdn.com/images/dong9rami/post/7e60d0e9-d538-4697-aa8c-251ba6a799ae/image.png)

결과

![](https://velog.velcdn.com/images/dong9rami/post/d06ce95f-7960-443a-b317-94ed940f2aef/image.png)

## 38. 네임스페이스 & 씬 전환

<SceneManagement 네임스페이스에 포함된 SceneManager 클래스 이용>

### #Organizing Code

- The more code we have, the higher likelyhood of comflicts between names and behaviors. Especially on multi - person projects. 

- So in C# our code is grouped with a particular structure to reduce conflicts.

![](https://velog.velcdn.com/images/dong9rami/post/8f8e2c47-23b7-42e6-a8ed-ed156083c995/image.png)


### 01 FinishLine 통과 감지 시 처음시작점으로 돌아가는 기능 구현


01) 코딩

![](https://velog.velcdn.com/images/dong9rami/post/ae66abae-67ee-4d36-89d7-2b743a86d793/image.png)

02) Scenes 폴더에 Level1 추가 후
File > Buildsettings 의 Scenes In Build 에 Level1 추가

![](https://velog.velcdn.com/images/dong9rami/post/f7d2a541-3bed-420b-a30d-2a5b2323581e/image.png)

03) 결과

![](https://velog.velcdn.com/images/dong9rami/post/2245f4d3-12ff-4652-a669-7e2db5b118d6/image.gif)

### 02 플레이어 충돌 감지 시 처음시작점으로 돌아가는 기능 구현


01) 코딩

![](https://velog.velcdn.com/images/dong9rami/post/d21f098f-7ddb-490d-a8f9-d754beef84f4/image.png)

02) 결과

![](https://velog.velcdn.com/images/dong9rami/post/d3fb9de7-dacb-4134-98bb-5d9f6f42d45f/image.gif)

## 39. Invoke()로 딜레이하기

### #Creating A Delay

- There are 2 useful approaches to "waiting a moment".
-> Invoke
-> Corutines
- Invoke is a bit easier to understand but not as powerful.

### #Using Invoke()

- When we call Invoke() we need to pass in the name of the method we want to call a delay, as well as how long the delay is.
-> Invoke("NameOfMethod", delay);

### 01 FinishLine 충돌 시 딜레이

![](https://velog.velcdn.com/images/dong9rami/post/867fb451-a404-4487-ac77-81f1d700ed4a/image.png)

### 02 딜레이 시간 조정

Quiz.딜레이 시간을 코드로 조정하는 것이 아닌 Inspector에서 조정할 수 있게 코딩하기

01) FinishLine 충돌 시 1초 딜레이 후 시작점으로 복귀

![](https://velog.velcdn.com/images/dong9rami/post/658789a9-15d3-4a66-85cd-8d51824ed404/image.png)

02) 머리 충돌 시 0.5초 딜레이 후 시작점으로 복귀

![](https://velog.velcdn.com/images/dong9rami/post/0688eb56-06cb-459b-b7f4-283f48449198/image.png)




