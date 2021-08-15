using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Olivia : MonoBehaviour
{
    private Animator OliviaAnimator;

    private void Start()
    {
        OliviaAnimator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "B�y�")
        {
            Destroy(GameObject.FindGameObjectWithTag("B�y�"));
            OliviaAnimator.SetBool("isFinish", true);
        }
        if (collision.gameObject.tag == "Ma�raGe�i�")
        {
            SceneManager.LoadScene("Ma�raD��me");    
        }
    }
}
