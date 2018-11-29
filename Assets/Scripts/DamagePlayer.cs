using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

	public int Damage = 10;

	public GameObject damageBurst;
	public Transform hitPoint;
	public GameObject damageNumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other){ //if the slime collides with another object
		if(other.gameObject.name == "Player") //if that other object is the player
		{
			other.gameObject.GetComponent<HealthManager>().takeDamage(Damage);

			var clone = (GameObject) Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageNumber = Damage;
		}
		
	}
}
