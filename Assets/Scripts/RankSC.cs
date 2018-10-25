using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankSC : MonoBehaviour
{
    public List<UILabel> ClearTime;

    void Start ()
    {

    }
	
	void Update ()
    {
        ClearTime[0].text = "" + PlayerPrefs.GetString("ClearTime01");
        ClearTime[1].text = "" + PlayerPrefs.GetString("ClearTime02");
        ClearTime[2].text = "" + PlayerPrefs.GetString("ClearTime03");
        ClearTime[3].text = "" + PlayerPrefs.GetString("ClearTime04");
        ClearTime[4].text = "" + PlayerPrefs.GetString("ClearTime05");
        ClearTime[5].text = "" + PlayerPrefs.GetString("ClearTime06");
        ClearTime[6].text = "" + PlayerPrefs.GetString("ClearTime07");
        ClearTime[7].text = "" + PlayerPrefs.GetString("ClearTime08");
        ClearTime[8].text = "" + PlayerPrefs.GetString("ClearTime09");
        ClearTime[9].text = "" + PlayerPrefs.GetString("ClearTime10");
    }
}
