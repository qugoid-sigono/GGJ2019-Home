using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
	public GameObject targetObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(targetObj){
			this.GetComponent<Transform>().position = new Vector3(targetObj.GetComponent<Transform>().position.x, targetObj.GetComponent<Transform>().position.y, this.GetComponent<Transform>().position.z);
		}
    }
}
