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
        if (collision.gameObject.tag == "Büyü")
        {
            Destroy(GameObject.FindGameObjectWithTag("Büyü"));
            OliviaAnimator.SetBool("isFinish", true);
        }
        if (collision.gameObject.tag == "MaðraGeçiþ")
        {
            SceneManager.LoadScene("MaðraDüþme");    
        }
    }
}
