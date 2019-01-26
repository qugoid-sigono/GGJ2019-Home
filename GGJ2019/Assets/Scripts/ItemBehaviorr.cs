using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviorr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		float posY = this.GetComponent<Transform>().position.y;
		this.GetComponent<SpriteRenderer>().sortingOrder = -((int)posY + 1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
