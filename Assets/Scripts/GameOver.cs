using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject stageObj;
    public GameObject stageObjUi;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            stageObj.SetActive(false);
            stageObjUi.SetActive(false);
            Application.LoadLevel(1);
        }
    }
}
