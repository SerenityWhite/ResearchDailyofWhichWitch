using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    public GameObject stageObj;
    public GameObject stageObjUi;
    public GameObject result;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            stageObj.SetActive(false);
            stageObjUi.SetActive(false);
            result.SetActive(true);
        }
	}
}
