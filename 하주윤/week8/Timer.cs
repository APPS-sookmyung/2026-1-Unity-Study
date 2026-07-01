using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour 
{
    [SerializeField] float timeToCompleteQestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool loadNextQuestion;
    public bool isAnwerinQuestion;
    public float fillFraction;

    float timerValue;

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

        if (isAnwerinQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQestion;
            }
            else
            {
                isAnwerinQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
           if(timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnwerinQuestion = true;
                timerValue = timeToCompleteQestion;
                loadNextQuestion = true;
            }
        }

        Debug.Log(isAnwerinQuestion + ": " + timerValue + " = " + fillFraction);
    } 
}
