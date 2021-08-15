using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanetDialog : MonoBehaviour
{
    public B�y�Atma B�y�Script;
    public TextMeshProUGUI TextDisplay;
    public Animator anim;
    public Animator B�y�c�Anim;
    public GameObject OliviaKafa;    
    public GameObject B�y�c�Kafa;    
    public string[] Sentences;
    public float TypingSpeed;
    private int index;
    private int counter;


    private void Start()
    {
        StartDialog();
    }
    public void StartDialog()
    {
        index = 0;
        anim.SetBool("IsOpen",true);
        StartCoroutine(Type());
    }
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {

            if (TextDisplay.text == Sentences[index])
            {
                LanetNextSentence();    
            }
            else
            {
                StopAllCoroutines();
                TextDisplay.text = Sentences[index];
                
            }
        }
    }
    
    public IEnumerator Type()
    {
        foreach (char letter in Sentences[index].ToCharArray())
        {
            TextDisplay.text += letter;
            yield return new WaitForSeconds(TypingSpeed);
            ;
        }

    }
    public void LanetNextSentence()
    {
        if (index < Sentences.Length - 1)
        {
            counter++;
            if (counter % 2 == 0)
            {
                OliviaKafa.SetActive(false);
                B�y�c�Kafa.SetActive(true);
            }
            else
            {
                OliviaKafa.SetActive(true);
                B�y�c�Kafa.SetActive(false);
            }
            index++;
            TextDisplay.text = "";
            StartCoroutine(Type());


        }
        else
        {
            anim.SetBool("�sClose", true);
            B�y�c�Anim.SetBool("�sFire", true);
            B�y�Script.Speed += 4;
                
        }
    }
}
