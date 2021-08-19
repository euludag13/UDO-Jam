using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject Credits;
    public void SetGame()
    {      
        SceneManager.LoadScene(1); 
    }
    public void SetCredits()
    {
        Credits.SetActive(true);
        gameObject.SetActive(false);
    }
    public void SetMenu()
    {
        Credits.SetActive(false);
        gameObject.SetActive(true);
    }
    public void SetQuit()
    {
        Application.Quit();
    }
}
