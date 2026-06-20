# 57. 텍스트 메쉬 프로 UGUI

질문 데이터를 저장하는 Scriptable Object가 준비되었으므로, 이제 이를 UI(Canvas) 에 연결
 
  --- 
### 1. QuizCanvas 스크립트 생성
 - 새로운 스크립트 QuizCanvas를 생성
 -  이 스크립트는 퀴즈 진행에 필요한 대부분의 로직을 담당
 - 관련 스크립트를 별도 폴더로 정리하여 프로젝트 구조를 깔끔하게 유지
 
 ---
### 2. Quiz 스크립트 이동
   현재 작업 중인 Quiz.cs 파일을 Scripts 폴더로 이동 후 Quiz.cs를 열어 작업을 진행
   
   ---
### 3. Scriptable Object의 질문을 UI에 표시하기
#### (1) QuestionSO 참조 변수 만들기

Scriptable Object에 저장된 질문 데이터를 가져오기 위해 변수를 선언

```cs 
[SerializeField] QuestionSO question;
```
- QuestionSO 타입의 Scriptable Object를 참조
- Inspector에서 질문 데이터를 연결할 수 있음

#### (2) TextMesh Pro 네임스페이스 추가

UI 텍스트를 사용하기 위한 코드 추가

``` cs
using TMPro;
[SerializeField] TextMeshProUGUI questionText;
```
> **TextMesh Pro 종류**
TextMeshPro : 게임 월드(씬) 안에 존재하는 텍스트에 사용
TextMeshProUGUI : Canvas 기반 UI 텍스트에 사용


---
### 4. 코드구현
```cs
using UnityEngine;
using TMPro;
public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    void Start()
    {
        questionText.text = question.GetQuestion();
    }
}

```
| 변수             | 역할                            |
| -------------- | ----------------------------- |
| `questionText` | Canvas에 있는 질문 텍스트 UI          |
| `question`     | Scriptable Object에 저장된 질문 데이터 |
---

![](https://velog.velcdn.com/images/jihyun418/post/00df9cef-4c0f-45b6-a836-fb818d2c1ad3/image.png)

+ 한글폰트가 깨져서 다른 폰트를 추가해서 사용해주었다.

---
# 58. 루프(Loop)

### 답안 텍스트 버튼 연결

### 1. 버튼을 저장할 변수 생성

- 답안 버튼의 텍스트와 이미지 등의 컴포넌트를 변경할 예정이므로, 버튼을 `GameObject` 타입으로 선언
- 답안이 4개이므로 배열(Array) 형태로 선언

```csharp
[SerializeField] GameObject[] answerButtons;
```

> 생성된 리스트에 버튼을 하나씩 드래그하여 넣는 것보다 더 빠른 방법
* Inspector 우측 상단의 **자물쇠(Lock)** 아이콘을 클릭
* Hierarchy에서 버튼 오브젝트를 선택해도 Inspector 내용 변경X
* 원하는 버튼 오브젝트들을 배열 슬롯에 차례대로 드래그하여 추가

---

### 2. 버튼 텍스트 변경하기

- 버튼의 텍스트는 버튼 GameObject의 **자식 오브젝트**로 존재![](https://velog.velcdn.com/images/jihyun418/post/5b306513-3d3e-4101-a80d-5578ed1f86ae/image.png)

따라서 루트 오브젝트에서 컴포넌트를 가져오는 것이 아니라, 자식 오브젝트에서 텍스트 컴포넌트를 찾아와야 함.

이를 위해 `GetComponentsInChildren<T>()` 메서드를 사용!

---

### 3. 루프(Loop)란?

루프는 **특정 조건이 만족될 때까지 같은 작업을 반복 실행하는 구조**

* `for` 루프를 사용하여 모든 답안 버튼을 순회하며 텍스트 설정

---

### 4. 코드 구현

```csharp
public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons; // 답안 버튼 저장 변수

    void Start()
    {
        // 질문 표시
        questionText.text = question.GetQuestion();

        // 모든 답안 버튼 순회
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText =
                answerButtons[i].GetComponentsInChildren<TextMeshProUGUI>()[0];

            buttonText.text = question.GetAnswer(i);
        }
    }
}
```

---


### 자식 컴포넌트 가져오기

```csharp
answerButtons[i].GetComponentsInChildren<TextMeshProUGUI>()[0];
```

1. `answerButtons[i]`

   * 현재 순서의 버튼 가져오기

2. `GetComponentsInChildren<TextMeshProUGUI>()`

   * 버튼 자신과 자식 오브젝트에서 모든 TextMeshProUGUI 컴포넌트 검색

3. `[0]`

   * 검색된 첫 번째 TextMeshProUGUI 컴포넌트 선택

---




![](https://velog.velcdn.com/images/jihyun418/post/648e044f-9b76-4e6b-bd2f-436752bffdf0/image.png)

---
# 59. 스와핑 스프라이트

플레이어가 답변 버튼을 클릭했을 때, 선택 결과에 따라 **퀴즈 텍스트와 버튼 스프라이트가 변경** 



---

### 1. 변수 추가하기

정답 인덱스와 버튼 스프라이트를 저장할 변수를 추가

```csharp
int correctAnswerIndex; // 정답 인덱스

[SerializeField] Sprite defaultAnswerSprite; // 기본 버튼 이미지
[SerializeField] Sprite correctAnswerSprite; // 정답 선택된 이미지
```


---

### 2. 버튼 클릭 메서드 만들기

버튼을 눌렀을 때 실행될 메서드를 작성

```csharp
public void OnAnswerSelected(int index)
{
    Image buttonImage;

    if (index == question.GetCorrectAnswerIndex()) // 정답 버튼 클릭
    {
        questionText.text = "정답!";

        buttonImage = answerButtons[index].GetComponent<Image>();
        buttonImage.sprite = correctAnswerSprite;
    }
    else // 틀린 답을 클릭 -> 정답 이미지 표시해줌
    {
        correctAnswerIndex = question.GetCorrectAnswerIndex();

        string correctAnswer = question.GetAnswer(correctAnswerIndex);
        questionText.text = "틀렸습니다! 정답은\n" + correctAnswer + "입니다.";

        buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
        buttonImage.sprite = correctAnswerSprite;
    }
}
```

정답을 선택한 경우에는 선택한 버튼의 이미지를 정답 스프라이트로 바꾸고,
오답을 선택한 경우에는 정답을 텍스트로 알려준 뒤 실제 정답 버튼의 이미지를 변경한다.

---

### 3. Button 컴포넌트에 메서드 연결하기

>Hierarchy에서 답변 버튼을 선택한 뒤, Button 컴포넌트의 **On Click()** 항목 설정
1. `On Click()` 아래의 `+` 버튼을 누른다.
2. QuizScript가 붙어 있는 오브젝트(QuizCanvas)를 드래그해서 넣는다.
3. 드롭다운에서 `Quiz → OnAnswerSelected(int)`를 선택한다.
4. 아래 숫자 입력 칸에 버튼 인덱스를 입력한다.
 ![](https://velog.velcdn.com/images/jihyun418/post/26033e9e-6dd1-4084-8355-13e617b69567/image.png)

---

### 4. 스프라이트 연결하기

Inspector에서 `Default Answer Sprite`와 `Correct Answer Sprite` 필드에 각각 사용할 버튼 이미지를 넣어준다.

이렇게 설정하면 플레이어가 답을 선택했을 때 정답 여부에 따라 텍스트와 버튼 이미지가 함께 변경된다.



![](https://velog.velcdn.com/images/jihyun418/post/3dbe1856-2e7c-442f-881e-e0c39ab19bdc/image.png)


![](https://velog.velcdn.com/images/jihyun418/post/94fa0c50-9c7f-440f-a862-393015da7699/image.png)

---

# 60. 버튼 상태 제어하기

이전 단계에서 답변 버튼을 클릭했을 때 정답인지 오답인지 확인하고 정답 버튼의 스프라이트를 변경하도록 만들었지만 답을 선택한 뒤에도 다른 버튼을 계속 클릭할 수 있어서 결과를 임의로 바꿀 수 있는 오류가 있다.

이를 막기 위해 답변을 선택한 순간 모든 버튼을 비활성화하고 새로운 문제가 나올 때 다시 버튼을 활성화 되도록 해줄 것이다.

---

### 1. 코드 구조 정리하기

먼저 `Start()` 안에 있던 질문 출력 코드를 `DisplayQuestion()`이라는 별도의 메서드로 분리한다.

```csharp
void Start()
{
    DisplayQuestion();
}

void DisplayQuestion()
{
    questionText.text = question.GetQuestion();

    for (int i = 0; i < answerButtons.Length; i++)
    {
        TextMeshProUGUI buttonText = answerButtons[i].GetComponentsInChildren<TextMeshProUGUI>()[0];
        buttonText.text = question.GetAnswer(i);
    }
}
```

분리하여 질문을 화면에 표시하는 기능을 필요할 때마다 다시 사용할 수 있도록 해줌

---

### 2. 게임 흐름


```text
새로운 질문 표시
↓
모든 답변 버튼 활성화
↓
플레이어가 답변 선택
↓
모든 답변 버튼 비활성화
↓
다음 질문에서 다시 반복
```

---

### 3. 버튼 활성화 / 비활성화 메서드 만들기

버튼의 `interactable` 값을 활성화하면 버튼을 클릭할 수 있고 비활성화하면 클릭할 수 없다.

```csharp
void SetButtonState(bool state)
{
    for (int i = 0; i < answerButtons.Length; i++)
    {
        Button button = answerButtons[i].GetComponent<Button>();
        button.interactable = state;
    }
}
```

`state`가 `true`이면 버튼을 클릭할 수 있고,
`false`이면 버튼이 비활성화되어 더 이상 클릭할 수 없다.

---

### 4. 답변 선택 후 버튼 끄기

답변을 선택한 뒤에는 모든 버튼을 비활성화한다.

```csharp
public void OnAnswerSelected(int index)
{
    ... // 버튼 클릭시 정답, 오답 나타내는 코드
    SetButtonState(false); // 버튼 비활성화
}
```

`SetButtonState(false)`를 마지막에 호출하면, 정답이나 오답을 선택한 후 모든 버튼이 비활성화 시킴

---

### 5. 다음 문제를 가져올 때 버튼 다시 켜기

새로운 문제가 나올 때는 버튼을 다시 활성화한 뒤 질문 표시

```csharp
void GetNextQuestion()
{
    SetButtonState(true); // 버튼 활성화
    DisplayQuestion(); // 새 질문 표시
}
```

그리고 `Start()`에서는 `DisplayQuestion()` 대신 `GetNextQuestion()`을 호출

```csharp
void Start()
{
    GetNextQuestion();
}
```

---

### 6. 버튼 이미지 초기화

이전 문제에서 정답 버튼의 이미지가 바뀌었기 때문에 새로운 문제가 나올 때 버튼 이미지를 기본 이미지로 다시 되돌려야 한다

```csharp
void SetDefaultButtonSprites() //모든 답변 버튼의 이미지를 기본 스프라이트로 되돌리는 메서드
{
    for (int i = 0; i < answerButtons.Length; i++)
    {
        Image buttonImage = answerButtons[i].GetComponent<Image>();
        buttonImage.sprite = defaultAnswerSprite;
    }
}
```




`GetNextQuestion()` 안에서 버튼 활성화, 이미지 초기화, 질문 표시를 한 번에 처리한다.

```csharp
void Start()
{
    GetNextQuestion();
}

void GetNextQuestion()
{
    SetButtonState(true); // 버튼 활성화
    SetDefaultButtonSprites(); //이미지 초기화
    DisplayQuestion(); // 질문 표시
}
```

이렇게 하면 새로운 문제가 시작될 때마다 버튼은 다시 클릭 가능해지고 버튼 이미지도 기본 상태로 초기화된다.

---





