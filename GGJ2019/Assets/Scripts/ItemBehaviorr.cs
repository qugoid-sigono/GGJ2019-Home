using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviorr : MonoBehaviour
{
    // Start is called before the first frame update
	private GameManager gameManager;
	public GameObject InteractionRange;


	bool mouseDown = false;
	public int Hp = 1;

    void Start()
    {
		//遊戲開始時根據Y軸調整物件圖層
		float posY = this.GetComponent<Transform>().position.y;
		this.GetComponent<SpriteRenderer>().sortingOrder = -((int)posY + 1000);

		if (gameManager == null)
		{
			gameManager = GameManager.instance;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnMouseDown()
	{
		mouseDown = true;
	}

	void OnMouseUp()
	{
		if(mouseDown){
			mouseDown = false;
			if(InteractionRange != null)
			if(InteractionRange.GetComponent<InTrigger>().canInteraction){
				if(gameManager.UsePickaxe())
					Hp --;
			}
		}
		if(Hp <= 0){
			Destroy(this.gameObject);
		}
	}



}
