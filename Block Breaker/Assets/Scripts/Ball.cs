using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private Vector3 PaddleBallCenterDistance; 
	public static bool hasStarted = false;
	// Use this for initialization
	void Start () {
	paddle = GameObject.FindObjectOfType<Paddle>();
	PaddleBallCenterDistance = this.transform.position - paddle.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
	if (!hasStarted){
		this.transform.position = paddle.transform.position + PaddleBallCenterDistance;
		if (Input.GetMouseButtonDown(0))
		{
		print ("Mouse Clicked");
		hasStarted = true;
		this.rigidbody2D.velocity = new Vector2 (2f,13f);
		
		}
	}
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
	Vector2 tweak = new Vector2(Random.Range(0f,0.2f),Random.Range(0f,0.2f));
	if (hasStarted)
	{
	rigidbody2D.velocity += tweak;
	
	}
	}
}
