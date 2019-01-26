using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

	public Rigidbody2D playerRigidbody2D;

	//[Range(0, 150)]
	public float xForce = 2;
	public float yForce = 2;
	public uint brakeTime = 10;
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
		float newSpeedY = Mathf.Clamp(speedY, -maxSpeedY, maxSpeedY);
		playerRigidbody2D.velocity = new Vector2(newSpeedX, newSpeedY);
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
		}else{
			if(Mathf.Abs(playerRigidbody2D.velocity.x) > 0 || Mathf.Abs(playerRigidbody2D.velocity.y) > 0){
				float vx = playerRigidbody2D.velocity.x - playerRigidbody2D.velocity.x / (1 + brakeTime);
				float vy = playerRigidbody2D.velocity.y - playerRigidbody2D.velocity.y / (1 + brakeTime);
				if(Mathf.Abs(vx) < 0) vx = 0.0f;
				if(Mathf.Abs(vy) < 0) vy = 0.0f;
				playerRigidbody2D.velocity = new Vector2(vx, vy);
			}
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("this is 2D Trigger ,tag :" + other.tag);
        switch (other.tag)
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("this is 2D Collision ,tag :" + other.collider.tag);
        switch (other.collider.tag)
        {
            case "Home":
                GameManager.instance.event_backHome();
                break;
            case "":
                break;
        }
    }
}
