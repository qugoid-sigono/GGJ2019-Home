using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

	public Rigidbody2D playerRigidbody2D;

	//[Range(0, 150)]
	public float xForce;
	public float yForce;

	//目前速度
	float speedX;
	float speedY;

	//[Header("最大水平速度")]
	public float maxSpeedX;
	public float maxSpeedY;

	public void ControlSpeed()
	{
		speedX = playerRigidbody2D.velocity.x;
		speedY = playerRigidbody2D.velocity.y;
		float newSpeedX = Mathf.Clamp(speedX, -maxSpeedX, maxSpeedX);
		playerRigidbody2D.velocity = new Vector2(newSpeedX, speedY);
	}

	/// <summary>水平移動</summary>
	void Movement()
	{
		//if(Input.GetMouseButton(0)){

		if (Input.GetMouseButton (0)){
			Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			mousePos = Camera.main.ScreenToWorldPoint (mousePos);
			float xF = (mousePos.x - this.GetComponent<Transform>().position.x) * xForce;
			float yF = (mousePos.y - this.GetComponent<Transform>().position.y) * yForce;

			//horizontalDirection = Input.GetAxis(HORIZONTAL);
			playerRigidbody2D.AddForce(new Vector2(xF , yF));
		}
	}

    // Start is called before the first frame update
    void Start()
    {
		playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		Movement();
		ControlSpeed();
    }
}
