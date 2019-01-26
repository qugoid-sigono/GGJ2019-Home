using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;     //Allows other scripts to call functions from GameManager.             

    #region 玩家血量數值設定
    //玩家血量數值
    public float maxHp = 100f;          // 最大血量(初始血量)
    public float minHp = 0f;            // 最低血量
    public float plusHpPerSecond = 1;   // 每秒加多少
    public float minusHPPerSecond = 1;  // 每秒扣多少

    public float currentPlayerHp;       // 玩家當前血量
    #endregion

    //場景數值
    public int totalPoint = 0;         //玩家分數

    #region  遊戲環境數值
    private bool gameStart = false; //遊戲開始狀態(true:開始/false:結束)
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

    void Update()
    {
        if (gameStart == true)
        {
            
            //玩家狀態
            switch (currentPlayerStat)
            {
                case playerStat.Iddle:     //玩家無事時
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
        gameStart = true;
        resetGameStat();
        Debug.Log("遊戲開始！");
    }

    void resetGameStat()
    {
        //遊戲數值重設
        currentPlayerHp = maxHp;
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

    public void recoverHp(int hp)
    {
        //回血
        currentPlayerHp += hp;
    }

    public void AddPoint(int point = 0)
    {
        //加分
        totalPoint += point;
    }

    public void GameOver()
    {
        //遊戲結束
        gameStart = false;
        Debug.Log("遊戲結束！");
    }

    //改變玩家狀態
    public void ChangePlayerStat(int stat = 0)
    {
        currentPlayerStat = (playerStat)Enum.Parse(typeof(playerStat), stat.ToString());
    }
}