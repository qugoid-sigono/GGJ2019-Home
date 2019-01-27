using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTrigger : MonoBehaviour
{

	public GameObject Object;
	public bool canInteraction = false;


    // Start is called before the first frame update
    void Start()
    {
		if(Object){
			this.GetComponent<BoxCollider2D>().size = Object.GetComponent<SpriteRenderer>().size + new Vector2(0.5f,0.5f);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		print(other.name);
		switch (other.tag){
		case "Player":
			canInteraction = true;
			break;
		case "":
			break;
		}
	}

	private void OnTriggerOut2D(Collider2D other)
	{
		switch (other.tag){
		case "Player":
			canInteraction = false;
			break;
		case "":
			break;
		}
	}
}
