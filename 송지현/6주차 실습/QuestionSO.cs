using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)] // 인스펙터 안의 텍스트 상자의 크기를 지정하고 조정할 수 있돌고 해줌, 2줄이 최소 6줄이 최대
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;
    public string GetQuestion()
    {
        return question;
    }
    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
    public string GetAnswer(int index)
    {
        return answers[index];
    }
}
