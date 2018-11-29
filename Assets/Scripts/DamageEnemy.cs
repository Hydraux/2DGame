using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour {
	
	
	public int Damage;

	public GameObject damageBurst;
	public Transform hitPoint;
	public GameObject damageNumber;
	public PlayerStats thePs;
	// Use this for initialization
	void Start () {
		thePs = FindObjectOfType<PlayerStats>();
		
	}
	
	// Update is called once per frame
	void Update () {
		Damage = thePs.currentattackLevel;
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			other.gameObject.GetComponent<EnemyHealthManager>().takeDamage(Damage);
			Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
			
			var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageNumber = Damage;
		}
	}
}
