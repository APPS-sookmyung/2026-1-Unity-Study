# 퀴즈 마스터 1주차

## 게임 디자인

### 게임 컨셉

- 퀴즈 게임
- 단일 정답
- 각 질문에 제한 시간 설정
- UI 특화 게임 플레이

### 게임 화면 구성

- 질문 텍스트 -> 답안 선택 후 확인 문구
- 답안 버튼들 -> 답안 선택 후 정답 강조
- 스코어 텍스트
- 타이머 이미지
- 진척률 바
- 종료 화면: 점수 안내, 재시작 버튼

### 게임 메커니즘

- 모든 질문을 저장하고 불러올 수 있는 메커니즘
- 답안을 선택할 수 있는 버튼
- 플레이어에게 압박을 주기 위한 타이머
- 남은 질문을 파악할 수 있는 진척률 바
- 플레이어가 얼마나 잘하고 있는 지 확인할 수 있는 점수
- 퀴즈가 끝난 뒤 재시작할 수 있는 기능

### 정리

- 플레이어 경험: 지식 (좋은 경험)
- 핵심 기능: 지식 테스트
- 게임 루프: 주어진 주제에 대한 일정한 수의 질문을 제한시간 내에 답변하도록 함

---

## UI 캔버스

### UI 캔버스

- UI = User Interface
- 텍스트, 버튼, 슬라이더, 메뉴 등을 포함
- 게임 모드가 아닌 유저가 상호작용할 수 있는 모든 것
- UI 요소는 캔버스 내에 존재
- 캔버스는 보통 Screen Space에 존재하며 게임 월드와 분리되어 있음
- 스크린 스페이스는 월드 스페이스 가장 위에 오버레이 됨
- 복수 캔버스를 가질 수 있음

### 캔버스 생성

- `UI(Canvas)` > `Canvas`
- 캔버스 생성 시 `EventSystem`이 같이 생성됨
- Standard Transform Component 대신 **Rect Transform**을 가지고 있음 (UI 전용 계산 방식 사용)

### 이미지 생성

- `UI(Canvas)` > `Image` 생성: 캔버스는 스크린 스페이스에 존재하기 때문에 게임 뷰에서 스프라이트가 보임
- Anchors, Pivot을 직접 수정하기 보다는 Anchor Presets를 수정하는 걸 추천 (정렬)
  ![](https://velog.velcdn.com/images/lyj5721/post/33fd9617-df66-4b6a-959e-8489dc112171/image.png)
- 해상도는 FULL HD로 설정

---

## 텍스트 메쉬 프로

- 리소스 임포트: `Window > TextMeshPro > Import TMP Essential Resources > Import`
- 폰트 에셋 생성: `Window > TextMeshPro > Font Asset Creator`

#### Text vs TextMeshPro

단순한 Legacy Text보다 훨씬 강력한 기능을 제공하는 UI 텍스트 시스템

- **품질**: 비트맵 방식이 아닌 **SDF**(Signed Distance Field) 방식을 사용해 확대해도 글자가 깨지지 않음
- **커스텀**: 외곽선, 그림자, 그라데이션 등 다양한 효과를 쉽게 적용 가능

![](https://velog.velcdn.com/images/lyj5721/post/a45b5862-811d-4e62-8d0a-8bf28db0b5ab/image.png)
