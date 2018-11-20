using UnityEngine;
using System.Collections;

public class PlayerCameraController : MonoBehaviour {
	public GameObject camera1, camera2, camera3;

	// Use this for initialization
	void Start () {
		if (GlobalControl.instance.currentCameraView == 1)
			SwitchToOne ();
		else if (GlobalControl.instance.currentCameraView == 2)
			SwitchToTwo ();
		else
			SwitchToThree ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SwitchToOne() {
		camera1.SetActive (true);
        if (camera2 != null) camera2.SetActive (false);
		if (camera3 != null) camera3.SetActive (false);
		GlobalControl.instance.currentCameraView = 1;
	}

	public void SwitchToTwo() {
		camera2.SetActive (true);
		camera1.SetActive (false);
		if (camera3 != null) camera3.SetActive (false);
		GlobalControl.instance.currentCameraView = 2;
	}

	public void SwitchToThree() {
		camera3.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 1);
		camera3.SetActive (true);
		camera1.SetActive (false);
		camera2.SetActive (false);
		GlobalControl.instance.currentCameraView = 3;
	}
}
