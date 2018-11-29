using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float playerMoveSpeed = 5f;
	private float currentMoveSpeed;
	public float diagonalMoveModifier;

	private Animator anim;
	private Rigidbody2D rb;

	private bool isMoving;

	private bool isAttacking;

	public float AttackTime = 0.1f;
	public float AttackTimeCounter;
	public Vector2 LastMove;

	private static bool playerExists;
	public string startPoint;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();

		if(!playerExists)
		{
			playerExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}else{
			Destroy (gameObject);
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		isMoving = false;
		if(!isAttacking)
		{
			if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
			{
				//transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * currentMoveSpeed * Time.deltaTime, 0f, 0f));
				rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, rb.velocity.y);
				isMoving = true;
				LastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
			}
			if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
			{
				//transform.Translate (new Vector3(0f, Input.GetAxisRaw("Vertical") * currentMoveSpeed * Time.deltaTime, 0f));
				rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
				isMoving = true;
				LastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));			
			}
			if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
			{
				rb.velocity = new Vector2(0f, rb.velocity.y);
			}
			if(Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
			{
				rb.velocity = new Vector2(rb.velocity.x, 0f);
			}
		
			if(Input.GetKeyDown("space"))
			{
				AttackTimeCounter = AttackTime;
				isAttacking = true;
				
				anim.SetBool("isAttacking", true);

			}

			if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
			{
				currentMoveSpeed = playerMoveSpeed * diagonalMoveModifier;
			} else {
				currentMoveSpeed = playerMoveSpeed;
			}
		}
			if(AttackTimeCounter > 0)
			{
				AttackTimeCounter -= Time.deltaTime;
				rb.velocity = Vector2.zero;
			}
			if(AttackTimeCounter <=0){
				isAttacking = false;
				anim.SetBool("isAttacking", false);
			}
			
		
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetBool("isMoving", isMoving);
		
		anim.SetFloat("LastMoveX", LastMove.x);
		anim.SetFloat("LastMoveY", LastMove.y);
	}
}
