using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] AnimationCurve curveY = null;
	[SerializeField] float speed = 6f;
	Rigidbody2D rb;
	Vector2 movement;
	Vector2 currentPos;
	Vector2 landingPos;
	float landingDis;
	//float speed = 1f;
	float timeElapsed = 0f;
	bool onGround = true;
	bool jump = false;
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {
    	rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
    	InputHandler();
    }

    void FixedUpdate()
    {
    	if(jump)
    	{
    		JumpHandler();
    		animator.SetBool("Jumping", true);
    	}
    	else
    	{
    		animator.SetBool("Jumping", false);
    		MovementHandler();
    		if(Mathf.Abs(movement.x) > 0|| Mathf.Abs(movement.y) > 0)
    		{
    			animator.SetBool("Walking", true);
    		}
    		else
    		{
    			animator.SetBool("Walking", false);
    		}
    	}
    }

    void JumpHandler()
    {
    	if(onGround)
    	{
    		currentPos = rb.position;
    		landingPos = currentPos + movement.normalized * speed;
    		landingDis = Vector2.Distance(landingPos, currentPos);
    		timeElapsed = 0f;
    		onGround = false;
    	}
    	else
    	{
    		timeElapsed += Time.fixedDeltaTime * speed / landingDis;
    		if(timeElapsed <= 1f)
    		{
    			currentPos = Vector2.MoveTowards(currentPos, landingPos, Time.fixedDeltaTime * speed);
    			rb.MovePosition(new Vector2(currentPos.x, currentPos.y + curveY.Evaluate(timeElapsed)));
    		}
    		else
    		{
    			jump = false;
    			onGround = true;
    		}
    	}
    }

    void MovementHandler()
    {
    	rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void InputHandler()
    {
    	float horizontal = Input.GetAxis("Horizontal");
    	float vertical = Input.GetAxis("Vertical");


    	movement = new Vector2(horizontal, vertical);

    	if(Input.GetKeyDown("space"))
    	{
    		jump = true;
    	}
    }
}