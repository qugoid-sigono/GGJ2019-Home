using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance = null;     //Allows other scripts to call functions from HUDManager.  

    private GameManager gameManager;

    public GameObject obj_HpBar;
    public GameObject obj_HpBarShadow;
    public GameObject obj_HpFlame;
    public GameObject obj_MsgBlock;
    public GameObject obj_ResultPanel;
    public GameObject obj_Score;
    public GameObject obj_ScoreShadow;
    public GameObject obj_ResultScore;
    public GameObject obj_ResultHighScore;
    public GameObject obj_WoodCountTxt;
    public GameObject obj_WoodCountTxtShadow;

    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            DestroyImmediate(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //將gameManager設上去
        if (gameManager == null)
        {
            gameManager = GameManager.instance;
        }

        adjustHpBar(gameManager.currentPlayerHp / gameManager.maxHp * gameManager.HpPercentDisplay);
        adjustScore(gameManager.timer);
        showWoodTxt(gameManager.currentItemHold);
    }

    // Update is called once per frame
    void Update()
    {
        adjustHpBar(gameManager.currentPlayerHp / gameManager.maxHp * gameManager.HpPercentDisplay);
        adjustScore(gameManager.timer);
        showWoodTxt(gameManager.currentItemHold);
    }

    void adjustHpBar(float hp)
    {
        obj_HpBar.GetComponent<Image>().fillAmount = hp;
        obj_HpBarShadow.GetComponent<Image>().fillAmount = hp;
        obj_HpFlame.GetComponent<RectTransform>().localPosition = new Vector3(1350 * hp, 0,0);
    }

    void adjustScore(float time)
    {
        obj_Score.GetComponent<Text>().text = Mathf.Floor(time / 60).ToString("00") + ":" + Mathf.Floor(time % 60).ToString("00");
        obj_ScoreShadow.GetComponent<Text>().text = Mathf.Floor(time / 60).ToString("00") + ":" + Mathf.Floor(time % 60).ToString("00");
    }

    public void showWoodTxt(int woodCount)
    {
        obj_WoodCountTxt.GetComponent<Text>().text = woodCount.ToString();
        obj_WoodCountTxtShadow.GetComponent<Text>().text = woodCount.ToString();
        
    }

    public void sendTextToMsgBlock(string message)
    {
        obj_MsgBlock.GetComponent<Text>().text = message;
    }

    public void OpenResult(int score)
    {
        Debug.Log("開結果");
        obj_ResultPanel.SetActive(true);
        obj_ResultScore.GetComponent<Text>().text = Mathf.Floor(score / 60).ToString("00") + ":" + Mathf.Floor(score % 60).ToString("00");
        obj_ResultHighScore.GetComponent<Text>().text = Mathf.Floor(PlayerPrefs.GetInt("HighScore") / 60).ToString("00") + ":" + Mathf.Floor(PlayerPrefs.GetInt("HighScore") % 60).ToString("00");

    }
}
