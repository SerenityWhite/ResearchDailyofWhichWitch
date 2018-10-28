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
            SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
            SoundSC.Instance().Sound.Play();
            stageObj.SetActive(false);
            stageObjUi.SetActive(false);
            result.SetActive(true);
        }
	}
}
