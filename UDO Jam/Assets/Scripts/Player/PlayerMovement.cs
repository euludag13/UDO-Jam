using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class PlayerMovement : MonoBehaviour {

	public Dialog dialog;
	public CharacterController2D controller;
	public CubukGelme CubukScript;
	public GameObject Boss;
	public SoundManager SoundManager;
	public BossControl BossScript;
	public Animator animator;
	public bool isDead;
	public bool isGround;
	public bool canMove;
	public float runSpeed = 40f;
	public bool canMoveBool;

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
        else if (BossScript.HealtBar.value == 0)
        {

			Destroy(Boss);
			canMove = false;
			animator.SetBool("ýsFnish", true);			
			CubukScript.BarierSpeed = 4;
			SceneManager.LoadScene("FinalScene");

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
        if (col.gameObject.tag == "BossBariyer")
        {
			animator.SetBool("IsCol",true);
        }
        if (col.gameObject.tag == "2.Bölüm")
        {

			SceneManager.LoadScene("2");
		}
		if (col.gameObject.tag == "BossOdasý")
		{

			SceneManager.LoadScene("BüyücüBoss");
		}
        if (col.gameObject.tag == "Bitiþ")
        {
			SceneManager.LoadScene("FinialScene");
        }



	}

	public void OnLanding ()
	{
        if (isDead == false)
        {
			animator.SetBool("IsJumping", false);
		}
	}
	public void CantMove()
	{
		canMoveBool = false;
		
	}
	public void CanMove()
	{
		canMoveBool = true;

		

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
