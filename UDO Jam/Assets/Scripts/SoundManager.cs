using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound;
    static AudioSource audioSrc;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject.transform);
    }
    void Start()
    {
        jumpSound = Resources.Load<AudioClip> ("Jump");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
        }
    }
}
