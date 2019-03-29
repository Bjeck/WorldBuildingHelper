using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

public class FileReader : MonoBehaviour
{

    public List<string> questions = new List<string>();

	// Use this for initialization
	void Start ()
    {
        Load(Application.dataPath + "/questions_raw.txt");
	}
	

    private bool Load(string fileName)
    {

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

                if (line != null && line.Substring(0, 1) != "#")
                {

                    print("ENTRY: " + line);
                    string q = line;
                    questions.Add(q);
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
