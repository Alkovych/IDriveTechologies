using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LangSystem : MonoBehaviour {

    public Image languageButtonImage;
    public Sprite[] flags;
    private string[] langArray = {"pl_PL","en_EN" };

    private string json;
    public static Lang lang = new Lang(); // Для доступа ко всем классам используем статику
    private int langIndex = 1;

    void Awake()
    {

        if (!PlayerPrefs.HasKey("Language")) // Проверка системы на язык
        {
            if (Application.systemLanguage == SystemLanguage.Polish)
            {
                PlayerPrefs.SetString("Language", "pl_PL");

            }
            else
            {
                PlayerPrefs.SetString("Language", "en_EN");
            }
        }
        LangLoad();
    }

    private void Start()
    {
        for (int i = 0; i <langArray.Length; i++)
        {
            if (PlayerPrefs.GetString("Language") == langArray[i])
            {
                langIndex = i + 1;
                languageButtonImage.sprite = flags[i];
                break;
            }
        }
    }


    void LangLoad() // Загрузка данных с файла
    {
        json = File.ReadAllText(Application.streamingAssetsPath + "/Languages/" + PlayerPrefs.GetString("Language") + ".json");

        lang = JsonUtility.FromJson<Lang>(json);
        print(lang.questions[0]);
    }

    public void SwithButton()
    {
        if (langIndex != langArray.Length)
        {
            langIndex++;
        }

        else
        {
            langIndex = 1;
        }

        PlayerPrefs.SetString("Language", langArray[langIndex - 1]);
        languageButtonImage.sprite = flags[langIndex - 1];
        LangLoad();
    }

}


public class Lang
{
    public string[] questions = new string[2];
}
