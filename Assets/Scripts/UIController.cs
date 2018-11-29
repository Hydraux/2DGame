using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Slider healthBar;
	private static bool UIExists;
	public Text HPText;
	public Text ExpText;
	public HealthManager playerHealth;
	private PlayerStats thePS;
	public Image expBar;
	// Use this for initialization
	void Start () {
		if(!UIExists)
		{
			UIExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}else{
			Destroy (gameObject);
		}
		
		
		thePS = GetComponent<PlayerStats>();

	}
	
	// Update is called once per frame
	void Update () {
		
		healthBar.maxValue = playerHealth.maxHealth;
		healthBar.value = playerHealth.Health;
		HPText.text = "HP: " + playerHealth.Health + "/" + playerHealth.maxHealth;
		ExpText.text = "" + thePS.currentLevel;
		
		expBar.fillAmount = thePS.expRatio;
	}
}
