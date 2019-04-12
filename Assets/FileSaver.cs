using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class FileSaver : MonoBehaviour
{
    [SerializeField] Manager manager;

    public List<QuestionAnswerPair> pairs = new List<QuestionAnswerPair>();


    public string CreateClearTextAnswer()
    {
        string allClearText = "";

        foreach (QuestionAnswerPair pair in manager.SaveData.questionAnswers)
        {
            string lineDivider = "\n\n" + "----------" + "\n\n";
            string fullText = "Q: " + pair.question.id + " (" + pair.question.category + ") \n" + pair.question.question + "\n\n" + "A: \n" + pair.answer;

            allClearText += lineDivider + fullText;
        }
        return allClearText;
    }

    public void SaveFile()
    {
#if !UNITY_WEBGL
        string allClearText = CreateClearTextAnswer();

        File.WriteAllText(Application.dataPath + "/Files/answer.txt", allClearText);

        string json = JsonUtility.ToJson(manager.SaveData);
        File.WriteAllText(Application.dataPath + "/Files/answer.json", json);
#endif
    }

    public void ClearFile()
    {
#if !UNITY_WEBGL
        File.WriteAllText(Application.dataPath + "/Files/answer.txt", string.Empty);
#endif
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
    public string refid;
    public string reference;

    public QuestionData(string q, string i, string cat, string refs, string refID)
    {
        question = q;
        id = i;
        category = cat;
        reference = refs;
        refid = refID;
    }

    public QuestionData() { }
}