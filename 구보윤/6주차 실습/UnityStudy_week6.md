### #53 버튼 레이아웃

#### 1. Canvas에 Button 추가
QuizCanvas > Canvas컴포넌트의 SortOrder를 1로 변경

#### 2. 버튼 설정
Color Tint, Transition 설정
![](https://velog.velcdn.com/images/dong9rami/post/9c162dd2-6e00-4634-807b-bfc4ab057290/image.png)
#### 3. Button Image 설정
소스이미지, 테두리 설정
![](https://velog.velcdn.com/images/dong9rami/post/9d571012-4dd7-4436-b189-50485750313e/image.png)

![](https://velog.velcdn.com/images/dong9rami/post/f4efefa6-fadc-4af0-8c7f-655a75c9fd36/image.png)

![](https://velog.velcdn.com/images/dong9rami/post/5fd5c117-de25-485e-87da-03c54c60868c/image.png)

![](https://velog.velcdn.com/images/dong9rami/post/83f260e9-e2fc-457e-8af9-5285bcbb31cf/image.png)

### #54 스크립터블 오브젝트

#### 1. 폴더 정리
![](https://velog.velcdn.com/images/dong9rami/post/68f85e17-7ff9-44d3-a0a1-caec5b96965b/image.png)

#### 2. QuestionSO Script

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter new question text here";
}

```

![](https://velog.velcdn.com/images/dong9rami/post/878ecf54-cac3-4b06-9737-d72fc4a06260/image.png)

### #55 게터 메서드

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter new question text here";

    public string GetQuestion()
    {
        return question;
    }
}
```

### #56 배열

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;

    public string GetQuestion()
    {
        return question;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
}

```

![](https://velog.velcdn.com/images/dong9rami/post/832d8994-e358-41e0-b78f-639f620d4ca9/image.png)


