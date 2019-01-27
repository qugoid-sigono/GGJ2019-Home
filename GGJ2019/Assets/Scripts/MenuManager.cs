using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject objHighScoreText;
    public GameObject creditPanel;


    // Start is called before the first frame update
    void Start()
    {
        int highScore = 0;

        highScore = PlayerPrefs.GetInt("HighScore");

        objHighScoreText.GetComponent<Text>().text = Mathf.Floor(highScore / 60).ToString("00") + ":" + Mathf.Floor(highScore % 60).ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCredit()
    {
        Debug.Log("打開");
        creditPanel.SetActive(true);
    }

    public void CloseCredit()
    {
        Debug.Log("關閉");
        creditPanel.SetActive(false);
    }

    public void Play()
    {
        //轉換Scene
        SceneManager.LoadScene("Game");
    }
}
