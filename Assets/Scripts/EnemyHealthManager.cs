using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int EnemyHealth;
	public int maxEnemyHealth;
	private PlayerStats thePlayerStats;
	public int expToGive;
	// Use this for initialization
	void Start () {
		EnemyHealth = maxEnemyHealth;

		thePlayerStats = FindObjectOfType<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
		if(EnemyHealth <= 0)
		{
			Destroy(gameObject);
			Debug.Log("Give Exp");
			thePlayerStats.AddExperience(expToGive);
		}
	}

	public void takeDamage(int Damage)
	{
		EnemyHealth -= Damage;
		
	}

	public void setMaxHealth(int maxEnemyHealth)
	{
		EnemyHealth = maxEnemyHealth;
	}
}
