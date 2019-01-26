using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour
{
	public Camera CameraUI;
	public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		if(CameraUI == null){
			Debug.Log("No Camera Setting!");
			return;
		}

		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		Vector3 mousePosUI = CameraUI.ScreenToWorldPoint (mousePos);
		this.GetComponent<Transform>().position = new Vector3(mousePosUI.x, mousePosUI.y, this.GetComponent<Transform>().position.z);


		if (Player == null) {
			Debug.Log("No Player Setting!");
			return;
		}

		Vector3 mousePosMain = Camera.main.ScreenToWorldPoint (mousePos);
		Vector3 dir = new Vector3 (mousePosMain.x - Player.GetComponent<Transform>().position.x, mousePosMain.y - Player.GetComponent<Transform>().position.y, 0);
		this.GetComponent<Transform>().rotation = Quaternion.Euler (0f, 0f, Mathf.Atan2(dir.y, dir.x) * 180/Mathf.PI - 90);

    }

	float VectorAngle(Vector2 from, Vector2 to)
	{
         float angle;
        
         Vector3 cross=Vector3.Cross(from, to);
         angle = Vector2.Angle(from, to);
         return cross.z > 0 ? -angle : angle;
	}
}
