### #44 OnCollisionExit2D사용하기

onCollisionEnter2D와 OnCollisionExit2D를 이용하여 눈 입자 효과 구현
![](https://velog.velcdn.com/images/dong9rami/post/d4fbdba4-6650-4631-9916-f7b15e1ca73a/image.png)
![](https://velog.velcdn.com/images/dong9rami/post/fafe4b5d-df7b-46ca-bd3b-73311f6351ee/image.gif)

### #45 사운드 이펙트 작동시키기

Audio Listener - receives sounds and plays through my computer's speakers
Audio Source - Plays audio and allows us to adjust settings
Audio Clip - Contains the audio data to be played

Audio Clip 지정
![](https://velog.velcdn.com/images/dong9rami/post/c4c016db-d7db-4839-aa62-51b3c11f5398/image.png)

Audio Clip 미지정
![](https://velog.velcdn.com/images/dong9rami/post/d698deb2-6539-46ee-ae13-1a3c79d84405/image.png)

### #46 공용 액세스 한정자

- 플레이어의 머리가 충돌한 이후에도 계속 이동함
-> 이를 해결하기 위해 PlayerController와 CrashDetector를 public을 이용하여 연결

public : 다른 class에서 조작 가능
private : 현재 class에서만 조작 가능
public access modifier

- PlayerController
![](https://velog.velcdn.com/images/dong9rami/post/a18a0376-47e6-4bc2-a484-4bb9ed94a7f9/image.png)
![](https://velog.velcdn.com/images/dong9rami/post/9109ed95-f4cf-4688-8281-6e054f1aa0c4/image.png)

- CrashDetector
![](https://velog.velcdn.com/images/dong9rami/post/3a61feb8-19a4-4d91-9122-d51148b40462/image.png)

### #47 멀티 플레이 막기

Crash SFX 와 Particle effect 가 1번만 trigger되게 하기

![](https://velog.velcdn.com/images/dong9rami/post/52f5e057-35fe-417c-90c1-d467d992e1a3/image.png)

### #48 요약 - 스노우보더

점수, 회전, 타이머, 위험물, 다른 점프, 부스트, 레벨추가 등 다른 것 시도해보기

### 끝~~!