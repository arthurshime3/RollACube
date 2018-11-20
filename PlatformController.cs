using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
	float waitTime, timer, initialY;
	bool moving, moveUp;
	public float height;

	// Use this for initialization
	void Start () {
		moving = false;
		waitTime = 1.0f; 
		timer = waitTime;
		initialY = gameObject.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (!moving) 
		{
			timer -= Time.deltaTime;
			moveUp = gameObject.transform.position.y < height / 2.0f;
			print (moveUp);
		}
		else 
		{
			if (moveUp) 
			{
				if (gameObject.transform.position.y < height)
					gameObject.transform.Translate (new Vector3 (0, 0.1f, 0));
				else
					timer = waitTime;
			}
			if (!moveUp) 
			{
				if (gameObject.transform.position.y > initialY)
					gameObject.transform.Translate (new Vector3 (0, -0.1f, 0));
				else
					timer = waitTime;
			}
		}
		moving = (timer <= 0.0f);
	}
}
