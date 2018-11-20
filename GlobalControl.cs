using UnityEngine;
using System.Collections;

public class GlobalControl : MonoBehaviour {
	public static GlobalControl instance;

	public int currentLevel = 1, currentCameraView = 1;
	// Use this for initialization
	void Start () {
		currentLevel = PlayerPrefs.GetInt ("CurrentLevel", 1);
		currentCameraView = PlayerPrefs.GetInt ("CurrentCameraView", 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake()
	{
		if (instance == null)
		{
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
		else if (instance != this)
			Destroy (gameObject);
	}

	void OnApplicationQuit() 
	{
		PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.SetInt("CurrentCameraView", currentCameraView);
	}

    public void Quit()
    {
        Application.Quit();
    }
}
