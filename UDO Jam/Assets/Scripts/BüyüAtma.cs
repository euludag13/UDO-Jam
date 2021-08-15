using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BüyüAtma : MonoBehaviour
{
    public float Speed;
    public Animator Oliva;

    public void FixedUpdate()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
    }
}
