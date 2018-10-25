using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSC : MonoBehaviour
{
    public GameObject main;
    public GameObject inventory;
    public GameObject MenuBox;
    public GameObject BuyList;
    public GameObject SellList;
    public GameObject Rank;
    public UILabel ItemIntroTX;
    public List<GameObject> itemBuy;
    public List<GameObject> itemSell;

    void Start ()
    {
        ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님, 공방에서 뵙는 건 꽤 오랜만인 것 같네요. 이번엔 뭐가 필요하시죠?";
    }

	void Update ()
    {

    }
    
    public void RankOn()
    {
        Rank.SetActive(true);
        MenuBox.SetActive(false);
        ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님, 최단 시간 정복! 한 번 도전해보는 건 어떨까요?";
    }

    public void RankOff()
    {
        Rank.SetActive(false);
        MenuBox.SetActive(true);
    }

    public void IventoryOn()
    {
        inventory.SetActive(true);
        main.SetActive(false);
    }

    public void IventoryOff()
    {
        inventory.SetActive(false);
        main.SetActive(true);
    }

    public void BuyOn()
    {
        BuyList.SetActive(true);
        MenuBox.SetActive(false);
        ItemIntroTX.text = "자, 어떤 걸 만들어볼까요?";
    }

    public void BuyBack()
    {
        BuyList.SetActive(false);
        MenuBox.SetActive(true);
        itemBuy[0].SetActive(false);
        itemBuy[1].SetActive(false);
        ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님, 연금술을 소홀히 하시면 실력이 늘지 않습니다.";
    }

    public void SellOn()
    {
        SellList.SetActive(true);
        MenuBox.SetActive(false);
        ItemIntroTX.text = "이번엔 어떤 것을 가져오셨습니까?";
    }

    public void SellBack()
    {
        SellList.SetActive(false);
        MenuBox.SetActive(true);
        itemSell[0].SetActive(false);
        itemSell[1].SetActive(false);
        ItemIntroTX.text = "더 열심히 해서 부자가 되어 보자고요.";
    }


    //Buy로직
    public void HpPotionClick()
    {
        if(playerState.Instance().gold >= 1000)
        {
            ItemIntroTX.text = "현재 " + PlayerPrefs.GetString("UserName") + "님이 보유한 골드는 " + playerState.Instance().gold + "이므로, HP 회복약의 합성이 가능합니다. 합성하시겠습니까?";
            itemBuy[0].SetActive(true);
            itemBuy[1].SetActive(false);
        }

        if (playerState.Instance().gold < 1000)
        {
            ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님, HP 회복약을 합성하기엔 가지고 계신 골드가 부족한 것 같아요. 지금 " + PlayerPrefs.GetString("UserName") + "님이 가진 골드는 " + playerState.Instance().gold + "입니다.";
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(false);
        }
    }

    public void HpPotionClickBuy()
    {
        if(playerState.Instance().gold >= 1000)
        {
            itemBuy[0].SetActive(false);
            playerState.Instance().gold -= 1000;
            playerState.Instance().hpPotion += 1;
            ItemIntroTX.text = "HP 회복약 1개 합성 성공입니다.";
            PlayerPrefs.SetInt("gold", playerState.Instance().gold);
            PlayerPrefs.SetInt("hpPotion", playerState.Instance().hpPotion);
        }

        if(playerState.Instance().gold < 1000)
        {
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(false);
        }
    }

    public void MpPotionClick()
    {
        if (playerState.Instance().gold >= 700)
        {
            ItemIntroTX.text = "현재 " + PlayerPrefs.GetString("UserName") + "님이 보유한 골드는 " + playerState.Instance().gold + "이므로, MP 회복약의 합성이 가능합니다. 합성하시겠습니까?";
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(true);
        }

        if (playerState.Instance().gold < 700)
        {
            ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님, MP 회복약을 합성하기엔 가지고 계신 골드가 부족한 것 같아요. 지금 " + PlayerPrefs.GetString("UserName") + "님이 가진 골드는 " + playerState.Instance().gold + "입니다.";
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(false);
        }
    }

    public void MpPotionClickBuy()
    {
        if (playerState.Instance().gold >= 700)
        {
            itemBuy[1].SetActive(false);
            playerState.Instance().gold -= 700;
            playerState.Instance().mpPotion += 1;
            ItemIntroTX.text = "MP 회복약 1개 합성 성공입니다.";
            PlayerPrefs.SetInt("gold", playerState.Instance().gold);
            PlayerPrefs.SetInt("mpPotion", playerState.Instance().mpPotion);
        }

        if (playerState.Instance().gold < 700)
        {
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(false);
        }
    }

    //Sell로직
    public void HpPotionSellClick()
    {
        if(playerState.Instance().hpPotion >= 1)
        {
            ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님이 가지고 계신 HP 회복약을 분해해서 골드로 만들 수 있어요. 200골드를 얻을 수 있습니다. 분해하시겠습니까?";
            itemSell[0].SetActive(true);
            itemSell[1].SetActive(false);
        }

        if(playerState.Instance().hpPotion < 1)
        {
            ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님, 분해할 HP 회복약이 없네요.";
            itemSell[0].SetActive(false);
            itemSell[1].SetActive(false);
        }
    }

    public void HpPotionClickSell()
    {
        if(playerState.Instance().hpPotion >= 1)
        {
            itemSell[0].SetActive(false);
            playerState.Instance().gold += 200;
            playerState.Instance().hpPotion -= 1;
            ItemIntroTX.text = "HP 회복약 1개를 분해해서 200골드를 얻었습니다.";
            PlayerPrefs.SetInt("gold", playerState.Instance().gold);
            PlayerPrefs.SetInt("hpPotion", playerState.Instance().hpPotion);
        }

        if (playerState.Instance().hpPotion < 1)
        {
            itemSell[0].SetActive(false);
            itemSell[1].SetActive(false);
        }
    }

    public void MpPotionSellClick()
    {
        if (playerState.Instance().mpPotion >= 1)
        {
            ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님이 가지고 계신 MP 회복약을 분해해서 골드로 만들 수 있어요. 100골드를 얻을 수 있습니다. 분해하시겠습니까?";
            itemSell[0].SetActive(false);
            itemSell[1].SetActive(true);
        }

        if (playerState.Instance().mpPotion < 1)
        {
            ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님, 분해할 MP 회복약이 없네요.";
            itemSell[0].SetActive(false);
            itemSell[1].SetActive(false);
        }
    }

    public void MpPotionClickSell()
    {
        if (playerState.Instance().mpPotion >= 1)
        {
            itemSell[1].SetActive(false);
            playerState.Instance().gold += 100;
            playerState.Instance().mpPotion -= 1;
            ItemIntroTX.text = "MP 회복약 1개를 분해해서 100골드를 얻었습니다.";
            PlayerPrefs.SetInt("gold", playerState.Instance().gold);
            PlayerPrefs.SetInt("mpPotion", playerState.Instance().mpPotion);
        }

        if (playerState.Instance().mpPotion < 1)
        {
            itemSell[0].SetActive(false);
            itemSell[1].SetActive(false);
        }
    }
}
