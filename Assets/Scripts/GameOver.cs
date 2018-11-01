using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject stageObj;
    public GameObject stageObjUi;

    void Start ()
    {

	}
	
	void Update ()
    {

    }

    public void RestartClick()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        stageObj.SetActive(false);
        stageObjUi.SetActive(false);
        Application.LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void WorldClick()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        stageObj.SetActive(false);
        stageObjUi.SetActive(false);
        Application.LoadLevel(1);
    }
}
