using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class PlayerMovement : MonoBehaviour {

	public Dialog dialog;
	public CharacterController2D controller;
	public SoundManager SoundManager;
	public Animator animator;
	public bool isDead;
	public bool isGround;
	public bool canMove;
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;

 
    void Start()
    {
		isDead = false;
		isGround = false;
		canMove = true;
    }
		
	
	void Update () {

        if (isDead == false && canMove == true)
        {
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
			animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		}

		if (Input.GetKeyDown(KeyCode.Space) && isDead == false && canMove == true)
		{
			jump = true;
			SoundManager.PlaySound("Jump");
		}
		else if (Input.GetKey(KeyCode.Space) && isDead == false)
		{
			
			jump = true;
			animator.SetBool("IsJumping", true);
		}
		

	}
	public void OnCollisionEnter2D(Collision2D col)
	{	
		if (col.gameObject.tag == "MaðraBitiþ")
		{
			SceneManager.LoadScene("1");
		}
		if (col.gameObject.tag == "Tuzak")
        {
			isDead = true;
        }
		if (col.gameObject.tag == "Zemin")
		{
			isGround = true;
		}
        if (col.gameObject.tag == ("Diyalog"))
        {
			canMove = false;
			dialog.anim.SetBool("IsOpen", true);
			dialog.StartDialog();
			Destroy(dialog.Bariyer);
			
        }
        if (col.gameObject.tag == "Lanet")
        {
			SceneManager.LoadScene("Lanet");
		}
	
	}

	public void OnLanding ()
	{
        if (isDead == false)
        {
			animator.SetBool("IsJumping", false);
		}
	}

	void FixedUpdate ()
	{
        if (canMove == true)
        {
			controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		}
		jump = false;
	}
}
