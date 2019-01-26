using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance = null;     //Allows other scripts to call functions from HUDManager.  

    private GameManager gameManager;

    public GameObject obj_HpBar;
    public GameObject obj_MsgBlock;
    public GameObject obj_Result;

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
    // Start is called before the first frame update
    void Start()
    {
        //將gameManager設上去
        if (gameManager == null)
        {
            gameManager = GameManager.instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        adjustHpBar(gameManager.currentPlayerHp / gameManager.maxHp * gameManager.HpPercentDisplay);
    }

    void adjustHpBar(float hp)
    {
        obj_HpBar.GetComponent<Image>().fillAmount = hp;
    }

    public void sendTextToMsgBlock(string message)
    {
        obj_MsgBlock.GetComponent<Text>().text = message;
    }

    public void OpenResult()
    {
        Debug.Log("開結果");
        obj_Result.SetActive(true);
    }
}
