using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public QuestionList[] questions;
    public Text questionText;
    public Text[] answersText;
    public Button[] answerButtons = new Button[4];

    public GameObject QuestionsAndAnswersPanel;
    public GameObject MainPanel;
    public GameObject ConfirmationPanel;

    List<object> qList;
    QuestionList currentQuestion;

    int randomQuestion;


    public void OnClickPlay()// Method for the Questions
    {
        qList = new List<object>(questions);//Присвоение всех вопросов один раз

        QuestionsGenerate();

        if (!QuestionsAndAnswersPanel.GetComponent<Animator>().enabled)
        {
            QuestionsAndAnswersPanel.GetComponent<Animator>().enabled = true;
            MainPanel.gameObject.SetActive(true);
            QuestionsAndAnswersPanel.gameObject.SetActive(true);
            ConfirmationPanel.gameObject.SetActive(false);
        }
        else
        {
            ConfirmationPanel.gameObject.SetActive(true);
            MainPanel.gameObject.SetActive(true);
            QuestionsAndAnswersPanel.gameObject.SetActive(true);
            QuestionsAndAnswersPanel.GetComponent<Animator>().SetTrigger("In");

        }

    }
    void QuestionsGenerate()
    {
        if (qList.Count > 0)
        {
            randomQuestion = Random.Range(0, qList.Count);

            currentQuestion = qList[randomQuestion] as QuestionList;
            questionText.text = currentQuestion.question;

            List<string> answers = new List<string>(currentQuestion.answers);// Список для случайного ответа в кнопке. Правильный ответ Серый указывай в индексе 0

            for (int i = 0; i < currentQuestion.answers.Length; i++)
            {
                int random = Random.Range(0, answers.Count);
                answersText[i].text = answers[random];
                answers.RemoveAt(random);
            }

            StartCoroutine(AnimationButtons());
        }
        else
        {
            print("Good Job=)");// Добавить панель)
        }
      
    }

    IEnumerator AnimationButtons()
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = false;
        }

        int a = 0;

        while (a > answerButtons.Length)
        {
            if (!answerButtons[a].gameObject.activeSelf)
            {
                answerButtons[a].gameObject.SetActive(true);
            }
            else
            {
                answerButtons[a].gameObject.GetComponent<Animator>().SetTrigger("In");
                a++;
                yield return new WaitForSeconds(0.5f);
            }
        }

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
        }

        yield break;

    }

    IEnumerator CheckedAnswers(bool check)
    {

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = false;
        }
        yield return new WaitForSeconds(0.5f);

        if (check)
        {

        }
        else
        {
               
        }

    }

    public void AnswersButtons(int index)
    {
        if (answersText[index].text.ToString() == currentQuestion.answers[0] )
        {
            StartCoroutine(CheckedAnswers(true));
        }
        else
        {
            StartCoroutine(CheckedAnswers(false));
        }
    }
}

[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[4];

}
