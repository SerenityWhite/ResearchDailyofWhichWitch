using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSC : MonoBehaviour
{
    public GameObject NamingBox;
    public GameObject ClickSound;

    void Start ()
    {

	}

	void Update ()
    {
        if(!PlayerPrefs.HasKey("UserName"))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                NamingBox.SetActive(true);
                ClickSound.SetActive(true);
                gameObject.SetActive(false);
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Application.LoadLevel(1);
            }
        }
	}
}
