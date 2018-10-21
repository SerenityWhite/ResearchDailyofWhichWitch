using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamingBoxSC : MonoBehaviour
{
    public UIInput NamingInput;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void NameSetClick()
    {
        PlayerPrefs.SetString("UserName", NamingInput.value);
        Application.LoadLevel(1);
    }
}
