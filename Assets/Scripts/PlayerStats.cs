using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public int currentLevel;
	public int currentattackLevel;
	public int currentExp;
	public int currentHealthLevel;
	public Item weapon;

	public int[] toLevelUp;
	public int[] attackLevel;
	public int[] healthLevel;
	public InventoryManager Inventory;


	public HealthManager thePlayer;
	public DamageEnemy damageEnemy;
	public float expRatio;
	// Use this for initialization
	void Start () {
		//thePlayer = GetComponent<HealthManager>();
		//Inventory =  GetComponent<InventoryManager>();
		weapon = Inventory.Weapon.GetComponent<Item>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		currentattackLevel =weapon.ItemDamage + attackLevel[currentLevel];
		
		if(currentExp >= toLevelUp[currentLevel])
		{
			LevelUp();
            
		}
		expRatio = (float)currentExp / (float)toLevelUp[currentLevel];
	}

	public void AddExperience(int experiencetoAdd)
	{
		currentExp += experiencetoAdd;
	}

	private void LevelUp()
	{
		currentLevel++;
		currentattackLevel = attackLevel[currentLevel];
		currentHealthLevel = healthLevel[currentLevel];
		thePlayer.maxHealth = currentHealthLevel;
		thePlayer.Health = thePlayer.maxHealth;
	}
}
