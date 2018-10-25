using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagSC : MonoBehaviour
{
    public List<GameObject> itemBox;
    public GameObject moveBar;
    public GameObject itemEmpty;
    public UILabel HpPotionCount;
    public UILabel MpPotionCount;
    public UILabel GoldCount;
    public UILabel SpringStoneCount;
    public UIGrid itemSlotGrid;

    void Start()
    {
        itemSlotGrid.Reposition();
    }

    void Update()
    {
        if (playerState.Instance().hpPotion >= 1)
        {
            itemBox[0].SetActive(true);
            itemEmpty.SetActive(false);
        }

        if (playerState.Instance().hpPotion == 0)
        {
            itemBox[0].SetActive(false);
        }

        //

        if (playerState.Instance().mpPotion >= 1)
        {
            itemBox[1].SetActive(true);
            itemEmpty.SetActive(false);
        }

        if (playerState.Instance().mpPotion == 0)
        {
            itemBox[1].SetActive(false);
        }

        //

        if(playerState.Instance().hpPotion > playerState.Instance().mpPotion)
        {
            itemBox[0].name = "a";
            itemBox[1].name = "b";
            itemSlotGrid.Reposition();
        }

        if(playerState.Instance().hpPotion < playerState.Instance().mpPotion)
        {
            itemBox[0].name = "b";
            itemBox[1].name = "a";
            itemSlotGrid.Reposition();
        }

        if (playerState.Instance().hpPotion == 0 && playerState.Instance().mpPotion == 0)
        {
            itemEmpty.SetActive(true);
        }

        if (itemBox.Count > 2)
            moveBar.SetActive(true);

        HpPotionCount.text = "" + playerState.Instance().hpPotion;
        MpPotionCount.text = "" + playerState.Instance().mpPotion;
        GoldCount.text = "" + playerState.Instance().gold;
        SpringStoneCount.text = "" + playerState.Instance().springStone;
    }
}