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
        Time.timeScale = 0;
        PausePopUp.SetActive(true);
        OptionPopUp.SetActive(false);
    }

    public void PauseReturn()
    {
        Time.timeScale = 1;
        PausePopUp.SetActive(false);
    }

    public void PauseWorld()
    {
        PausePopUp.SetActive(false);
        WorldPopUp.SetActive(true);
    }

    public void PauseOption()
    {
        PausePopUp.SetActive(false);
        OptionPopUp.SetActive(true);
    }

    public void PauseEXIT()
    {
        PausePopUp.SetActive(false);
        EXITPopUp.SetActive(true);
    }

    public void OptionBack()
    {
        OptionPopUp.SetActive(false);
        PausePopUp.SetActive(true);
    }
    
    public void GoWorldYES()
    {
        Application.LoadLevel(1);
    }

    public void GoWorldNo()
    {
        WorldPopUp.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitYes()
    {
        Application.Quit();
    }

    public void ExitNo()
    {
        EXITPopUp.SetActive(false);
        Time.timeScale = 1;
    }
}
