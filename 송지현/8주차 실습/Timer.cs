using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    
    [SerializeField] float timeToCompleteQuestion = 30f; // 문제당 주어지는 시간
    [SerializeField] float timeToShowCorrecxtAnswer = 10f; // 정답 보여주는 시간
    float timerValue;//문제의 남은 시간 파악을 위한 변수
    public float fillFraction;
    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion = true;
    
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime; 

        if (isAnsweringQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion; 
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrecxtAnswer;    
            }
            
        }
        else
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrecxtAnswer; 
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;    
                loadNextQuestion = true;
            }
            
        }

        Debug.Log(isAnsweringQuestion + ": "+timerValue + "="+ fillFraction);
    }
}
