using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReferenceLink : MonoBehaviour
{
    string url = "";
    [SerializeField] TextMeshProUGUI text;
    
    public void SetupLink(string link)
    {
        url = link;
        text.text = "Question from <color=#42B1EC>" + url + "</color>";
    }

    public void OpenLink()
    {
        Application.OpenURL(url);
    }
}
