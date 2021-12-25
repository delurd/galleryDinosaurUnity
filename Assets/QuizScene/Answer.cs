using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Answer : MonoBehaviour
{
    public AnswerScript AS;
    QuizManager quizManager;

    // Start is called before the first frame update
    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
    }

    public void Submit()
    {
        

        if (quizManager.answer == 1)
        {
            Debug.Log("Corect Answer");
            quizManager.correct();
           
        }
        if (quizManager.answer == 0)
        {
            Debug.Log("Wrong Answer");
            
        }
        if(quizManager.answer == 2)
        {
            Debug.Log("Select Answer !");
        }

        quizManager.answer = 2;

        int sibling = transform.GetSiblingIndex();

        GameObject answerScript = transform.parent.GetChild(sibling - 1).gameObject;
        for (int i = 0; i < answerScript.transform.childCount; i++)
        {
           answerScript.transform.GetChild(i).GetComponent<Image>().color = Color.white;
        }
        

    }
}
