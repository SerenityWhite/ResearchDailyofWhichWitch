using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState : MonoBehaviour
{
    static playerState _instance = null;
    public static playerState Instance()
    {
        return _instance;
    }

    public int hpPotion;
    public int mpPotion;
    public int gold;
    public int springStone;
    public int stageNum;
    public int openStageNum;
    public List<int> springSTClearBool;

    void Start ()
    {
        if (_instance == null)
            _instance = this;

        hpPotion = PlayerPrefs.GetInt("hpPotion");
        mpPotion = PlayerPrefs.GetInt("mpPotion");
        gold = PlayerPrefs.GetInt("gold");
        springStone = PlayerPrefs.GetInt("springStone");
        stageNum = PlayerPrefs.GetInt("stageNum");
        openStageNum = PlayerPrefs.GetInt("openStageNum");
        springSTClearBool[0] = PlayerPrefs.GetInt("springST01ClearBool");
        springSTClearBool[1] = PlayerPrefs.GetInt("springST02ClearBool");
        springSTClearBool[2] = PlayerPrefs.GetInt("springST03ClearBool");
        springSTClearBool[3] = PlayerPrefs.GetInt("springST04ClearBool");
        springSTClearBool[4] = PlayerPrefs.GetInt("springST05ClearBool");
        springSTClearBool[5] = PlayerPrefs.GetInt("springST06ClearBool");
        springSTClearBool[6] = PlayerPrefs.GetInt("springST07ClearBool");
        springSTClearBool[7] = PlayerPrefs.GetInt("springST08ClearBool");
        springSTClearBool[8] = PlayerPrefs.GetInt("springST09ClearBool");
        springSTClearBool[9] = PlayerPrefs.GetInt("springST10ClearBool");
    }

	void Update ()
    {
        if (hpPotion < 0)
            hpPotion = 0;

        if (mpPotion < 0)
            mpPotion = 0;

        if (gold < 0)
            gold = 0;

        if (springStone < 0)
            springStone = 0;
    }
}
