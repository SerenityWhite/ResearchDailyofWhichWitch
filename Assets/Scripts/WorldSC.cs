using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSC : MonoBehaviour
{
    public GameObject witchHouse;
    public GameObject SpringSTLabel;
    public GameObject SpringSTList;
    public GameObject witch;
    public GameObject world;

	void Start ()
    {
		
	}

	void Update ()
    {
		
	}

    public void WitchHouseHover()
    {
        witchHouse.transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
    }

    public void WitchHouseHoverOut()
    {
        witchHouse.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    public void WitchHouseClick()
    {
        witch.SetActive(true);
        world.SetActive(false);
    }

    public void WorldBack()
    {
        world.SetActive(true);
        witch.SetActive(false);
    }

    public void SpringSTHover()
    {
        SpringSTLabel.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void SpringSTHoverOut()
    {
        SpringSTLabel.transform.localScale = new Vector3(0, 0, 0);
    }

    public void SpringSTClick()
    {
        SpringSTList.SetActive(true);
    }
}
