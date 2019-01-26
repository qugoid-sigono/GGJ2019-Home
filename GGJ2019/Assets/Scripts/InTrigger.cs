using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTrigger : MonoBehaviour
{

	public bool canInteraction = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
