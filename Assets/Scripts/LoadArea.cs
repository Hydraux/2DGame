using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArea : MonoBehaviour {

	public string levelToLoad;

	public string exitPoint;
	private PlayerController thePlayer;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if((other.gameObject.name == "Player") && (Input.GetKeyDown("e")))
		{
			SceneManager.LoadScene(levelToLoad);
			thePlayer.startPoint = exitPoint;
		}
	}
}
