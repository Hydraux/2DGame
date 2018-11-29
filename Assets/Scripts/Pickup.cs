using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	private InventoryManager inventory;
	public GameObject itemButton;
	
	void Start()
	{
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{

			if(gameObject.CompareTag("Weapon") && inventory.isFull[0] == false)
			{
				inventory.isFull[0] = true;
				Instantiate(itemButton, inventory.slots[0].transform, false);
				Destroy(gameObject);
			}else{

			
				for(int i = 1; i < inventory.slots.Length; i++)
				{
					if(inventory.isFull[i] == false)
					{
						inventory.isFull[i] = true;
						Instantiate(itemButton, inventory.slots[i].transform, false);
						Destroy(gameObject);
						break;
					}
				}
			}
		}
	}
}
