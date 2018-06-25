using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHelper : MonoBehaviour {

    public GameObject MainPanel;
    public GameObject ConfirmationPanle;

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
}
