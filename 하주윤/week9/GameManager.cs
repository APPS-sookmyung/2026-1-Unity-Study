using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    [SerializeField] GameObject quizCanvas;
    [SerializeField] GameObject winCanvas;
    Quiz quiz; 
    EndScreen endScreen;
    
    void Awake() 
    {
        quiz = FindFirstObjectByType<Quiz>();
        endScreen = FindFirstObjectByType<EndScreen>();
    }

    void Start()
    {
        quizCanvas.SetActive(true);
        winCanvas.SetActive(false);
    }

    void Update()
    {
        if (quiz.isComplete)
        {
            quizCanvas.SetActive(false);
            winCanvas.SetActive(true);
            endScreen.ShowFinalScore();
        }
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}