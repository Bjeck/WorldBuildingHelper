using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

public class FileReader : MonoBehaviour
{
    public Dictionary<string, List<string>> questions = new Dictionary<string, List<string>>();

	// Use this for initialization
	void Start ()
    {
        Load(Application.dataPath + "/questions_raw.txt");
	}
	

    private bool Load(string fileName)
    {
        string currentlist = "";

        string line;
        line = "";
        StreamReader theReader = new StreamReader(fileName, Encoding.Default);
        using (theReader)
        {
            // While there's lines left in the text file, do this:
            while (line != null)
            {
                //print("reading line");
                line = theReader.ReadLine();

                if (line != null)
                {

                    print("ENTRY: " + line);
                    //if(line.Length > 4)
                    //{
                        line = line.Trim('\t');
                    //}
                    if (line.StartsWith("#"))
                    {
                        line = line.Remove(0, 1);
                        if (!questions.ContainsKey(line))
                        {
                            questions.Add(line, new List<string>());
                        }
                        currentlist = line;
                    }
                    else
                    {
                        questions[currentlist].Add(line);
                    }

                }
            }
            //
            //while(line != null);
            // Done reading, close the reader and return true to broadcast success  
            Debug.Log(questions.Count);
            theReader.Close();
            return true;
        }
        // If anything broke in the try block, we throw an exception with information
        // on what didn't work

    }
}
