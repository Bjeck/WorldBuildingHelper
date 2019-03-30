using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popups : MonoBehaviour
{
    public GameObject noCategoriesPopup;
    public GameObject noQuestionsPopup;


    public void NoCategoriesSelectedPopup()
    {
        noCategoriesPopup.SetActive(true);
    }

    public void NoMoreQuestionsInCategories()
    {
        noQuestionsPopup.SetActive(true);
    }


}
