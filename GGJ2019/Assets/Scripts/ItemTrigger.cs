using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
	private GameManager gameManager;
	public bool fireWood;
	public bool pickaxe;
	public int pickaxeNum;
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
		switch (other.tag){
			case "Player":
				if(gameManager){
				if(fireWood){
					gameManager.AddWood();
					Debug.Log("Item Picked Up! Now ItemNum = "+gameManager.currentItemHold);
				}
				if(pickaxe){
					gameManager.AddPickaxe(pickaxeNum);
					Debug.Log("Item Picked Up! Now pickaxeNum = "+gameManager.pickaxeNum);
				}					
					Destroy(this.gameObject);
				
				}else{
					Debug.Log("There is no gameManager on this scece!");
				}
			break;
			case "":
				break;
		}
	}
}
