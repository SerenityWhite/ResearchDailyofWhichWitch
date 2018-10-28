using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSC : MonoBehaviour
{
    static SoundSC _instance = null;
    public static SoundSC Instance()
    {
        return _instance;
    }
    public AudioSource Sound;
    public AudioClip Jump;
    public AudioClip Attack;
    public AudioClip Click;
    public AudioClip ShopOpen;
    public AudioClip StageOpen;

    void Start ()
    {
        if (_instance == null)
            _instance = this;

        Sound = GetComponent<AudioSource>();
    }
	
	void Update ()
    {

    }
}
