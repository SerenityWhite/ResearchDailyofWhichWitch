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
    public TypewriterEffect labelEF;

    void Start ()
    {
        ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님, 공방에 어서오시라냥~ \n이번엔 뭐가 필요하시냥?";
        labelEF.ResetToBeginning();
    }

	void Update ()
    {

    }
    
    public void RankOn()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        Rank.SetActive(true);
        MenuBox.SetActive(false);
        labelEF.Finish();
        ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님, 최단 시간 정복! \n한 번 도전해보는 건 어떠냥?";
        labelEF.ResetToBeginning();
        Rank.GetComponent<TweenPosition>().Play(true);
    }

    public void RankOff()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        Rank.SetActive(false);
        MenuBox.SetActive(true);
        Rank.GetComponent<TweenPosition>().ResetToBeginning();
    }

    public void IventoryOn()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        inventory.SetActive(true);
        main.SetActive(false);
    }

    public void IventoryOff()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        inventory.SetActive(false);
        main.SetActive(true);
        labelEF.Finish();
        ItemIntroTX.text = "루나라는 이름 어떤 것 같냥? \n커~다란 달밤에 " + PlayerPrefs.GetString("UserName") + "님이 데려와줬으니 그 날을 기념해서 스스로 지어봤다냥!";
        labelEF.ResetToBeginning();
    }

    public void BuyOn()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ShopOpen;
        SoundSC.Instance().Sound.Play();
        BuyList.SetActive(true);
        MenuBox.SetActive(false);
        labelEF.Finish();
        ItemIntroTX.text = "자, 이번엔 어떤 걸 만들어볼까냥?";
        labelEF.ResetToBeginning();
        BuyList.GetComponent<TweenPosition>().Play(true);
    }

    public void BuyBack()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        BuyList.SetActive(false);
        MenuBox.SetActive(true);
        itemBuy[0].SetActive(false);
        itemBuy[1].SetActive(false);
        itemBuy[2].SetActive(false);
        itemBuy[3].SetActive(false);
        labelEF.Finish();
        ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님! 연금술을 소홀히 하면 실력이 늘지 않는다냥.";
        labelEF.ResetToBeginning();
        BuyList.GetComponent<TweenPosition>().ResetToBeginning();
    }

    public void SellOn()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ShopOpen;
        SoundSC.Instance().Sound.Play();
        SellList.SetActive(true);
        MenuBox.SetActive(false);
        labelEF.Finish();
        ItemIntroTX.text = "이번엔 어떤 걸 가져오셨냥?";
        labelEF.ResetToBeginning();
        SellList.GetComponent<TweenPosition>().Play(true);
    }

    public void SellBack()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        SellList.SetActive(false);
        MenuBox.SetActive(true);
        itemSell[0].SetActive(false);
        itemSell[1].SetActive(false);
        itemBuy[2].SetActive(false);
        itemBuy[3].SetActive(false);
        labelEF.Finish();
        ItemIntroTX.text = "더 열심히 해서 부~자가 되어 보자냥.";
        labelEF.ResetToBeginning();
        SellList.GetComponent<TweenPosition>().ResetToBeginning();
    }


    //Buy로직
    public void HpPotionClick()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();

        if (playerState.Instance().gold >= 500)
        {
            labelEF.Finish();
            ItemIntroTX.text = "지금 " + PlayerPrefs.GetString("UserName") + "님이 가진 골드는 " + playerState.Instance().gold + "골드다냥. \n이 정도면 HP 회복약의 합성이 가능하다냥. \n합성할 거냥?";
            labelEF.ResetToBeginning();
            itemBuy[0].SetActive(true);
            itemBuy[1].SetActive(false);
            itemBuy[2].SetActive(false);
            itemBuy[3].SetActive(false);
        }

        if (playerState.Instance().gold < 500)
        {
            labelEF.Finish();
            ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님, HP 회복약을 합성하기엔 골드가 부족하다냥. \n지금 " + PlayerPrefs.GetString("UserName") + "님이 가진 골드는 " + playerState.Instance().gold + "골드 밖에 안된다냥. \n합성하고 싶으면 월드에서 골드를 더 구해오라냥.";
            labelEF.ResetToBeginning();
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(false);
            itemBuy[2].SetActive(false);
            itemBuy[3].SetActive(false);
        }
    }

    public void HpPotionClickBuy()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();

        if (playerState.Instance().gold >= 500)
        {
            itemBuy[0].SetActive(false);
            playerState.Instance().gold -= 500;
            playerState.Instance().hpPotion += 1;
            labelEF.Finish();
            ItemIntroTX.text = "HP 회복약 1개 합성 성공이다냥!";
            labelEF.ResetToBeginning();
            PlayerPrefs.SetInt("gold", playerState.Instance().gold);
            PlayerPrefs.SetInt("hpPotion", playerState.Instance().hpPotion);
        }

        if(playerState.Instance().gold < 500)
        {
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(false);
            itemBuy[2].SetActive(false);
            itemBuy[3].SetActive(false);
        }
    }

    public void HpPotionClick02()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();

        if (playerState.Instance().springStone >= 2)
        {
            labelEF.Finish();
            ItemIntroTX.text = "봄의 마법석 2개로 HP 회복약의 합성이 가능하다냥. \n지금 " + PlayerPrefs.GetString("UserName") + "님이 가진 마법석은 " + playerState.Instance().springStone + "개다냥. \n합성할 거냥?";
            labelEF.ResetToBeginning();
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(false);
            itemBuy[2].SetActive(true);
            itemBuy[3].SetActive(false);
        }

        if (playerState.Instance().springStone < 2)
        {
            labelEF.Finish();
            ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님, HP 회복약을 합성하기엔 마법석이 부족하다냥. \n지금 " + PlayerPrefs.GetString("UserName") + "님이 가진 봄의 마법석은 " + playerState.Instance().springStone + "개밖에 안된다냥. \n합성하고 싶으면 월드에서 마법석을 더 구해오라냥.";
            labelEF.ResetToBeginning();
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(false);
            itemBuy[2].SetActive(false);
            itemBuy[3].SetActive(false);
        }
    }

    public void HpPotionClickBuy02()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();

        if (playerState.Instance().springStone >= 2)
        {
            itemBuy[2].SetActive(false);
            playerState.Instance().springStone -= 2;
            playerState.Instance().hpPotion += 1;
            labelEF.Finish();
            ItemIntroTX.text = "HP 회복약 1개 합성 성공이다냥!";
            labelEF.ResetToBeginning();
            PlayerPrefs.SetInt("springStone", playerState.Instance().springStone);
            PlayerPrefs.SetInt("hpPotion", playerState.Instance().hpPotion);
        }

        if (playerState.Instance().springStone < 2)
        {
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(false);
            itemBuy[2].SetActive(false);
            itemBuy[3].SetActive(false);
        }
    }

    public void MpPotionClick()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();

        if (playerState.Instance().gold >= 300)
        {
            labelEF.Finish();
            ItemIntroTX.text = "지금 " + PlayerPrefs.GetString("UserName") + "님이 가진 골드는 " + playerState.Instance().gold + "골드다냥. \n이 정도면 MP 회복약의 합성이 가능하다냥. \n합성할 거냥?";
            labelEF.ResetToBeginning();
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(true);
            itemBuy[2].SetActive(false);
            itemBuy[3].SetActive(false);
        }

        if (playerState.Instance().gold < 300)
        {
            labelEF.Finish();
            ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님, MP 회복약을 합성하기엔 골드가 부족하다냥. \n지금 " + PlayerPrefs.GetString("UserName") + "님이 가진 골드는 " + playerState.Instance().gold + "골드 밖에 안된다냥. \n합성하고 싶으면 월드에서 골드를 더 구해오라냥.";
            labelEF.ResetToBeginning();
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(false);
            itemBuy[2].SetActive(false);
            itemBuy[3].SetActive(false);
        }
    }

    public void MpPotionClickBuy()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();

        if (playerState.Instance().gold >= 300)
        {
            itemBuy[1].SetActive(false);
            playerState.Instance().gold -= 300;
            playerState.Instance().mpPotion += 1;
            labelEF.Finish();
            ItemIntroTX.text = "MP 회복약 1개 합성 성공이다냥!";
            labelEF.ResetToBeginning();
            PlayerPrefs.SetInt("gold", playerState.Instance().gold);
            PlayerPrefs.SetInt("mpPotion", playerState.Instance().mpPotion);
        }

        if (playerState.Instance().gold < 300)
        {
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(false);
            itemBuy[2].SetActive(false);
            itemBuy[3].SetActive(false);
        }
    }

    public void MpPotionClick02()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();

        if (playerState.Instance().springStone >= 1)
        {
            labelEF.Finish();
            ItemIntroTX.text = "봄의 마법석 1개로 MP 회복약의 합성이 가능하다냥. \n지금 " + PlayerPrefs.GetString("UserName") + "님이 가진 마법석은 " + playerState.Instance().springStone + "개다냥. \n합성할 거냥?";
            labelEF.ResetToBeginning();
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(false);
            itemBuy[2].SetActive(false);
            itemBuy[3].SetActive(true);
        }

        if (playerState.Instance().springStone < 1)
        {
            labelEF.Finish();
            ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님, MP 회복약을 합성하기엔 마법석이 부족하다냥. \n지금 " + PlayerPrefs.GetString("UserName") + "님이 가진 봄의 마법석은 " + playerState.Instance().springStone + "개밖에 안된다냥. \n합성하고 싶으면 월드에서 마법석을 더 구해오라냥.";
            labelEF.ResetToBeginning();
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(false);
            itemBuy[2].SetActive(false);
            itemBuy[3].SetActive(false);
        }
    }

    public void MpPotionClickBuy02()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();

        if (playerState.Instance().springStone >= 1)
        {
            itemBuy[3].SetActive(false);
            playerState.Instance().springStone -= 1;
            playerState.Instance().mpPotion += 1;
            labelEF.Finish();
            ItemIntroTX.text = "MP 회복약 1개 합성 성공이다냥!";
            labelEF.ResetToBeginning();
            PlayerPrefs.SetInt("springStone", playerState.Instance().springStone);
            PlayerPrefs.SetInt("mpPotion", playerState.Instance().mpPotion);
        }

        if (playerState.Instance().springStone < 1)
        {
            itemBuy[0].SetActive(false);
            itemBuy[1].SetActive(false);
            itemBuy[2].SetActive(false);
            itemBuy[3].SetActive(false);
        }
    }

    //Sell로직
    public void HpPotionSellClick()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();

        if (playerState.Instance().hpPotion >= 1)
        {
            labelEF.Finish();
            ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님이 갖고 있는 HP 회복약을 분해해서 골드로 만들 수 있다냥! \n200골드를 얻을 수 있다냥. \n분해하시겠냥?";
            labelEF.ResetToBeginning();
            itemSell[0].SetActive(true);
            itemSell[1].SetActive(false);
        }

        if(playerState.Instance().hpPotion < 1)
        {
            labelEF.Finish();
            ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님, 분해할 HP 회복약이 없다냥. \n빨리 구해오라냥.";
            labelEF.ResetToBeginning();
            itemSell[0].SetActive(false);
            itemSell[1].SetActive(false);
        }
    }

    public void HpPotionClickSell()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();

        if (playerState.Instance().hpPotion >= 1)
        {
            itemSell[0].SetActive(false);
            playerState.Instance().gold += 200;
            playerState.Instance().hpPotion -= 1;
            labelEF.Finish();
            ItemIntroTX.text = "냐앙~ 냐앙~ 돈이다냥~ \nHP 회복약 1개를 분해해서 200골드를 얻었다냥!";
            labelEF.ResetToBeginning();
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
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();

        if (playerState.Instance().mpPotion >= 1)
        {
            labelEF.Finish();
            ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님이 갖고 있는 MP 회복약을 분해해서 골드로 만들 수 있다냥! \n100골드를 얻을 수 있다냥. \n분해하시겠냥?";
            labelEF.ResetToBeginning();
            itemSell[0].SetActive(false);
            itemSell[1].SetActive(true);
        }

        if (playerState.Instance().mpPotion < 1)
        {
            labelEF.Finish();
            ItemIntroTX.text = PlayerPrefs.GetString("UserName") + "님, 분해할 MP 회복약이 없다냥. \n빨리 구해오라냥.";
            labelEF.ResetToBeginning();
            itemSell[0].SetActive(false);
            itemSell[1].SetActive(false);
        }
    }

    public void MpPotionClickSell()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();

        if (playerState.Instance().mpPotion >= 1)
        {
            itemSell[1].SetActive(false);
            playerState.Instance().gold += 100;
            playerState.Instance().mpPotion -= 1;
            labelEF.Finish();
            ItemIntroTX.text = "냐앙~ 냐앙~ 돈이다냥~ \nMP 회복약 1개를 분해해서 100골드를 얻었다냥!";
            labelEF.ResetToBeginning();
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
