using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    static StageManager _instance = null;
    public static StageManager Instance()
    {
        return _instance;
    }
    public string stageName;
    public int stageNum;
    public UILabel stageNameObj;

    public float playTime;
    public float lastPlayTime;
    public string timeStr;
    public int min;
    public int sec;
    public UILabel timeTX;

    public int deadEnemy;
    public int maxEnemy;
    public UILabel enemyNumTX;
    public bool enemyClear = false;
    public bool goal = false;
    public GameObject clearTX;
    public GameObject enemyNone;
    public int plusGold;
    public int plusSpringStone;
    public UILabel hpPotionCount;
    public UILabel mpPotionCount;
    public GameObject gameOverTX;

    public enum CLEARSTATE
    {
        NONCLEAR = 0,
        IDLE,
        CLEAR,
        GAMEOVER
    }
    public CLEARSTATE clearState;

	void Start ()
    {
        Time.timeScale = 1;

        if (_instance == null)
            _instance = this;

        stageNum = playerState.Instance().stageNum;

        if (stageNum == 1)
        {
            stageName = "생명의 숲1";
            lastPlayTime = PlayerPrefs.GetFloat("playTime01");
        }

        if (stageNum == 2)
        {
            stageName = "생명의 숲2";
            lastPlayTime = PlayerPrefs.GetFloat("playTime02");
        }

        if (stageNum == 3)
        {
            stageName = "생명의 숲3";
            lastPlayTime = PlayerPrefs.GetFloat("playTime03");
        }

        if (stageNum == 4)
        {
            stageName = "생명의 숲4";
            lastPlayTime = PlayerPrefs.GetFloat("playTime04");
        }

        if (stageNum == 5)
        {
            stageName = "생명의 숲5";
            lastPlayTime = PlayerPrefs.GetFloat("playTime05");
        }

        if (stageNum == 6)
        {
            stageName = "생명의 숲6";
            lastPlayTime = PlayerPrefs.GetFloat("playTime06");
        }

        if (stageNum == 7)
        {
            stageName = "생명의 숲7";
            lastPlayTime = PlayerPrefs.GetFloat("playTime07");
        }

        if (stageNum == 8)
        {
            stageName = "생명의 숲8";
            lastPlayTime = PlayerPrefs.GetFloat("playTime08");
        }

        if (stageNum == 9)
        {
            stageName = "생명의 숲9";
            lastPlayTime = PlayerPrefs.GetFloat("playTime09");
        }

        if (stageNum == 10)
        {
            stageName = "생명의 숲10";
            lastPlayTime = PlayerPrefs.GetFloat("playTime10");
        }

        stageNameObj.text = stageName;
    }
	
	void Update ()
    {
        playTime += Time.deltaTime;
        min = (int)playTime / 60;
        sec = (int)playTime % 60;
        timeStr = min.ToString("00") + " : " + sec.ToString("00");

        timeTX.text = timeStr;
        enemyNumTX.text = "Enemy " + deadEnemy + " / " + maxEnemy;
        hpPotionCount.text = "" + playerState.Instance().hpPotion;
        mpPotionCount.text = "" + playerState.Instance().mpPotion;


        if (deadEnemy == maxEnemy)
        {
            enemyNumTX.color = Color.red;
            enemyClear = true;
        }

        if (goal == false)
        {
            enemyNone.SetActive(false);
        }

        switch (clearState)
        {
            case CLEARSTATE.NONCLEAR:
                if (goal == true)
                {
                    if (enemyClear == false)
                    {
                        enemyNone.SetActive(true);
                    }

                    if (enemyClear == true)
                    {
                        clearState = CLEARSTATE.CLEAR;
                    }
                }

                if (CharacterSC.Instance().playerHP <= 0)
                    clearState = CLEARSTATE.GAMEOVER;

                        break;
            case CLEARSTATE.IDLE:
                break;
            case CLEARSTATE.CLEAR:
                clearTX.SetActive(true);
                Time.timeScale = 0;

                if (playerState.Instance().stageNum == 1)
                {
                    if (playerState.Instance().springSTClearBool[0] == 0)
                    {
                        playerState.Instance().openStageNum = 2;
                        PlayerPrefs.SetInt("openStageNum", playerState.Instance().openStageNum);
                        plusGold = 1000;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(1, 5);
                        playerState.Instance().springStone += plusSpringStone;
                        PlayerPrefs.SetFloat("playTime01", playTime);
                        PlayerPrefs.SetString("ClearTime01", timeStr);
                    }

                    if (playerState.Instance().springSTClearBool[0] == 1)
                    {
                        plusGold = 1000;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(1, 5);
                        playerState.Instance().springStone += plusSpringStone;
                        if (lastPlayTime > playTime)
                        {
                            PlayerPrefs.SetFloat("playTime01", playTime);
                            PlayerPrefs.SetString("ClearTime01", timeStr);
                        }
                    }
                }

                if (playerState.Instance().stageNum == 2)
                {
                    if (playerState.Instance().springSTClearBool[1] == 0)
                    {
                        playerState.Instance().openStageNum = 3;
                        PlayerPrefs.SetInt("openStageNum", playerState.Instance().openStageNum);
                        plusGold = 1500;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(1, 6);
                        playerState.Instance().springStone += plusSpringStone;
                        PlayerPrefs.SetFloat("playTime02", playTime);
                        PlayerPrefs.SetString("ClearTime02", timeStr);
                    }

                    if (playerState.Instance().springSTClearBool[1] == 1)
                    {
                        plusGold = 1500;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(1, 6);
                        playerState.Instance().springStone += plusSpringStone;
                        if (lastPlayTime > playTime)
                        {
                            PlayerPrefs.SetFloat("playTime02", playTime);
                            PlayerPrefs.SetString("ClearTime02", timeStr);
                        }
                    }
                }

                if (playerState.Instance().stageNum == 3)
                {
                    if (playerState.Instance().springSTClearBool[2] == 0)
                    {
                        playerState.Instance().openStageNum = 4;
                        PlayerPrefs.SetInt("openStageNum", playerState.Instance().openStageNum);
                        plusGold = 2000;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(1, 7);
                        playerState.Instance().springStone += plusSpringStone;
                        PlayerPrefs.SetFloat("playTime03", playTime);
                        PlayerPrefs.SetString("ClearTime03", timeStr);
                    }

                    if (playerState.Instance().springSTClearBool[2] == 1)
                    {
                        plusGold = 2000;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(1, 7);
                        playerState.Instance().springStone += plusSpringStone;
                        if (lastPlayTime > playTime)
                        {
                            PlayerPrefs.SetFloat("playTime03", playTime);
                            PlayerPrefs.SetString("ClearTime03", timeStr);
                        }
                    }
                }

                if (playerState.Instance().stageNum == 4)
                {
                    if (playerState.Instance().springSTClearBool[3] == 0)
                    {
                        playerState.Instance().openStageNum = 5;
                        PlayerPrefs.SetInt("openStageNum", playerState.Instance().openStageNum);
                        plusGold = 2500;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(1, 8);
                        playerState.Instance().springStone += plusSpringStone;
                        PlayerPrefs.SetFloat("playTime04", playTime);
                        PlayerPrefs.SetString("ClearTime04", timeStr);
                    }

                    if (playerState.Instance().springSTClearBool[3] == 1)
                    {
                        plusGold = 2500;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(1, 8);
                        playerState.Instance().springStone += plusSpringStone;
                        if (lastPlayTime > playTime)
                        {
                            PlayerPrefs.SetFloat("playTime04", playTime);
                            PlayerPrefs.SetString("ClearTime04", timeStr);
                        }
                    }
                }

                if (playerState.Instance().stageNum == 5)
                {
                    if (playerState.Instance().springSTClearBool[4] == 0)
                    {
                        playerState.Instance().openStageNum = 6;
                        PlayerPrefs.SetInt("openStageNum", playerState.Instance().openStageNum);
                        plusGold = 3000;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(1, 9);
                        playerState.Instance().springStone += plusSpringStone;
                        PlayerPrefs.SetFloat("playTime05", playTime);
                        PlayerPrefs.SetString("ClearTime05", timeStr);
                    }

                    if (playerState.Instance().springSTClearBool[4] == 1)
                    {
                        plusGold = 3000;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(1, 9);
                        playerState.Instance().springStone += plusSpringStone;
                        if (lastPlayTime > playTime)
                        {
                            PlayerPrefs.SetFloat("playTime05", playTime);
                            PlayerPrefs.SetString("ClearTime05", timeStr);
                        }
                    }
                }

                if (playerState.Instance().stageNum == 6)
                {
                    if (playerState.Instance().springSTClearBool[5] == 0)
                    {
                        playerState.Instance().openStageNum = 7;
                        PlayerPrefs.SetInt("openStageNum", playerState.Instance().openStageNum);
                        plusGold = 4000;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(2, 6);
                        playerState.Instance().springStone += plusSpringStone;
                        PlayerPrefs.SetFloat("playTime06", playTime);
                        PlayerPrefs.SetString("ClearTime06", timeStr);
                    }

                    if (playerState.Instance().springSTClearBool[5] == 1)
                    {
                        plusGold = 4000;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(2, 6);
                        playerState.Instance().springStone += plusSpringStone;
                        if (lastPlayTime > playTime)
                        {
                            PlayerPrefs.SetFloat("playTime06", playTime);
                            PlayerPrefs.SetString("ClearTime06", timeStr);
                        }
                    }
                }

                if (playerState.Instance().stageNum == 7)
                {
                    if (playerState.Instance().springSTClearBool[6] == 0)
                    {
                        playerState.Instance().openStageNum = 8;
                        PlayerPrefs.SetInt("openStageNum", playerState.Instance().openStageNum);
                        plusGold = 4500;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(2, 7);
                        playerState.Instance().springStone += plusSpringStone;
                        PlayerPrefs.SetFloat("playTime07", playTime);
                        PlayerPrefs.SetString("ClearTime07", timeStr);
                    }

                    if (playerState.Instance().springSTClearBool[6] == 1)
                    {
                        plusGold = 4500;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(2, 7);
                        playerState.Instance().springStone += plusSpringStone;
                        if (lastPlayTime > playTime)
                        {
                            PlayerPrefs.SetFloat("playTime07", playTime);
                            PlayerPrefs.SetString("ClearTime07", timeStr);
                        }
                    }
                }

                if (playerState.Instance().stageNum == 8)
                {
                    if (playerState.Instance().springSTClearBool[7] == 0)
                    {
                        playerState.Instance().openStageNum = 9;
                        PlayerPrefs.SetInt("openStageNum", playerState.Instance().openStageNum);
                        plusGold = 5000;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(2, 8);
                        playerState.Instance().springStone += plusSpringStone;
                        PlayerPrefs.SetFloat("playTime08", playTime);
                        PlayerPrefs.SetString("ClearTime08", timeStr);
                    }

                    if (playerState.Instance().springSTClearBool[7] == 1)
                    {
                        plusGold = 5000;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(2, 8);
                        playerState.Instance().springStone += plusSpringStone;
                        if (lastPlayTime > playTime)
                        {
                            PlayerPrefs.SetFloat("playTime08", playTime);
                            PlayerPrefs.SetString("ClearTime08", timeStr);
                        }
                    }
                }

                if (playerState.Instance().stageNum == 9)
                {
                    if (playerState.Instance().springSTClearBool[8] == 0)
                    {
                        playerState.Instance().openStageNum = 10;
                        PlayerPrefs.SetInt("openStageNum", playerState.Instance().openStageNum);
                        plusGold = 5500;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(2, 9);
                        playerState.Instance().springStone += plusSpringStone;
                        PlayerPrefs.SetFloat("playTime09", playTime);
                        PlayerPrefs.SetString("ClearTime09", timeStr);
                    }

                    if (playerState.Instance().springSTClearBool[8] == 1)
                    {
                        plusGold = 5500;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(2, 9);
                        playerState.Instance().springStone += plusSpringStone;
                        if (lastPlayTime > playTime)
                        {
                            PlayerPrefs.SetFloat("playTime09", playTime);
                            PlayerPrefs.SetString("ClearTime09", timeStr);
                        }
                    }
                }

                if (playerState.Instance().stageNum == 10)
                {
                    if (playerState.Instance().springSTClearBool[9] == 0)
                    {
                        plusGold = 7000;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(4, 9);
                        playerState.Instance().springStone += plusSpringStone;
                        PlayerPrefs.SetFloat("playTime10", playTime);
                        PlayerPrefs.SetString("ClearTime10", timeStr);
                    }

                    if (playerState.Instance().springSTClearBool[9] == 1)
                    {
                        plusGold = 7000;
                        playerState.Instance().gold += plusGold;
                        plusSpringStone = Random.Range(4, 9);
                        playerState.Instance().springStone += plusSpringStone;
                        if (lastPlayTime > playTime)
                        {
                            PlayerPrefs.SetFloat("playTime10", playTime);
                            PlayerPrefs.SetString("ClearTime10", timeStr);
                        }
                    }
                }

                clearState = CLEARSTATE.IDLE;
                break;

            case CLEARSTATE.GAMEOVER:
                gameOverTX.SetActive(true);
                Time.timeScale = 0;
                clearState = CLEARSTATE.IDLE;
                break;
        }

        PlayerPrefs.SetInt("hpPotion", playerState.Instance().hpPotion);
        PlayerPrefs.SetInt("mpPotion", playerState.Instance().mpPotion);
        PlayerPrefs.SetInt("gold", playerState.Instance().gold);
        PlayerPrefs.SetInt("springStone", playerState.Instance().springStone);
    }
}
