using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

	public int Health;
	public int maxHealth;
	public bool flashActive;
	public float flashTime = 10f;
	public float flashTimeCounter;
	private SpriteRenderer SpriteRender;

	// Use this for initialization
	void Start () {
		Health = maxHealth;
		SpriteRender = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(flashActive)
		{
			playerFlash();
		}
	}

	public void takeDamage(int Damage)
	{
		Health -= Damage;
		setplayerFlash(flashTime);
		if(Health <= 0)
		{
			gameObject.SetActive(false);
		}


	}

	public void setMaxHealth(int maxHealth)
	{
		Health = maxHealth;
	}

	public void setplayerFlash(float flashTime)
	{
		flashActive = true;
		//SpriteRender.color = new Color(SpriteRender.color.r, SpriteRender.color.g, SpriteRender.color.b, 0.1f);
		flashTimeCounter = flashTime;
		

	}
	public void playerFlash()
	{
			flashTimeCounter -= Time.deltaTime;
			if(flashTimeCounter > flashTime * 0.66)
			{
				SpriteRender.color = new Color(SpriteRender.color.r, SpriteRender.color.g, SpriteRender.color.b, 0.1f);
			}else  if(flashTimeCounter > flashTime * 0.33)
			{
				SpriteRender.color = new Color(SpriteRender.color.r, SpriteRender.color.g, SpriteRender.color.b, 1f);
			}else if(flashTimeCounter > 0)
			{
				SpriteRender.color = new Color(SpriteRender.color.r, SpriteRender.color.g, SpriteRender.color.b, 0.1f);
			}else
			{
				flashActive = false;
				SpriteRender.color = new Color(SpriteRender.color.r, SpriteRender.color.g, SpriteRender.color.b, 1f);
				
			}
			
	}
}
