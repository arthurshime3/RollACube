using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset, playerInitialPos;
	private bool offsetSet;

	void Start ()
	{
		playerInitialPos = player.transform.position;
		SetOffset ();
	}

	void LateUpdate ()
	{
//		if ((player.transform.position.z < playerInitialPos.z - 5.0f || player.transform.position.z > playerInitialPos.z + 5.0f) ||
//			(player.transform.position.x < playerInitialPos.x - 2.0f || player.transform.position.x > playerInitialPos.x + 2.0f)) 
//		{
//			if (!offsetSet)
//				SetOffset ();
//			transform.position = player.transform.position + offset;
//		} 
//		else
//			offsetSet = false;

		transform.position = player.transform.position + offset;
	}

	void Awake()
	{
		Application.targetFrameRate = 60;
	}

	void SetOffset() 
	{
		offset = transform.position - player.transform.position;
		offsetSet = true;
	}

	void ChangePlayer(GameObject newPlayer)
	{
		player = newPlayer;
	}
}
