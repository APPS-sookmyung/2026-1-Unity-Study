## 53. 버튼 레이아웃

### 1. 캔버스에 버튼 추가하기
   - 버튼은 QuizCanvas 안에 추가
``QuizCanvas 우클릭 -> UI 선택 -> Button - TextMeshPro 선택``

   - ** 문제상황** : 버튼 생성되었지만 화면에서 안 보이는 경우
      - 원인 : 이는 QuizCanvas가 배경 캔버스와 같은 레이어 순서에 있기 때문
      - 해결법 :  QuizCanvas 선택 Canvas 컴포넌트의 Sort Order를 `0`에서 `1`로 변경
           이렇게 하면 퀴즈 캔버스가 배경보다 앞에 표시되어 버튼이 보인다

### 2. 버튼의 구성 
   - 생성된 버튼을 보면 자식 오브젝트로 TextMeshPro 텍스트가 들어 있음
        -  **Button 본체**: 클릭 영역과 배경 이미지 담당
        - **TextMeshPro 자식 요소**: 버튼 위에 표시되는 글자 담당
 - 버튼은 기본적으로 Image 컴포넌트와 Button 컴포넌트를 함께 가진다.

- **Button 컴포넌트 주요 옵션**
  - `Interactable` 
   버튼을 클릭할 수 있는지 설정하는 옵션(체크 해제 시 버튼이 비활성화되며 회색으로 표시됨)
  - `Color Tint` 관련 옵션
  버튼 상태에 따라 색상을 다르게 설정할 수 있다.
     - `Normal Color`: 기본 상태 색상
     - `Highlighted Color`: 마우스를 올렸을 때 색상
     - `Pressed Color`: 눌렀을 때 색상
     - `Disabled Color`: 비활성화 상태 색상
  - `On Click()`
  버튼을 클릭했을 때 실행할 기능을 연결하는 곳, 스크립트를 추가해 클릭 시 동작을 직접 제어할 수 있다.
  - `Transition`
  기본값은 Color Tint, 이번에는 None으로 변경(색상 변화 처리를 없애고, 이후 코드로 더 간단하게 제어하기 위함)

### 3. 버튼 이미지 적용하기

버튼의 Source Image에 원하는 이미지를 넣어 버튼 디자인을 변경

- 이미지 버튼 크기에 맞추기
   - 프로젝트 창에서 해당 스프라이트 선택 -> Sprite Editor 열기 -> Border 값 조정 (강의에서는 75로 설정)
   - 이렇게 하면 버튼의 모서리는 유지되고, 가운데 부분만 자연스럽게 늘어난다.

### 4. 여러 버튼을 세로로 배치하기

>빈 게임 오브젝트 생성 -> 이름을 AnswerButtonGroup으로 변경 -> 기존 버튼을 AnswerButtonGroup의 자식으로 이동 -> AnswerButtonGroup에 `Vertical Layout Group` 컴포넌트 추가

답변 버튼이 세로 목록 형태이므로 Vertical Layout Group을 사용한다.

또한 AnswerButtonGroup의 크기는
모든 버튼이 들어갈 수 있을 만큼 충분히 크게 조정한다.

- **Layout Group 종류**
  
  - `Horizontal Layout Group` : 자식 오브젝트를 가로 방향으로 정렬
  - `Vertical Layout Group` : 자식 오브젝트를 세로 방향으로 정렬
    - **Vertical Layout Group 주요 옵션**
      - `Padding` : 레이아웃 박스 바깥쪽 여백 설정
      - `pacing` : 자식 요소들 사이의 간격 설정
      - `hild Alignment` : 자식 요소들을 어느 위치에 정렬할지 설정   
      예: 위쪽, 가운데, 아래쪽 / 왼쪽, 중앙, 오른쪽
      - `Control Child Size` : 자식 요소의 가로·세로 크기를 레이아웃 그룹이 직접 제어하도록 설정 (체크하면 버튼들이 부모 영역에 맞게 일정하게 정렬)
   - `Grid Layout Group` : 자식 오브젝트를 격자 형태로 정렬

![](https://velog.velcdn.com/images/jihyun418/post/c86ffe68-fd88-47aa-9bb0-8f8535eddbcb/image.png)

---

## 54. 스크립터블 오브젝트

### 1. 시작 전 에셋 폴더 정리

먼저 프로젝트 폴더를 정리했다.

> **폰트 파일 정리하기**
TextMeshPro 관련 폴더 열기
.TTF 폰트 파일을 Fonts 폴더로 이동 / 생성된 폰트 에셋은 Resources > Fonts & Materials 폴더로 이동

### 2. 스크립터블 오브젝트란?

- **스크립터블 오브젝트(Scriptable Object)**
   - 게임에서 사용하는 데이터를 저장하는 전용 컨테이너
   - 일반적인 스크립트처럼 기능을 실행하는 것이 아닌 질문, 수치, 설정값 같은 데이터를 보관하는 역할

- **스크립터블 오브젝트의 장점**
  1) 코드 안에 직접 데이터를 작성하지 않고,별도의 에셋으로 저장해 관리할 수 있다.
  2) 같은 데이터를 여러 스크립트가 공유해 사용할 수 있어, 중복을 줄이고 메모리 관리에도 유리하다.
 3) MonoBehaviour와 달리 게임 오브젝트에 컴포넌트로 부착하지 않아도 된다.
 4) 프로젝트 창에서 하나의 에셋처럼 생성하고 수정할 수 있다.
 5) 스크립터블 오브젝트는 일종의 데이터 청사진 또는 템플릿처럼 사용할 수 있다.
> 예시)
RPG 게임의 공격력, 치명타 확률
카드 게임의 카드 이름, 설명, 능력치
아이템 정보
퀴즈 게임의 질문과 정답 데이터

이 프로젝트에서는 퀴즈 질문 데이터를 저장하는 용도로 사용한다.
### 3. QuestionSO 스크립트 생성
- **질문 데이터를 저장할 스크립트 생성**
`Scripts 폴더 우클릭` -> `Create > C# Script`-> 이름을 `QuestionSO`로 설정

- 스크립트를 열면 기본적으로 들어 있는 `Start()`, `Update()` 메서드는 삭제
   이유는  스크립터블 오브젝트에서는 필요하지 않고, Start와 Update는 주로 게임 오브젝트에 붙는 MonoBehaviour에서 사용되기 때문

- ** `MonoBehaviour` -> `ScriptableObject` 변경**
게임 오브젝트용 스크립트가 아니라 데이터 저장용 오브젝트이므로
```cs
public class QuestionSO : ScriptableObject 

```




- `[CreateAssetMenu()]` : Create 메뉴 안에 이 스크립터블 오브젝트를 생성할 수 있는 항목 추가
  - 각 옵션의 의미
     - menuName = "Quiz Question" : 프로젝트 창에서 우클릭했을 때 표시되는 메뉴 이름
     - fileName = "New Question" : 새 에셋을 만들었을 때 기본으로 붙는 파일명
![](https://velog.velcdn.com/images/jihyun418/post/b3d7ec7c-b6fa-4e52-887c-670ad0918fcb/image.png)

**최종코드**
```cs
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)] // 문자열 입력 칸의 최소 높이: 2줄, 최대 높이: 6줄
    [SerializeField] string question = "Enter new question text here";
}
```


---

## 55. Getter 메서드

Getter 메서드란?
- 클래스 내부의 private 변수 값을 외부에서 읽을 수 있게 해주는 메서드
  - private 변수는 외부에서 직접 접근할 수 없음
  - 게터 메서드를 사용하면 값을 안전하게 가져올 수 있음 
  - 변수의 내용은 보호하면서, 필요한 데이터만 전달 가능

```cs

    public string GetQuestion()
    {
        return question; //question 변수에 저장된 문자열을 반환
    }
```

---
## 56. 배열

각 질문에는 4개의 답변이 필요하다.
이를 각각 다른 변수로 만들기보다 배열을 사용하면 더 효율적으로 관리할 수 있다.

배열이란?
같은 자료형의 값을 여러 개 묶어서 저장하는 방식
```cs
int[] oddNumbers = { 1, 3, 5, 7, 9 };
```
- []는 배열을 의미
- 배열 안의 각 값은 요소라고 부름
- 각 요소는 인덱스 번호로 접근
- 인덱스는 0부터 시작 


```cs
    [SerializeField] string[] answers = new string[4]; //4개의 답변을 저장하기 위한 문자열 배열 선언
    [SerializeField] int correctAnswerIndex; // 정답 번호 저장할 변수 선언
    
    public int GetCorrectAnswerIndex() // 정답의 인덱스 번호 반환
    {
        return correctAnswerIndex;
    }
    public string GetAnswer(int index) // 전달받은 인덱스 위치의 답변을 반환
    {
        return answers[index];
    }
 ```
 ![](https://velog.velcdn.com/images/jihyun418/post/2f0c7955-a885-42cf-9ce5-7080d0daac19/image.png)
