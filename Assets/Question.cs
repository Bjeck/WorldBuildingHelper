using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Question : MonoBehaviour
{
    [SerializeField] Manager manager;
    [SerializeField] TextMeshProUGUI question;

    public void NewQuestion()
    {
        List<string> name = manager.currentQuestions.Keys.ToList();
        string rand = name[Random.Range(0, name.Count)];
        int rand2 = Random.Range(0, manager.currentQuestions[rand].Count);
        question.text = manager.currentQuestions[rand][rand2];

        //use that question up
    }
}