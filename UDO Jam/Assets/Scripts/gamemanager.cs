using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public PlayerMovement PlayerScript;
    public GameObject DeathScreen;
    public GameObject Player;
    void Start()
    {
        
        Time.timeScale = 1;          
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.isDead == true)
        {
            Time.timeScale = 0;
            DeathScreen.SetActive(true);
            //Destroy(Player);
        }
    }
    public void SetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
