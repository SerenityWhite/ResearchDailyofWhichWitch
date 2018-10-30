using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class result : MonoBehaviour
{
    public UILabel stageName;
    public UILabel timeTX;
    public UILabel goldTX;
    public UILabel springStoneTX;
    public int stageNum;

    void Start ()
    {
        stageNum = StageManager.Instance().stageNum;
	}
	
	void Update ()
    {
        stageName.text = StageManager.Instance().stageName;
        timeTX.text = StageManager.Instance().timeStr;
        goldTX.text = "" + StageManager.Instance().plusGold;
        springStoneTX.text = "" + StageManager.Instance().plusSpringStone;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (playerState.Instance().springSTClearBool[0] == 0 && stageNum == 1)
            {
                playerState.Instance().springSTClearBool[0] = 1;
                PlayerPrefs.SetInt("springST01ClearBool", playerState.Instance().springSTClearBool[0]);
            }

            if (playerState.Instance().springSTClearBool[1] == 0 && stageNum == 2)
            {
                playerState.Instance().springSTClearBool[1] = 1;
                PlayerPrefs.SetInt("springST02ClearBool", playerState.Instance().springSTClearBool[1]);
            }

            if (playerState.Instance().springSTClearBool[2] == 0 && stageNum == 3)
            {
                playerState.Instance().springSTClearBool[2] = 1;
                PlayerPrefs.SetInt("springST03ClearBool", playerState.Instance().springSTClearBool[2]);
            }

            if (playerState.Instance().springSTClearBool[3] == 0 && stageNum == 4)
            {
                playerState.Instance().springSTClearBool[3] = 1;
                PlayerPrefs.SetInt("springST04ClearBool", playerState.Instance().springSTClearBool[3]);
            }

            if (playerState.Instance().springSTClearBool[4] == 0 && stageNum == 5)
            {
                playerState.Instance().springSTClearBool[4] = 1;
                PlayerPrefs.SetInt("springST05ClearBool", playerState.Instance().springSTClearBool[4]);
            }

            if (playerState.Instance().springSTClearBool[5] == 0 && stageNum == 6)
            {
                playerState.Instance().springSTClearBool[5] = 1;
                PlayerPrefs.SetInt("springST06ClearBool", playerState.Instance().springSTClearBool[5]);
            }

            if (playerState.Instance().springSTClearBool[6] == 0 && stageNum == 7)
            {
                playerState.Instance().springSTClearBool[6] = 1;
                PlayerPrefs.SetInt("springST07ClearBool", playerState.Instance().springSTClearBool[6]);
            }

            if (playerState.Instance().springSTClearBool[7] == 0 && stageNum == 8)
            {
                playerState.Instance().springSTClearBool[7] = 1;
                PlayerPrefs.SetInt("springST08ClearBool", playerState.Instance().springSTClearBool[7]);
            }

            if (playerState.Instance().springSTClearBool[8] == 0 && stageNum == 9)
            {
                playerState.Instance().springSTClearBool[8] = 1;
                PlayerPrefs.SetInt("springST09ClearBool", playerState.Instance().springSTClearBool[8]);
            }

            if (playerState.Instance().springSTClearBool[9] == 0 && stageNum == 10)
            {
                playerState.Instance().springSTClearBool[9] = 1;
                PlayerPrefs.SetInt("springST10ClearBool", playerState.Instance().springSTClearBool[9]);
            }

            SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
            SoundSC.Instance().Sound.Play();
            Application.LoadLevel(1);
        }
    }
}
