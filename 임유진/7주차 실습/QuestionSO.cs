using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)] // controll the size of the text area in the inspector
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;

    public string GetQuestion()
    {
        return question;
    }

    public string[] GetAnswers()
    {
        return answers;
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
}
