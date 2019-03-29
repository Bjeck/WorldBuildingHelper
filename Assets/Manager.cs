using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  TO DO
/// 
/// - track which questions you've already answered 
///     - save this to a file as well, for progress.
/// - skip question button (that also saves that this question was chosen to not be answered)
/// 
/// - better writing tool? (than built-in input field?)
/// - some writing incentive? (timer? wordcount limit? other?)
/// - 
/// - 
/// - web integration for saving and downloading of files!
/// </summary>





public class Manager : MonoBehaviour
{
    [SerializeField] FileReader reader;
    [SerializeField] Categories categories;
    [SerializeField] Question question;

    public Dictionary<string, List<string>> currentQuestions = new Dictionary<string, List<string>>();


    // Start is called before the first frame update
    void Start()
    {
        categories.gameObject.SetActive(false);

    }

    public void OpenCategoryMenu()
    {
        if(reader.questions.Count > 0)
        {
            categories.gameObject.SetActive(true);
            categories.SetupCategoryField(reader.questions);
        }
    }


    public void GetCategories()
    {
        List<string> cats = categories.DefineCategories();

        currentQuestions.Clear();

        for (int i = 0; i < cats.Count; i++)
        {
            currentQuestions.Add(cats[i], reader.questions[cats[i]]);
        }

    }




}
