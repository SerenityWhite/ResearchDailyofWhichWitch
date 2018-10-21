using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSC : MonoBehaviour
{
    public GameObject NamingBox;

	void Start ()
    {
		
	}

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            NamingBox.SetActive(true);
            gameObject.SetActive(false);
        }
	}
}
