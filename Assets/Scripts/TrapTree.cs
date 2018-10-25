using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTree : MonoBehaviour
{
	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            CharacterSC.Instance().playerHP -= 3;
        }
    }
}
