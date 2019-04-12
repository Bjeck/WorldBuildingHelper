using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

//READ WRITE WEBGL: https://forum.unity.com/threads/webgl-read-write.336171/ Maybe or https://www.youtube.com/watch?v=4OZqY1Ukj8I or http://amalgamatelabs.com/Blog/4/data_persistence

public class FileReader : MonoBehaviour
{
    public List<TextAsset> questionSheets = new List<TextAsset>();

    public Dictionary<string, List<QuestionData>> questions = new Dictionary<string, List<QuestionData>>();

    [SerializeField] Manager manager;

    // Use this for initialization
    void Awake()
    {


        foreach(TextAsset ta in questionSheets)
        {
            TextAsset asset = Resources.Load<TextAsset>(ta.name);
            Read(asset.text, asset.name);
         //   Debug.Log("ASSSET " + asset);
          //  Load(Application.dataPath + "/Resources/" + ta.name + ".csv", ta.name);
        }

        LoadAnsweredList();
    }


    private void Read(string text, string refID)
    {
        string currentlist = "";

        int id = 0;

        string[] textInLines = text.Split('\n');

        foreach(string line in textInLines)
        {
            if (line != null)
            {
                string lineToRead = line;
                print("ENTRY: " + line);
                lineToRead = line.Trim('\t');

                string[] split = line.Split(new string[] { ",," }, System.StringSplitOptions.None);

                if (line.StartsWith("#"))
                {
                    lineToRead = line.Remove(0, 1);
                    if (!questions.ContainsKey(line))
                    {
                        questions.Add(split[0], new List<QuestionData>());
                    }
                    currentlist = split[0];
                }
                else
                {
                    QuestionData data = new QuestionData(split[0], id.ToString(), currentlist, split[1], refID);
                    questions[currentlist].Add(data);
                }
            }

            id++;
        }
    }


    //private bool Load(string fileName, string refID)
    //{
    //    string currentlist = "";

    //    int id = 0;

    //    string line;
    //    line = "";
    //    StreamReader theReader = new StreamReader(fileName, Encoding.Default);
    //    using (theReader)
    //    {
    //        while (line != null)
    //        {
    //            line = theReader.ReadLine();

    //            if (line != null)
    //            {

    //                print("ENTRY: " + line);
    //                line = line.Trim('\t');

    //                string[] split = line.Split(new string[] { ",," }, System.StringSplitOptions.None);

    //                if (line.StartsWith("#"))
    //                {
    //                    line = line.Remove(0, 1);
    //                    if (!questions.ContainsKey(line))
    //                    {
    //                        questions.Add(split[0], new List<QuestionData>());
    //                    }
    //                    currentlist = split[0];
    //                }
    //                else
    //                {
    //                    QuestionData data = new QuestionData(split[0],id.ToString(), currentlist, split[1], refID);
    //                    questions[currentlist].Add(data);
    //                }
    //            }

    //            id++;
    //        }

    //        theReader.Close();
    //        return true;
    //    }
    //}


    void LoadAnsweredList()
    {
#if !UNITY_WEBGL
        if (!File.Exists(Application.dataPath + "/Files/answer.json"))
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
#endif
    }
}

