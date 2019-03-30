using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class Categories : MonoBehaviour
{
    [SerializeField] GameObject categoryPrefab;
    [SerializeField] Transform scrollContent;

    [SerializeField] List<GameObject> categories;

    public void SetupCategoryField(Dictionary<string, List<QuestionData>> questions)
    {
        List<string> cats = questions.Keys.ToList();
        for (int i = 0; i < cats.Count; i++)
        {
            GameObject g = Instantiate(categoryPrefab, scrollContent);
            g.GetComponentInChildren<TextMeshProUGUI>().text = cats[i];
            categories.Add(g);
        }
    }

    public void RemoveCategories()
    {
        for (int i = categories.Count - 1; i >= 0; i--)
        {
            Destroy(categories[i]);
        }
        categories.Clear();
        gameObject.SetActive(false);
    }

    public List<string> DefineCategories()
    {
        List<string> cats = new List<string>();
        foreach(GameObject g in categories)
        {
            bool isOn = g.GetComponentInChildren<Toggle>().isOn;
            if (isOn)
            {
                cats.Add(g.GetComponentInChildren<TextMeshProUGUI>().text);
            }
        }

        return cats;
    }

    public void SelectAll()
    {
        foreach (GameObject g in categories)
        {
            g.GetComponentInChildren<Toggle>().isOn = true;
        }
    }

    public void SelectNone()
    {
        foreach (GameObject g in categories)
        {
            g.GetComponentInChildren<Toggle>().isOn = false;
        }
    }


}
