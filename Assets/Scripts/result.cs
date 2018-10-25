﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class result : MonoBehaviour
{
    public UILabel stageName;
    public UILabel timeTX;
    public UILabel goldTX;
    public UILabel springStoneTX;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        stageName.text = StageManager.Instance().stageName;
        timeTX.text = StageManager.Instance().timeStr;
        goldTX.text = "" + StageManager.Instance().plusGold;
        springStoneTX.text = "" + StageManager.Instance().plusSpringStone;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (playerState.Instance().springSTClearBool[0] == 0)
            {
                playerState.Instance().springSTClearBool[0] = 1;
                PlayerPrefs.SetInt("springST01ClearBool", playerState.Instance().springSTClearBool[0]);
            }

            if (playerState.Instance().springSTClearBool[1] == 0)
            {
                playerState.Instance().springSTClearBool[1] = 1;
                PlayerPrefs.SetInt("springST02ClearBool", playerState.Instance().springSTClearBool[1]);
            }

            if (playerState.Instance().springSTClearBool[2] == 0)
            {
                playerState.Instance().springSTClearBool[2] = 1;
                PlayerPrefs.SetInt("springST03ClearBool", playerState.Instance().springSTClearBool[2]);
            }

            if (playerState.Instance().springSTClearBool[3] == 0)
            {
                playerState.Instance().springSTClearBool[3] = 1;
                PlayerPrefs.SetInt("springST04ClearBool", playerState.Instance().springSTClearBool[3]);
            }

            Application.LoadLevel(1);
        }
    }
}