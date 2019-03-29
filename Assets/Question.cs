using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Question : MonoBehaviour
{
    [SerializeField] FileReader reader;
    [SerializeField] TextMeshProUGUI question;

    public void NewQuestion()
    {
        int rand = Random.Range(0, reader.questions.Count);
        question.text = reader.questions[rand];

        //use that question up
    }
}