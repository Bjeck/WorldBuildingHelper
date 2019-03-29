using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordCount : MonoBehaviour
{
    const int MIN_CHAR_COUNT = 250;

    [SerializeField] TMP_InputField input;
    [SerializeField] TextMeshProUGUI text;

	// Use this for initialization
	void Start () {
        input.onValueChanged.AddListener((s) => { UpdateWordCount(s); });
		
	}
	

    void UpdateWordCount(string s)
    {
        text.text = s.Length.ToString();
        if(s.Length < MIN_CHAR_COUNT)
        {
            text.color = Color.red;
        }
        else
        {
            text.color = Color.green;
        }
    }
}
