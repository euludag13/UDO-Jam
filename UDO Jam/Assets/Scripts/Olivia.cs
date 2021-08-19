using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Olivia : MonoBehaviour
{
    private Animator OliviaAnimator;
    public CubukGelme CubukScript;

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
            CubukScript.BarierSpeed = 1f;
        }
        if (collision.gameObject.tag == "MaðraGeçiþ")
        {
            SceneManager.LoadScene("MaðraDüþme");    
        }
    }
}
