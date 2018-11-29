using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChestInventory : InventoryManager {

	private PlayerController thePlayer;
	public GameObject chestInventory;
	public GameObject chestItem;

	// Use this for initialization
	void Start () {
		thePlayer = GetComponent<PlayerController>();
		chestInventory = GameObject.Find("Panel");
		//chestInventory.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		
		if((other.gameObject.name == "Player") && Input.GetKeyDown("e"))
		{
			Instantiate(chestItem, gameObject.transform, false);
			
			
		}
	}
}
