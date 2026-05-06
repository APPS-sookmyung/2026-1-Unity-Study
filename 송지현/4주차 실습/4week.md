### 44. OnCollisionExit2D 사용하기

- OnCollisionEnter2D() :콜라이더가 적용된 오브젝트가 충돌했을 때 이벤트 발생(입자 효과, 레벨 종료, 플레이어 충돌 등을 설정 가능)

- **OnCollisionExit2D()** : 더 이상 콜라이더가 적용된 오브젝트에 충돌하지 않을 때

동일한 개념이 TriggerEnter2D , TirggerExit2D 이다. 


파티클을 생성한 후 아래와 같이 스크립트를 작성해주었다.
```cs
public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustParticles; 

    void OnCollisionEnter2D(Collision2D other) // 밑에 충돌했을 닿았을때
    {
        if(other.gameObject.tag == "Ground") // 충돌한 게임오브젝트의 태그가 Ground일 때
        {
            dustParticles.Play();    
        }
               
    }
    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            dustParticles.Stop();    
        }
    }
}
```

---

### 45. 사운드 이펙트 작동시키기

- Audio Listener(오디오 리스너) : 소리를 받아들이는 마이크(어떤 소리가 나는지 듣는 역할, 기본값은 카메라)
- Audio Source (오디오 소스) : 소리를 만들어내고 설정(소리 크기 조절 등)함
- Audio Clip (오디오 클립): 재생할 소리 데이터(mp3, waves,ogg)

음향 효과는 트리거에 작용시 소리가 난다 

1. 추가할 오디오 파일을 Assets에 생성한 오디오 파일에 추가한 후
2. 오디오를 추가할 오브젝트에 Audio Sorce 컴포넌트를 추가
3. Audio Sorce 안 Audio Generator에 원하는 오디오 넣은 후
 - 3-1. 도착지점 효과음 (하나의 효과음 적용)
  ```cs
   void OnTriggerEnter2D(Collider2D Other)
      {

          if(Other.tag == "Player")
          {
              finishEffect.Play();
              GetComponent<AudioSource>().Play(); // 도착지점 효과음 플레이
              Invoke("ReloadScene", Delay);


          }
      }
      
  - 3-2. 충돌 후 효과음 (여러 효과음 적용 원할 때 - 충돌, 부스터 등등)

```cs

    [SerializeField] AudioClip crashSFX; // 원하는 효과음 추가
    
    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Ground")
        {
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX); 
            // Play()와 차이점 : 다른 음악끼리 겹치지 않음, 딱 한 번만 실행됨
            Invoke("ReloadScene", Delay);
        }
    }
```

>스크립트가 오디오 소스와 동일한 오브젝트 내에 위치할때 : GetComponent<> 사용 가능!

---

### 46. 공용 액세스 한정자

>**현재 문제점** : 레벨 로딩 딜레이 시간이 1초라 머리가 충돌한 이후에도 계속 이동 가능한 문제 발생
**해결방법** : 플레이 사고난 이후 -> 플레이 할 수 없음

PlayController, CrashDetector 두 스크립트를 연결하여 문제 해결

- public : 다른 클래스에서 접근 가능
- private : 현재 클래스 내에서만 접근 가능 (기본값)

>public을 앞에 붙이면 모든 곳에서 접근이 가능해 [SerializeField]와 같이 Inspector에서 조정이 가능하다. 하지만, 다른 스크립트에서도 접근이 가능하다는 점에서 public보다 [SerializeField]를 사용하는 것이 안전하다!

```cs
//PlayerController.cs

bool canMove= true; // 움직임 기본값 

void Update()
    {
        if (canMove) // 컨트롤 가능 여부
        {
            RotatePlayer();
            RespondToBoost();    
        }
    }
    public void DisableControls() // public으로 함수 설정 : 충돌 후 컨트롤X
    {
        canMove=false;
    }
```

```cs
//CrashDetector.cs

 void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Ground")
        {
            FindAnyObjectByType<PlayerController>().DisableControls(); // 컨트롤X 함수 실행
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX); 
            Invoke("ReloadScene", Delay);
        }
    }
 ```
 
 ---
 
### 47. 멀티 플레이 막기
 
 문제점 : 컨트롤은 막아도 머리를 두 번 박는다면 이펙트와 효과음이 두 번씩 생기는 문제
 
 ```cs
  bool hasCrashed = false; // 충돌 전 기본값
    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Ground" && !hasCrashed) // 충돌 여부 확인 후 아래 효과 실행
        {
        	hasCrashed=true; 
            FindAnyObjectByType<PlayerController>().DisableControls();        
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX); 
            Invoke("ReloadScene", Delay); 
            
        }
    }
    
  ```
  
  
  ---
  
###   48. 요약 - 스노우 보더

![](https://velog.velcdn.com/images/jihyun418/post/8a5b7f53-74ab-4dd9-81e0-0e977dd07dc3/image.gif)
