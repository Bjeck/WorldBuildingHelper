using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

public class FileReader : MonoBehaviour
{
    public Dictionary<string, List<QuestionData>> questions = new Dictionary<string, List<QuestionData>>();

    [SerializeField] Manager manager;

    // Use this for initialization
    void Awake()
    {
        Load(Application.dataPath + "/questions_raw.txt");
        LoadAnsweredList();
    }


    private bool Load(string fileName)
    {
        string currentlist = "";

        int id = 0;

        string line;
        line = "";
        StreamReader theReader = new StreamReader(fileName, Encoding.Default);
        using (theReader)
        {
            while (line != null)
            {
                line = theReader.ReadLine();

                if (line != null)
                {

                    print("ENTRY: " + line);
                    line = line.Trim('\t');

                    if (line.StartsWith("#"))
                    {
                        line = line.Remove(0, 1);
                        if (!questions.ContainsKey(line))
                        {
                            questions.Add(line, new List<QuestionData>());
                        }
                        currentlist = line;
                    }
                    else
                    {
                        QuestionData data = new QuestionData(line,id.ToString(), currentlist,"");
                        questions[currentlist].Add(data);
                    }
                }

                id++;
            }
            Debug.Log(questions.Count);
            theReader.Close();
            return true;
        }
    }


    void LoadAnsweredList()
    {
        if(!File.Exists(Application.dataPath + "/Files/answer.json"))
        {
            return;
        }
        string jsonData = File.ReadAllText(Application.dataPath + "/Files/answer.json");
        if (string.IsNullOrEmpty(jsonData))
        {
            return;
        }
        QuestionAnswerData allData = JsonUtility.FromJson<QuestionAnswerData>(jsonData);

        if(allData != null)
        {
            manager.SaveData = allData;
        }
    }
}

