using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class FileSaver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] TMP_InputField answer;

    public List<QuestionAnswerPair> pairs = new List<QuestionAnswerPair>();

    public void SaveFile()
    {
        string lineDivider = "\n\n" + "----------" + "\n\n";
        string fullText = "Q: \n" + question.text + "\n\n" + "A: \n" + answer.text;

        QuestionAnswerPair qap = new QuestionAnswerPair(question.text, answer.text);
        pairs.Add(qap);

        File.AppendAllText(Application.dataPath + "/Files/answer.txt", lineDivider + fullText);
    }

    public void ClearFile()
    {
        File.WriteAllText(Application.dataPath + "/Files/answer.txt", string.Empty);
    }
}

public class QuestionAnswerPair
{
    public string question; //should probably contain a little metadata about the question so we can read the answer informedly?
    public string answer;
    
    public QuestionAnswerPair(string q, string a)
    {
        question = q;
        answer = a;
    }
    public QuestionAnswerPair() { }
}
