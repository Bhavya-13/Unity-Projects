using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour {

	
	public CharacterController2D controller;
    public Animator animator;
	private Rigidbody2D rb;
	public float bounce = 5f;


    [SerializeField]
	public static float runSpeed = 30f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	
    void Start(){
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
            animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

    public void Onlanding ()
    {
        animator.SetBool("IsJumping", false);
    }

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacles")
        {
           SceneManager.LoadScene("GameOver");
		   runSpeed = 30f;
		}

		if (col.gameObject.tag == "BelowBarrier")
        {
           SceneManager.LoadScene("GameOver");
		   runSpeed = 30f;
        }

		if (col.gameObject.tag == "MovingPlatform"){
			this.transform.parent = col.transform;
		}

		if (col.gameObject.tag == "Enemy"){
			rb.AddForce(new Vector2(0f, bounce));
		}

	}

    public Vector3 GetPosition() {
        return transform.position;
    }

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "MovingPlatform")
			this.transform.parent = null;
	}

}