using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	Vector3 position;

	float drag, timeLeft = 1.0f, currentSpeed;
	public float speed;
	public GameObject winSquare;
	Rigidbody rb;
	bool playing, paused;
	Vector3 initialPos, winPos;
	public VirtualJoystickController vjc;

    public GameObject levelCompleteObject;
	public int level;
	public GameObject pauseScreen;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		drag = 0;
		currentSpeed = 100.0f;
		playing = true;
		paused = false;
		initialPos = transform.position;
        levelCompleteObject.SetActive(false);
		//pauseScreen = GameObject.Find ("Joystick/Virtual Joystick 1/Pause Screen");
		pauseScreen.SetActive (false);	
	}
	
	// Update is called once per frame
	void Update () 
	{
        float moveHorizontal = 0;
        float moveVertical = 0; 

        if (vjc != null)
        {
            moveHorizontal = vjc.Horizontal();
            moveVertical = vjc.Vertical();
        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		if (movement.magnitude > 0.5)
			currentSpeed = speed;
		else
			currentSpeed = 5000.0f;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
                Pause();
            else
                Resume();
        }

		if (!paused) 
		{
			rb.AddForce (movement * currentSpeed * Time.deltaTime);

			if (transform.position.y < -10.0f)
				Respawn ();
		}
	}

	public void Pause()
	{
		paused = true;
		pauseScreen.SetActive (paused);
	}

	public void Resume()
	{
		paused = false;
		pauseScreen.SetActive (paused);
	}

	public void Respawn()
	{
		if (playing)
			Application.LoadLevel (Application.loadedLevel);
		else
			transform.position = winPos;
	}

	void SetSpeed(float newSpeed)
	{
		speed = newSpeed;
	}

	void LevelComplete()
	{
		if (playing) 
		{
            levelCompleteObject.SetActive(true);
			winPos = winSquare.transform.position;
			if (GlobalControl.instance.currentLevel < level + 1)
				GlobalControl.instance.currentLevel = level + 1;
		}
		playing = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Win")) 
			LevelComplete ();
	}
}
