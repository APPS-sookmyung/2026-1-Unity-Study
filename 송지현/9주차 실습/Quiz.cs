using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;
public class Quiz : MonoBehaviour
{

    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly = true;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage; // UI 이미지
    Timer timer; // 타이머 접근을 위한 타이머 변수 

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI ScoreText;
    ScoreKeeper scoreKeeper;

    public bool isComplete; // 유저가 게임을 완료했는지에 대한 상태 저장

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;
    void Awake() 
    {
        timer= FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;

    }
    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {

             if(progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return; // 오류방지
            }
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
    public void OnAnswerSelected(int index) // 버튼 클릭시 발생하는 이벤트 
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);

        SetButtonState(false);
        timer.CancelTimer();

        ScoreText.text = "점수: " + scoreKeeper.CalculateScore()+ "%"; // 추가

       
    }

    void DisplayAnswer(int index)
    {
         Image buttonImage;
        if(index == currentQuestion.GetCorrectAnswerIndex()) // 정답을 맞춘 경우
        {
            questionText.text = "정답!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.IncrementCorretAnswers(); // 추가
        }
        else // 정답을 틀린 경우
        {
            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text = "틀렸습니다! 정답은\n "+ correctAnswer + "입니다.";
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    void GetNextQuestion() // 다음 질문 넘어가기
    {
        if(questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();   
            progressBar.value++; // 추가
            scoreKeeper.IncrementQuestionsSeen();
        }
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);    
        }
        
    }
    void DisplayQuestion() // 질문, 답변 텍스트 가져오기
    {
         questionText.text = currentQuestion.GetQuestion();


        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonTexts = answerButtons[i].GetComponentsInChildren<TextMeshProUGUI>()[0];
            buttonTexts.text = currentQuestion.GetAnswer(i);
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
