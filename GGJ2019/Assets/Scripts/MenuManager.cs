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

        objHighScoreText.GetComponent<Text>().text = highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCredit()
    {
        creditPanel.active = true;
    }

    public void CloseCredit()
    {
        creditPanel.active = false;
    }

    public void Play()
    {
        //轉換Scene
        SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);
    }
}
