using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Question : MonoBehaviour
{
    [SerializeField] Manager manager;
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] ReferenceLink referenceLink;


    public QuestionData currentQuestionData;

    public void NewQuestion()
    {
        List<string> name = manager.questionsNotAsked.Keys.ToList();
        if(name.Count == 0)
        {
            manager.popups.NoCategoriesSelectedPopup();
            return;
        }
        string rand = name[Random.Range(0, name.Count)];
        if(manager.questionsNotAsked[rand].Count == 0)
        {
            manager.popups.NoMoreQuestionsInCategories();
            return;
        }
        int rand2 = Random.Range(0, manager.questionsNotAsked[rand].Count);
        currentQuestionData = manager.questionsNotAsked[rand][rand2];
        question.text = currentQuestionData.question;
        referenceLink.SetupLink(currentQuestionData.reference);

        //use that question up

    }




}