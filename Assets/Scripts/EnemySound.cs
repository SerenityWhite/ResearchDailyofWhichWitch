using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    static EnemySound _instance = null;
    public static EnemySound Instance()
    {
        return _instance;
    }
    public AudioSource enemySound;
    public AudioClip EnemyAttack;
    public AudioClip EnemyHit;

    void Start ()
    {
        if (_instance == null)
            _instance = this;

        enemySound = GetComponent<AudioSource>();
    }

	void Update ()
    {
		
	}
}
