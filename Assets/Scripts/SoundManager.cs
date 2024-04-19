using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {get; set;}

    public AudioSource shootingSound;

    public AudioClip zombieChase;
    public AudioClip zombieWalk;
    //public AudioClip zombieAttack;
    public AudioClip zombieDeath;
    public AudioClip zombieHurt;

    public AudioSource zombieChannel;
    public AudioSource zombieChannel2;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
