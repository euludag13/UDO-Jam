using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public SoundManager SoundManager;
	public Animator animator;
	public bool isDead;
	public bool isGround;
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	
	
	void Start()
    {
		isDead = false;
		isGround = false;
    }
		
	
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (isDead == false)
        {
			animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		}

		if (Input.GetKey(KeyCode.Space) && isDead == false)
		{
			jump = true;
			animator.SetBool("IsJumping", true);
			SoundManager.PlaySound("Jump");
		}


	}
	void OnCollisionEnter2D(Collision2D col)
	{
        if (col.gameObject.tag == "TutorialFinish")
        {
			SceneManager.LoadScene("Lanet");
        }
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
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}
}
