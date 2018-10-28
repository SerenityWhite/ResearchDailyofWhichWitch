using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamingBoxSC : MonoBehaviour
{
    public UIInput NamingInput;
    public GameObject ClickSound;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void NameSetClick()
    {
        ClickSound.SetActive(true);
        PlayerPrefs.SetString("UserName", NamingInput.value);
        Application.LoadLevel(1);
    }
}
