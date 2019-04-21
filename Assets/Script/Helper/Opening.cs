using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    public Text timeText;
    public GameObject leftPanel;
    public GameObject rightPanel;
    public GameObject buttons;
    public GameObject texts;



    private bool startPressed;

    private void Start()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsTags.BESTTIME))
        {
            timeText.text = PlayerPrefs.GetString(PlayerPrefsTags.BESTTIME);
        }
        else
        {
            timeText.text = "Else not";
        }
    }


    public void OnClickPlayGame()
    {
        STF.uiManager.endGame.SetActive(false);
        leftPanel.GetComponent<Animation>().Play("LeftPanel");
        rightPanel.GetComponent<Animation>().Play("RightPanel");
        buttons.GetComponent<Animation>().Play("ButtonsDown");
        texts.GetComponent<Animation>().Play("TextUp");

        startPressed = true;
    }

    private void Update()
    {
        if (startPressed && !leftPanel.GetComponent<Animation>().isPlaying)
        {
            STF.uiManager.InitGame();
            startPressed = false;
            
        }
    }


}
