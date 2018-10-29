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
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        gameObject.SetActive(false);
    }

    public void LockStageTXClose()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        LockStageTX.SetActive(false);
    }

    public void Stage1UNLOCK()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().StageOpen;
        SoundSC.Instance().Sound.Play();
        playerState.Instance().stageNum = 1;
        PlayerPrefs.SetInt("stageNum", playerState.Instance().stageNum);
        Application.LoadLevel(2);
    }

    public void Stage2UNLOCK()
    {
        if (playerState.Instance().openStageNum < 2)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
            SoundSC.Instance().Sound.Play();
            LockStageTX.SetActive(true);
        }

        if(playerState.Instance().openStageNum >= 2)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().StageOpen;
            SoundSC.Instance().Sound.Play();
            playerState.Instance().stageNum = 2;
            PlayerPrefs.SetInt("stageNum", playerState.Instance().stageNum);
            Application.LoadLevel(3);
        }
    }

    public void Stage3UNLOCK()
    {
        if (playerState.Instance().openStageNum < 3)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
            SoundSC.Instance().Sound.Play();
            LockStageTX.SetActive(true);
        }

        if (playerState.Instance().openStageNum >= 3)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().StageOpen;
            SoundSC.Instance().Sound.Play();
            playerState.Instance().stageNum = 3;
            PlayerPrefs.SetInt("stageNum", playerState.Instance().stageNum);
            Application.LoadLevel(4);
        }
    }

    public void Stage4UNLOCK()
    {
        if (playerState.Instance().openStageNum < 4)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
            SoundSC.Instance().Sound.Play();
            LockStageTX.SetActive(true);
        }

        if (playerState.Instance().openStageNum >= 4)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().StageOpen;
            SoundSC.Instance().Sound.Play();
            playerState.Instance().stageNum = 4;
            PlayerPrefs.SetInt("stageNum", playerState.Instance().stageNum);
            Application.LoadLevel(5);
        }
    }

    public void Stage5UNLOCK()
    {
        if (playerState.Instance().openStageNum < 5)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
            SoundSC.Instance().Sound.Play();
            LockStageTX.SetActive(true);
        }

        if (playerState.Instance().openStageNum >= 5)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().StageOpen;
            SoundSC.Instance().Sound.Play();
            playerState.Instance().stageNum = 5;
            PlayerPrefs.SetInt("stageNum", playerState.Instance().stageNum);
            Application.LoadLevel(6);
        }
    }

    public void Stage6UNLOCK()
    {
        if (playerState.Instance().openStageNum < 6)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
            SoundSC.Instance().Sound.Play();
            LockStageTX.SetActive(true);
        }

        if (playerState.Instance().openStageNum >= 6)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().StageOpen;
            SoundSC.Instance().Sound.Play();
            playerState.Instance().stageNum = 6;
            PlayerPrefs.SetInt("stageNum", playerState.Instance().stageNum);
            Application.LoadLevel(7);
        }
    }

    public void Stage7UNLOCK()
    {
        if (playerState.Instance().openStageNum < 7)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
            SoundSC.Instance().Sound.Play();
            LockStageTX.SetActive(true);
        }

        if (playerState.Instance().openStageNum >= 7)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().StageOpen;
            SoundSC.Instance().Sound.Play();
            playerState.Instance().stageNum = 7;
            PlayerPrefs.SetInt("stageNum", playerState.Instance().stageNum);
            Application.LoadLevel(8);
        }
    }

    public void Stage8UNLOCK()
    {
        if (playerState.Instance().openStageNum < 8)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
            SoundSC.Instance().Sound.Play();
            LockStageTX.SetActive(true);
        }

        if (playerState.Instance().openStageNum >= 8)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().StageOpen;
            SoundSC.Instance().Sound.Play();
            playerState.Instance().stageNum = 8;
            PlayerPrefs.SetInt("stageNum", playerState.Instance().stageNum);
            Application.LoadLevel(9);
        }
    }

    public void Stage9UNLOCK()
    {
        if (playerState.Instance().openStageNum < 9)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
            SoundSC.Instance().Sound.Play();
            LockStageTX.SetActive(true);
        }

        if (playerState.Instance().openStageNum >= 9)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().StageOpen;
            SoundSC.Instance().Sound.Play();
            playerState.Instance().stageNum = 9;
            PlayerPrefs.SetInt("stageNum", playerState.Instance().stageNum);
            Application.LoadLevel(10);
        }
    }

    public void Stage10UNLOCK()
    {
        if (playerState.Instance().openStageNum < 10)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
            SoundSC.Instance().Sound.Play();
            LockStageTX.SetActive(true);
        }

        if (playerState.Instance().openStageNum >= 10)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().StageOpen;
            SoundSC.Instance().Sound.Play();
            playerState.Instance().stageNum = 10;
            PlayerPrefs.SetInt("stageNum", playerState.Instance().stageNum);
            Application.LoadLevel(11);
        }
    }
}
