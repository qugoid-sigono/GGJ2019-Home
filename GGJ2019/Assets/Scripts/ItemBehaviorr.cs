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
		if(this.GetComponent<SpriteRenderer>() == null)
			return;

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
/*	//用raycasting寫在playerMove
	void OnMouseDown()
	{
		mouseDown = true;
	}

	void OnMouseUp()
	{
		if(mouseDown){
			mouseDown = false;
			print("mouseDown" + mouseDown);
			if(InteractionRange != null)
			if(InteractionRange.GetComponent<InTrigger>().canInteraction){
				print("UsePickaxe" + mouseDown);
				if(gameManager.UsePickaxe())
					Hp --;
			}
		}
		if(Hp <= 0){
			Destroy(this.gameObject);
		}
	}
*/
	public void OnMouseRayHit()
	{
		print("OnMouseClick");
		if(InteractionRange != null)
		if(InteractionRange.GetComponent<InTrigger>().canInteraction){
			print("UsePickaxe");
			if(gameManager.UsePickaxe())
				Hp --;
		}

		if(Hp <= 0){
			Destroy(this.gameObject);
		}
	}



}
