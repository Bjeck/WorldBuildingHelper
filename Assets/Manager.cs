using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/// <summary>
///  TO DO
/// 
/// DONE - track which questions you've already answered 
/// DONE     - save this to a file as well, for progress.
/// DONE - don't ask about the tracked questions again.
/// DONE - skip question button (that also saves that this question was chosen to not be answered)
/// - fallback when there are no more questions left
/// 
/// DONE - load a new question immediately so we don't have to press and create empty data.
/// - better writing tool? (than built-in input field?)
/// - clear text when pressing new question.
/// - some writing incentive? (timer? wordcount limit? other?)
/// - 
/// - better presentation.
/// - new font
/// 
/// - web integration for saving and downloading of files!
/// - proper referencing of questions!
/// 
/// - simple ai idea: When they answer a question, a weighing of the randomness of the next question category goes up for that category.
///                     maybe increases weighing more if the answer is longer????
/// 
/// </summary>





public class Manager : MonoBehaviour
{
    [SerializeField] FileReader reader;
    [SerializeField] Categories categories;
    [SerializeField] Question question;
    [SerializeField] TMP_InputField answer;

    public Popups popups;

    public QuestionAnswerData SaveData = null;

    public Dictionary<string, List<QuestionData>> questionsNotAsked = new Dictionary<string, List<QuestionData>>();

    // Start is called before the first frame update
    void Start()
    {
        categories.gameObject.SetActive(false);
        LoadStartingQuestions();
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

        questionsNotAsked.Clear();

        for (int i = 0; i < cats.Count; i++)
        {
            List<QuestionData> list = reader.questions[cats[i]];
            list.RemoveAll(x => SaveData.questionAnswers.Exists(y => y.question.id == x.id)); //removes all with an id already present in save data.
            questionsNotAsked.Add(cats[i], reader.questions[cats[i]]);
        }

        question.NewQuestion();
    }

    public void LoadStartingQuestions()
    {
        questionsNotAsked = new Dictionary<string, List<QuestionData>>();

        foreach(KeyValuePair<string, List<QuestionData>> kvp in reader.questions)
        {
            questionsNotAsked.Add(kvp.Key, kvp.Value);
        }

        if(SaveData != null)
        {
            for (int i = 0; i < SaveData.questionAnswers.Count; i++)
            {
                questionsNotAsked[SaveData.questionAnswers[i].question.category].RemoveAll(x => x.id == SaveData.questionAnswers[i].question.id);
            }
        }

        question.NewQuestion();
    }

    public void SaveQuestion(string customAnswer = null)
    {
        QuestionAnswerPair pair = new QuestionAnswerPair(question.currentQuestionData, string.IsNullOrEmpty(customAnswer) ? answer.text : customAnswer);
        SaveData.questionAnswers.Add(pair);

        questionsNotAsked[question.currentQuestionData.category].Remove(question.currentQuestionData);
    }

    public void SkipAndRemoveQuestionFromPool()
    {
        SaveQuestion("[SKIPPED]");
    }





}
