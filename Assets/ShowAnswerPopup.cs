using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowAnswerPopup : MonoBehaviour
{
    public TMP_InputField text;
    
    public void DisplayAnswer(string fullAnswer)
    {
        text.text = fullAnswer;
    }


    public void CopyToClipBoard()
    {
        GUIUtility.systemCopyBuffer = text.text;
    }


}
