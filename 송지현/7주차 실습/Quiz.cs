using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start() 
    {
       GetNextQuestion();

    }   
    public void OnAnswerSelected(int index) // 버튼 클릭시 발생하는 이벤트 

    {
        Image buttonImage;
        if(index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "정답!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "틀렸습니다! 정답은\n "+ correctAnswer + "입니다.";
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

        SetButtonState(false);
    }

    void GetNextQuestion() // 다음 질문 넘어가기
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }
    void DisplayQuestion() // 질문, 답변 텍스트 가져오기
    {
         questionText.text = question.GetQuestion();


        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonTexts = answerButtons[i].GetComponentsInChildren<TextMeshProUGUI>()[0];
            buttonTexts.text = question.GetAnswer(i);
        }
    }

    void SetButtonState(bool state) // 버튼을 원하는 상태로 변경
    {
        for(int i=0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites() // 이미지 초기화
    {
        for(int i=0; i< answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
