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
    public GameObject B�y�;

    void Start()
    {

        isDead = false;
        StartCoroutine(B�y�Atma());
        Destroy(B�y�, 5f);
    }
    IEnumerator B�y�Atma()
    {
        while (isDead == false)
        {
            Instantiate(B�y�, new Vector3(16, Random.Range(height, height1) ,0), Quaternion.identity);
            yield return new WaitForSeconds(4);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "B�y�")
        {
            Destroy(B�y�);
            HealtBar.value -= 5;

        }
    }
}
