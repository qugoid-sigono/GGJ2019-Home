using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
	private GameManager gameManager = new GameManager();

    // Start is called before the first frame update
    void Start()
    {
		if (gameManager == null)
		{
			gameManager = GameManager.instance;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(gameManager){
			gameManager.currentItemHold++;
			Debug.Log("Item Picked Up! Now ItemNum = "+gameManager.currentItemHold);
			Destroy(this.gameObject);
		}else{
			Debug.Log("There is no gameManager on this scece!");
		}
	}
}
