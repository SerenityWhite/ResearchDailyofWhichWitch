using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSC : MonoBehaviour
{
    public GameObject PausePopUp;
    public GameObject OptionPopUp;
    public GameObject EXITPopUp;
    public GameObject WorldPopUp;

    void Start ()
    {
		
	}

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EXITPopUp.SetActive(true);
            PausePopUp.SetActive(false);
            OptionPopUp.SetActive(false);
        }
    }

    public void PauseIconClick()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        Time.timeScale = 0;
        PausePopUp.SetActive(true);
        OptionPopUp.SetActive(false);
    }

    public void PauseReturn()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        Time.timeScale = 1;
        PausePopUp.SetActive(false);
    }

    public void PauseWorld()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        PausePopUp.SetActive(false);
        WorldPopUp.SetActive(true);
    }

    public void PauseOption()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        PausePopUp.SetActive(false);
        OptionPopUp.SetActive(true);
    }

    public void PauseEXIT()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        PausePopUp.SetActive(false);
        EXITPopUp.SetActive(true);
    }

    public void OptionBack()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        OptionPopUp.SetActive(false);
        PausePopUp.SetActive(true);
    }
    
    public void GoWorldYES()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        Application.LoadLevel(1);
    }

    public void GoWorldNo()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        WorldPopUp.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitYes()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        Application.Quit();
    }

    public void ExitNo()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        EXITPopUp.SetActive(false);
        Time.timeScale = 1;
    }
}
