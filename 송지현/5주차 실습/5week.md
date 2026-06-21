### 49. 소개 - 퀴즈마스터
 주요 학습 내용 
 - 사용자 인터페이스, UI
 - 글자, 이미지, 캔버스추가, 키입력 버튼, 슬라이더
 - 데이터 저장

---
---

### 50. 게임 디자인 - 퀴즈 마스터

1. 게임 컨셉
- 퀴즈 게임
- 질문에 대한 답을 고름
- 제한된 시간안에 답변
- UI 집중 게임 진행

2. 게임 메커니즘
- 질문 저장 후 불러올 수 있는 메커니즘
- 플레이어가 선택할 버튼
- 간단한 타이머
- 남은 퀴즈 확인 가능한 진행률 바(슬라이더 사용)
- 점수 시스템
- 퀴즈 끝난 이후 다시 시작 버튼

3. 게임 디자인
   - 플레이어 경험 : 지식 함양
   - 기본 메커니즘 : 지식 테스트, 공부
   - 게임 루프: 주어진 주제 일정 수의 질문을 제한시간 내에 답변하기
   
게임 주제 : 아직 미정.. 

---
---

### 51. UI 캔버스

다른 이미지도 대체하고 싶은데 시간이 없어서 제공된 이미지로 만들었다 ㅎ.. 다음에 변경할 예정이다!!

**UI Canvas**
- UI :User Interface (텍스트, 버튼, 슬라이더, 메뉴, 미니맵 ) 유저가 상호작용할 수 있는 요소
- 유니티의 UI 요소 위치 : 캔버스 (UI 요소가 Canvas라는 부모 오브젝트 안에 들어가야 화면에 표시됨)
- Screen Space Canvas = 게임 속 공간이 아닌, 플레이어 화면 위에 고정된 UI 판 (캐릭터가 돌아다니는 화면에 상관없이 항상 고정된 화면 -> 체력바, 점수, 버튼 등)
-  World Space Canvas = 게임 월드 안에 실제 물체처럼 존재하는 UI 판 (캐릭터 머리 위 체력바, 이름표 등)
---
1. 캔버스 생성
   - Hierarchy -> UI -> Canvas
     - 캔버스의 Inspector를 확인하면 다른 오브젝트와 다르게 Standard Transform Component가 없는 대신에 Rect Transform가 존재한다.

2. 생성한 캔버스 하위에 Image 생성 후 위치 조정 
   - Anchor Presets : UI 위치의 기준점
![](https://velog.velcdn.com/images/jihyun418/post/bb8cdf3e-f8ee-4906-846e-88a07333a699/image.png)
   - Shift : Pivot(UI 자기 자신의 중심점/회전 기준점) 아이콘 추가
   - Alt : 위치 변경
   - Shift+Alt : 피봇 추가 후 그 위치로 변경

3. 해상도 HD로 변경
   -  게임 뷰 -> Free Aspect -> Full HD(1920x1080)

4. 게임 진행의 필요한 요소들을 배치(레이아웃)하는 것을 도와줄 미리 보기 이미지 설정
   - 이미지 컴포넌트 안 Source Image 옵션에 미리보기 이미지 추가
   - 컬러 설정에 투명도 값을 조정해 투명하게 설정
   - 그 후 Canvas 컴포넌트 안에  Sort Order 값을 100으로 설정
      - Sort Order: 값이 클수록 더 앞쪽에서 보임
      
5. 위에 방식을 적용해 배경 이미지 설정까지 완료
![](https://velog.velcdn.com/images/jihyun418/post/e0c18b95-86a1-4d45-967e-d777dd583929/image.png)
---
---
### 52. 텍스트 메쉬 프로


>**TextMeshPro 사용전 설정**
위 창 Window에서 TextMashPro -> Import TMP Essential Resources -> 모든 체크 박스 선택된 지 확인 후 Import -> Assets 폴더에 파일 생성 완료

1. 텍스트 추가
     - 이미지 추가 원하는 캔버스 왼쪽 클릭 후 UI -> Text -TextMeshPro 

2. 텍스트 크기 조정 및 문구 추가
   - 텍스트를 원하는 곳에 이동한 이후 알맞게 크기를 조절해준다
   - TextMeshPro 컴포넌트에서 원하는 글자 문구로 수정
   - Font Size 조절

3. 폰트 추가
   - 원하는 폰트 파일을 Assets 폴더에 추가
   - 기본 폰트 파일을 TextMeshPro 사용할 수 있는 Font Asset으로 변경 (폰트 생성)
   - 생성한 폰트를 TextMeshPro 컴포넌트 안에 Font Asset에 추가
   
   
   >**폰트 생성**
   window -> TextMestPro -> Font Asset Creater -> Source Font에 원하는 폰트 추가 -> Generate Font Atlas -> Svae as ..
   ---
한글 폰트 깨짐 문제 
![](https://velog.velcdn.com/images/jihyun418/post/b328b04f-1fa0-4502-9672-71241a410c39/image.png)
해결 : 폰트 에셋에서 Atlas Population Mode 를 Dynamic으로 변경
![](https://velog.velcdn.com/images/jihyun418/post/bd098910-72bc-4008-8cc8-dfaa8b117400/image.png)

4. 글자 꾸미기
   - Color Gradient를 체크한 후 Color Mode를 Vertical Gradient로 설정해서 그라데이션 효과를 줄 수 있다.
   - 텍스트의 인스펙터를 내리면 글자의 Face, Outline, Urderlay(그림자), Lighting, Glow를 추가할 수 있다 

간단하게 글자도 추가해주었다 나중에 다시 제대로 글자 모양이나 질문을 변경할 예정..!
![](https://velog.velcdn.com/images/jihyun418/post/ae00ff69-b090-4873-a8bd-30107f8d3759/image.png)
