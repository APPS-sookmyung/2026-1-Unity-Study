using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    Quiz quiz; //퀴즈 스크립트 접근
    EndScreen endScreen; //

    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endScreen =FindObjectOfType<EndScreen>();
    }

    void Start()
    {

        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if (quiz.isComplete)
        {
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.ShowFinalScore(); // 최종점수 멘트
        }
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
