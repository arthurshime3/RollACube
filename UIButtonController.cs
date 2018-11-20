using UnityEngine;
using System.Collections;

public class UIButtonController : MonoBehaviour {
//	public string levelName;
	public GameObject pauseScreen;

	// Use this for initialization
	void Start () {
		pauseScreen.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Action (string levelName)
	{
		Application.LoadLevel (levelName);
	}

//	public void Pause ()
//	{
//		pauseScreen.SetActive (true);
//	}
//
//	public void Resume ()
//	{
//		pauseScreen.SetActive (false);
//	}
}
