using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    private bool isDead;
    public float height;
    public float height1;
    public Slider HealtBar;
    public GameObject Büyü;

    void Start()
    {

        isDead = false;
        StartCoroutine(BüyüAtma());
        Destroy(Büyü, 5f);
    }
    IEnumerator BüyüAtma()
    {
        while (isDead == false)
        {
            Instantiate(Büyü, new Vector3(16, Random.Range(height, height1) ,0), Quaternion.identity);
            yield return new WaitForSeconds(4);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Büyü")
        {
            Destroy(Büyü);
            HealtBar.value -= 5;

        }
    }
}
