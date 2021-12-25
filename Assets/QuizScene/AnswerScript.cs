using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    

    public void Answer()
    {

        clearAnswer();
        GetComponent<Image>().color = Color.green;
        if (isCorrect)
        {
            quizManager.answer = 1;
            /*Debug.Log("Corect Answer");
            quizManager.correct();*/
        }
        else
        {
            quizManager.answer = 0;
            /*Debug.Log("Wrong Answer");*/
        }
    }

    public void clearAnswer()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            transform.parent.GetChild(i).GetComponent<Image>().color = Color.white;
        }
    }
    
}
