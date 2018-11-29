using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D myRigidbody;

	private bool moving; //is the slime moving?

	public float timeBetweenMove; //how long the slime stands still
	private float timeBetweenMoveCounter; //counts down to 0 to move the slime
	public float timeToMove; //how long the slime moves for
	private float timeToMoveCounter; //counts down to 0 to make the slime still

	private Vector3 moveDirection; //which way the slime moves (x,y,z)

	public bool reloading;//is the scene being reloaded (ex: player death)

	private float timeToReload; //time left before scene reload
	public GameObject thePlayer; //the player game object
	private float playerX;
	private float playerY;
	private float deltaX;
	private float deltaY;
	public float distance;
	private float moveX;
	private float moveY;
	public float currentDistance;
	

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>(); //the RigidBody2d of the slime
		thePlayer = GameObject.Find("Player");

		//timeBetweenMoveCounter = timeBetweenMove; -----old function for below ------
		//timeToMoveCounter = timeToMove; -----old function for below -----
		timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f); //sets each slime's timeBetweenMove to a random number between 3/4 and 5/4 time
		timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);//sets each slime's timeToMove to a random number between 3/4 and 5/4 the original time
	}
	
	// Update is called once per frame
	void Update () {
		currentDistance = checkPos();
		if(moving) //if it is time for the slime to move
		{
			timeToMoveCounter -= Time.deltaTime; //counts the time to move counter down	
			myRigidbody.velocity = moveDirection; //moves the slime 

			if(timeToMoveCounter < 0f) //if the slime is out of time to move
			{
				moving = false; //states that the slime should not be moving anymore
				//timeBetweenMoveCounter = timeBetweenMove; -----old function for below ------
				timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f); //resets the counter for time between movement
			}

		}else{ //if the slime should not be moving
			timeBetweenMoveCounter -= Time.deltaTime; //counts the still time down
			myRigidbody.velocity = Vector2.zero; //sets the slime's velocity to 0 (x,y,z) = (0,0,0)

			if(timeBetweenMoveCounter < 0f) //if the stillness time has run out
			{
				moving = true; //states that the slime should start moving
				//timeToMoveCounter = timeToMove; ---old function for below-----
				timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f); //resets the time to move counter
				moveType(currentDistance);
			}
		}
		
		if(reloading) //if the scene should be reloaded
		{
			
			timeToReload -= Time.deltaTime; //counts a timer down
			Debug.Log(timeToReload);
			if(timeToReload < 0) //if the timer passes 0
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reload the current scene
				thePlayer.SetActive(true); //make the player visible
			}
		}
	}

	public void moveType(float distanceFrom)
	{
		distanceFrom = Mathf.Sqrt(Mathf.Pow(deltaX,2) + Mathf.Pow(deltaY, 2));
		if(distanceFrom <= 3)
		{
			Debug.Log("In range");
			moveAttack();
		}else{
			moveRandom();
		}
	}
	public void moveRandom()
	{
		moveDirection = new Vector3(Random.Range (-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f); //sets the velocity of the slime's next movement
	}
	public void moveAttack()
	{	
		moveX = checkValue(deltaX);
		moveY = checkValue(deltaY);
		 
		Vector3 moveInDirection = new Vector3(-1 * moveX, -1 * moveY, 0f);
		moveDirection = Vector3.Normalize(moveInDirection) * moveSpeed; //sets the velocity of the slime's next movement
	}
	public float checkValue(float input)
	{
		if(input > 0)
		{
			return 1f;
		}else if(input < 0)
		{
			return -1f;
		}else
		{
			return 0f;
		}

	
	}
	public float checkPos()
	{
		playerX = thePlayer.transform.position.x;
		playerY = thePlayer.transform.position.y;
		deltaX = transform.position.x - playerX;
		deltaY = transform.position.y - playerY;
		distance = Mathf.Sqrt(Mathf.Pow(deltaX,2) + Mathf.Pow(deltaY, 2));
		return distance;
	}

	
}
