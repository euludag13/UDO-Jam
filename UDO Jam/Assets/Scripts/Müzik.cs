using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Müzik : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
