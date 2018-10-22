using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSC : MonoBehaviour
{
    public float moveSpeed;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Translate(moveSpeed, 0, 0);
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
