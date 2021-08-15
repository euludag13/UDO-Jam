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
    public Animator Kýzanim;
    public GameObject OliviaKafa;
    public GameObject KöylüKafa;
    public GameObject BüyücüKafa;
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
                BüyücüKafa.SetActive(false);
            }
            else
            {
                OliviaKafa.SetActive(false);
                BüyücüKafa.SetActive(true);
            }
            index++;
            TextDisplay.text = "";
            StartCoroutine(Type());


        }
        else
        {
            anim.SetBool("ýsClose", true);
            Kýzanim.SetBool("Finish", true);
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
                KöylüKafa.SetActive(false);
            }
            else
            {
                OliviaKafa.SetActive(false);
                KöylüKafa.SetActive(true);
            }
            index++;
            TextDisplay.text = "";
            StartCoroutine(Type());


        }
        else
        {
            anim.SetBool("ýsClose", true);
            Kýzanim.SetBool("Finish", true);
            PlayerScript.canMove = true;    
        }
    }
}
