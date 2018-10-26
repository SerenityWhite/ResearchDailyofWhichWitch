using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringSTList : MonoBehaviour
{
    public GameObject LockStageTX;

    void Update()
    {

    }

    public void Back()
    {
        gameObject.SetActive(false);
    }

    public void LockStageTXClose()
    {
        LockStageTX.SetActive(false);
    }

    public void Stage1UNLOCK()
    {
        playerState.Instance().stageNum = 1;
        PlayerPrefs.SetInt("stageNum", playerState.Instance().stageNum);
        Application.LoadLevel(2);
    }

    public void Stage2UNLOCK()
    {
        if (playerState.Instance().openStageNum < 2)
            LockStageTX.SetActive(true);

        if(playerState.Instance().openStageNum >= 2)
        {
            playerState.Instance().stageNum = 2;
            PlayerPrefs.SetInt("stageNum", playerState.Instance().stageNum);
            Application.LoadLevel(3);
        }
    }

    public void Stage3UNLOCK()
    {
        if (playerState.Instance().openStageNum < 3)
            LockStageTX.SetActive(true);

        if (playerState.Instance().openStageNum >= 3)
        {
            playerState.Instance().stageNum = 3;
            PlayerPrefs.SetInt("stageNum", playerState.Instance().stageNum);
            Application.LoadLevel(4);
        }
    }

    public void Stage4UNLOCK()
    {
        if (playerState.Instance().openStageNum < 4)
            LockStageTX.SetActive(true);

        if (playerState.Instance().openStageNum >= 4)
        {
            playerState.Instance().stageNum = 4;
            PlayerPrefs.SetInt("stageNum", playerState.Instance().stageNum);
            Application.LoadLevel(5);
        }
    }

    public void Stage5UNLOCK()
    {
        if (playerState.Instance().openStageNum < 5)
            LockStageTX.SetActive(true);

        if (playerState.Instance().openStageNum >= 5)
        {
            playerState.Instance().stageNum = 5;
            PlayerPrefs.SetInt("stageNum", playerState.Instance().stageNum);
            Application.LoadLevel(6);
        }
    }
}
