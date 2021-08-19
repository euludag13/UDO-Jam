using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubukGelme : MonoBehaviour
{
    public float BarierSpeed;

    void FixedUpdate()
    {
        transform.position += Vector3.right * BarierSpeed * Time.deltaTime;
        
    }
}
