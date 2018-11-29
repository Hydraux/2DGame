using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InventoryManager : MonoBehaviour {

	public bool[] isFull;
	public GameObject[] slots;

	public GameObject Weapon;
	

	void Start()
	{
		isFull[0] = true;
		Instantiate(Weapon, slots[0].transform, false);
	}

	void Update()
	{
		Weapon = slots[0];

	}

}
