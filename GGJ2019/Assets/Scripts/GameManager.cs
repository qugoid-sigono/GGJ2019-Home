using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;     //Allows other scripts to call functions from GameManager.             

    #region 玩家血量數值設定
    //玩家血量數值
    private float iniHp;                // 最大初始血量
    public float maxHp = 100f;          // 當前最大血量(初始血量)
    public float minHp = 0f;            // 最低血量
    public float plusHpPerSecond = 1;   // 每秒加多少
    public float minusHPPerSecond = 1;  // 每秒扣多少

    public float currentPlayerHp;       // 玩家當前血量
    #endregion

    //場景數值
    public int totalScore = 0;         //玩家分數
    public int currentItemHold;        //玩家所持物品數量
    public int pointPerItem;           //每個道具所加的分
    public int hpPerItem;              //每個道具所加的血

    #region  遊戲環境數值
    public bool gameStart = false; //遊戲開始狀態(true:開始/false:結束)
    public enum playerStat
    {
        Iddle = 0,
        OutHouse = 1,
        InHouse = 2
    }

    public playerStat currentPlayerStat;              //玩家當前狀況(0:nothing/1:家外/2:家內)
    #endregion


    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        iniHp = maxHp;
    }

    void Update()
    {
        if (gameStart == true)
        {
            
            //玩家狀態
            switch (currentPlayerStat)
            {
                case playerStat.Iddle:     //玩家無事時(目前沒在用)
                    //nothing
                    break;
                case playerStat.OutHouse:     //在家外時
                    action_loseHp();
                    break;
                //case playerStat.InHouse:     //在家內時
                //    action_plusHp();
                //    break;
            }

            if (currentPlayerHp <= 0)
            {
                GameOver();
            }
        }
    }

    public void GameStart()
    {
        //遊戲開始
        if (gameStart == false)
        {
            gameStart = true;
            resetGameStat();
            Debug.Log("遊戲開始！");
        }
    }

    public void event_backHome()
    {
        //根據玩家所持的道具回血
        recoverHp(currentItemHold * hpPerItem);
        //根據玩家所持道具數量加分
        AddPoint(currentItemHold * pointPerItem);

        currentItemHold = 0;    //道具歸0
    }

    public void GameOver()
    {
        if (gameStart == true)
        {
            //遊戲結束
            gameStart = false;
            //最高分存檔
            PlayerPrefs.SetInt("HighScore", totalScore);
            Debug.Log("遊戲結束！");
        }
    }

    void resetGameStat()
    {
        //遊戲數值重設
        totalScore = 0;
        currentPlayerHp = iniHp;
        currentPlayerStat = playerStat.OutHouse;
    }

    void action_plusHp()
    {
        currentPlayerHp = Mathf.Clamp(currentPlayerHp + plusHpPerSecond * Time.deltaTime, minHp, maxHp);
        //objHpBar.GetComponent<Image>().fillAmount = currentPlayerHp / maxHp;
    }

    void action_loseHp()
    {
        //扣血
        currentPlayerHp = Mathf.Clamp(currentPlayerHp - minusHPPerSecond * Time.deltaTime, minHp, maxHp);
        //objHpBar.GetComponent<Image>().fillAmount = currentPlayerHp / maxHp;
    }

    void recoverHp(int hp)
    {
        //最大生命值增加
        maxHp += hp;
        //回血
        currentPlayerHp += hp;
    }

    void AddPoint(int point = 0)
    {
        //加分
        totalScore += point;
    }

    //改變玩家狀態
    public void ChangePlayerStat(int stat = 0)
    {
        currentPlayerStat = (playerStat)Enum.Parse(typeof(playerStat), stat.ToString());
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Additive);
    }
}