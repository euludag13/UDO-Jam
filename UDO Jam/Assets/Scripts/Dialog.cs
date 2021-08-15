using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay;
    public PlayerMovement PlayerScript;
    public Animator anim;
    public Animator K�zanim;
    public GameObject OliviaKafa;
    public GameObject K�yl�Kafa;
    public GameObject B�y�c�Kafa;
    public GameObject Bariyer;
    public string[] Sentences;
    public float TypingSpeed;
    private int index;
    public int counter;
    public int SentencesLenght;
    private int kafaCounter;

    private void Start()
    {
        SentencesLenght = Sentences.Length;
        TextDisplay.text = string.Empty;
        StartDialog();
    }
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
           
            if (TextDisplay.text == Sentences[index])
            {
                NextSentence();
                counter++;
            }
            else
            {
                StopAllCoroutines();
                TextDisplay.text = Sentences[index];
            }
        }
    }
    public void StartDialog()
    {
        index = 0;
        StartCoroutine(Type());
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
            kafaCounter++;
            if (kafaCounter % 2 == 0)
            {
                OliviaKafa.SetActive(true);
                B�y�c�Kafa.SetActive(false);
            }
            else
            {
                OliviaKafa.SetActive(false);
                B�y�c�Kafa.SetActive(true);
            }
            index++;
            TextDisplay.text = "";
            StartCoroutine(Type());


        }
        else
        {
            anim.SetBool("�sClose", true);
            K�zanim.SetBool("Finish", true);
            PlayerScript.canMove = true;
        }   
    }
    public void NextSentence()
    {
        if (index < Sentences.Length - 1)
        {
            kafaCounter++;
            if (kafaCounter % 2 == 0)
            {
                OliviaKafa.SetActive(true);
                K�yl�Kafa.SetActive(false);
            }
            else
            {
                OliviaKafa.SetActive(false);
                K�yl�Kafa.SetActive(true);
            }
            index++;
            TextDisplay.text = "";
            StartCoroutine(Type());


        }
        else
        {
            anim.SetBool("�sClose", true);
            K�zanim.SetBool("Finish", true);
            PlayerScript.canMove = true;    
        }
    }
}
