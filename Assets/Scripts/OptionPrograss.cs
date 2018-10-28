using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPrograss : MonoBehaviour
{
    public UISlider Music;
    public UISlider Sound;

    public AudioSource BGM;
    public AudioSource BGSound;
    public AudioSource FullSound;
    public AudioSource enemySound;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        BGM.volume = Music.value;
        BGSound.volume = Music.value;
        FullSound.volume = Sound.value;
        enemySound.volume = Sound.value;
    }
}
