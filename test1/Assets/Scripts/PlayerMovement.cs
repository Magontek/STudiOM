using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	float speed = 1f;
	Rigidbody2D rb;
	Vector2 movement;
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
		MovementHandler();
		if(Mathf.Abs(movement.x) > 0|| Mathf.Abs(movement.y) > 0)
		{
			Debug.Log(movement);
			animator.SetBool("Walking", true);
		}
		else
		{
			animator.SetBool("Walking", false);
		}
    }

    void MovementHandler()
    {
    	rb.MovePosition(rb.position + movement * speed);
    	//rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void InputHandler()
    {
    	float horizontal = Input.GetAxis("Horizontal");
    	float vertical = Input.GetAxis("Vertical");
    	if (horizontal != 0 && vertical != 0)
    	{
    		movement = new Vector2(horizontal/29, vertical/50)/15*10;
    	}
    	else
    	{
    	movement = new Vector2(horizontal, vertical)/40;
    	}

    }
}