using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [HideInInspector]
    public float minutes;
    [HideInInspector]
    public float milliseconds;
    [HideInInspector]
    public float seconds;
    [SerializeField]
    private Text counterText;
    [SerializeField]
    public GameObject endGame;


    public Transform startPoint;

    [SerializeField]
    private Text yourTime;

    [HideInInspector]
    public bool game = true;

    private float timeSinceStartGame;


    [Header("OpenMenu")]
    public Text timeText;
    public GameObject leftPanel;
    public GameObject rightPanel;
    public GameObject buttons;
    public GameObject texts;

    public GameObject player;



    private void Start()
    {
        STF.NullReferences();
        game = false;
    }

    void Update()
    {

        if (game)
        {

            timeSinceStartGame += Time.deltaTime;

            minutes = (int)(timeSinceStartGame / 60f) % 60;
            milliseconds = (int)(timeSinceStartGame * 1000f) % 1000;
            seconds = (int)(timeSinceStartGame % 60f);
            counterText.text = minutes.ToString() + ":" + seconds.ToString() + ":" + milliseconds.ToString();
        }
    }

    public void EndGame()
    {
        
        endGame.SetActive(true);
        yourTime.text = counterText.text;
    }

    public void OnClickExitToMenu()
    {

        if (PlayerPrefs.HasKey(PlayerPrefsTags.BESTTIME))
        {
            timeText.text = PlayerPrefs.GetString(PlayerPrefsTags.BESTTIME);
        }
        else
        {
            timeText.text = "Else not";
        }

        player.SetActive(false);
        counterText.text = "";
        leftPanel.GetComponent<Animation>().Play("LeftPanelClose");
        rightPanel.GetComponent<Animation>().Play("RightpPanelClose");
        buttons.GetComponent<Animation>().Play("ButtonsUp");
        texts.GetComponent<Animation>().Play("TextDown");
        endGame.SetActive(false);

    }

    public void onClickRestartGame()
    {
        endGame.SetActive(false);
        InitGame();
    }


    public void OnExitGame()
    {
        Application.Quit();
    }


    public void SavePlayerTime()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsTags.BESTTIME))
        {

            string tmpTime = PlayerPrefs.GetString(PlayerPrefsTags.BESTTIME);

            var tmpTabTime = tmpTime.Split(':');

            int tmpMinutes = 9999;
            int tmpSeconds = 9999;
            int tmpMilliSeconds = 9999;

            try
            {
                tmpMinutes = int.Parse(tmpTabTime[0]);
                tmpSeconds = int.Parse(tmpTabTime[1]);
                tmpMilliSeconds = int.Parse(tmpTabTime[2]);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            float allTimeTmp = (tmpMinutes * 60) + tmpSeconds + tmpMilliSeconds;


            if (allTimeTmp > (minutes * 60) + seconds + milliseconds)
                PlayerPrefs.SetString(PlayerPrefsTags.BESTTIME, counterText.text);

        }
        else
        {
            PlayerPrefs.SetString(PlayerPrefsTags.BESTTIME, counterText.text);
        }

    }

    public void InitGame()
    {
        timeSinceStartGame = 0;
        player.transform.position = startPoint.position;
        STF.uiManager.game = true;
        player.SetActive(true);

    }


}
