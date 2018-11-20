using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
	public string levelName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.touchCount == 1)
//			if (Input.GetTouch (0).phase == TouchPhase.Began)
//				Application.LoadLevel (levelName);
	}

	void OnMouseDown()
	{
		Application.LoadLevel (levelName);
	}
}
