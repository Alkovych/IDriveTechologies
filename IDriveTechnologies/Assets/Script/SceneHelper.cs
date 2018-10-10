using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHelper : MonoBehaviour {

    public GameObject MainPanel;
    public GameObject ConfirmationPanle;
    public GameObject MessagePanel;
    public GameObject SettingsPanel;
    public GameObject PracticePanel;
    public GameObject CarPracticePanel;

    public void TestButtonClick()
    {
        ConfirmationPanle.gameObject.SetActive(true);
        ConfirmationPanle.GetComponent<Animator>().SetTrigger("Down");
    }

    public void BackButtonClickConfirmationPanel()
    {

        ConfirmationPanle.GetComponent<Animator>().SetTrigger("Up");
        ConfirmationPanle.gameObject.SetActive(false);
		
	}

    public void PracticeButtonClick()
    {

        PracticePanel.gameObject.SetActive(true);
        PracticePanel.GetComponent<Animator>().SetTrigger("PracticeGroupDown");

    }

    public void PracticeCarButtonClick()
    {

        CarPracticePanel.gameObject.SetActive(true);
        CarPracticePanel.GetComponent<Animator>().SetTrigger("PracticeCarPanelDown");

    }


    public void BackButtonCarPracticePanel()
    {
        CarPracticePanel.gameObject.SetActive(false);
    }

    public void BackButtonFromEmail()
    {
        MessagePanel.gameObject.SetActive(false);
    }

    public void BackButtonFromSettings()
    {
        SettingsPanel.gameObject.SetActive(false);
    }

    public void BackButtonPracticeGroup()
    {
        PracticePanel.gameObject.SetActive(false);
    }


    

    public void SettingsButton()
    {
        SettingsPanel.GetComponent<Animator>().SetTrigger("SettingsDown");
        SettingsPanel.gameObject.SetActive(true);
    }
}
