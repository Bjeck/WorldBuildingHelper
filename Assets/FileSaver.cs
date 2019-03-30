using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class FileSaver : MonoBehaviour
{
    [SerializeField] Manager manager;

    public List<QuestionAnswerPair> pairs = new List<QuestionAnswerPair>();

    public void SaveFile()
    {
        string allClearText = "";

        foreach(QuestionAnswerPair pair in manager.SaveData.questionAnswers)
        {
            string lineDivider = "\n\n" + "----------" + "\n\n";
            string fullText = "Q: " + pair.question.id + " (" + pair.question.category + ") \n" + pair.question.question + "\n\n" + "A: \n" + pair.answer;

            allClearText += lineDivider + fullText;
        }
        
        File.WriteAllText(Application.dataPath + "/Files/answer.txt", allClearText);

        string json = JsonUtility.ToJson(manager.SaveData);
        File.WriteAllText(Application.dataPath + "/Files/answer.json", json);
    }

    public void ClearFile()
    {
        File.WriteAllText(Application.dataPath + "/Files/answer.txt", string.Empty);
    }
}


//JSON TYPES

[System.Serializable]
public class QuestionAnswerData
{
    public List<QuestionAnswerPair> questionAnswers = new List<QuestionAnswerPair>();
}

[System.Serializable]
public class QuestionAnswerPair
{
    public QuestionData question;
    public string answer;
    
    public QuestionAnswerPair(QuestionData q, string a)
    {
        question = q;
        answer = a;
    }
    public QuestionAnswerPair() { }
}

[System.Serializable]
public class QuestionData
{
    public string question;
    public string id;
    public string category;
    public string reference;

    public QuestionData(string q, string i, string cat, string refs)
    {
        question = q;
        id = i;
        category = cat;
        reference = refs;
    }

    public QuestionData() { }
}