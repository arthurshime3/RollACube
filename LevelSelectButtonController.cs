using UnityEngine;
using System.Collections;

public class LevelSelectButtonController : MonoBehaviour {
	public int levelNumber;
	// Use this for initialization
	void Start () {
		if (GlobalControl.instance.currentLevel < levelNumber) 
		{
			GetComponent<UnityEngine.UI.Image> ().color = Color.gray;
			GetComponent<UnityEngine.UI.Button> ().interactable = false;
		} 
		else 
		{
			GetComponent<UnityEngine.UI.Image> ().color = Color.white;
			GetComponent<UnityEngine.UI.Button> ().interactable = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
