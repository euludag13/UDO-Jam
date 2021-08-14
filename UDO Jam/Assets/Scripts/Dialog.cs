using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay;
    public string[] Sentences;
    public float TypingSpeed;
    private int index;
    private int counter;
    private int SentencesLenght;

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
            if (counter == SentencesLenght + 2)
            {
                SceneManager.LoadScene("MaðraDüþme");
            }
            counter++;
            if (TextDisplay.text == Sentences[index])
            {
                NextSentence();
            }
            else
            {
                StopAllCoroutines();
                TextDisplay.text = Sentences[index];
            }
        }
    }
    void StartDialog()
    {
        index = 0;
        StartCoroutine(Type());
    }
    IEnumerator Type()
    {
        foreach (char letter in Sentences[index].ToCharArray())
        {
            TextDisplay.text += letter;
            yield return new WaitForSeconds(TypingSpeed);
            ;
        }

    }
    public void NextSentence()
    {
        if (index < Sentences.Length - 1)
        {
            index++;
            TextDisplay.text = "";
            StartCoroutine(Type());

        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
