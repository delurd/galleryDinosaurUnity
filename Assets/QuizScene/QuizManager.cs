using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuizManager : MonoBehaviour
{
    public GameObject kuisPanel;
    public List<QuestionAndAnswer> QnA;
    public GameObject[] option;
    public int currentQuestion;
    public Text QuestionTxt;

    public int answer = 2;
    // Start is called before the first frame update
    void Start()
    {
        answer = 2;

        generateQuestion();
    }

    public void correct()
    {
        
        QnA.RemoveAt(currentQuestion);

        if (QnA.Count > 0)
        {
            generateQuestion();
        }
        else
        {
            kuisPanel.SetActive(false);
            Debug.Log("End Question");
        }
    }

    void SetAnswers()
    {
        for (int i = 0; i < option.Length; i++)
        {
            option[i].GetComponent<AnswerScript>().isCorrect = false;
            option[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                option[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
