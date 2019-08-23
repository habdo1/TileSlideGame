using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    public static AudioClip slideSound, victorySound;
    static AudioSource source;
    
	public Sprite soundOff;
	public Sprite soundOn;
	public Button soundBtn;
	
	public void switchSound()
	{
		if (soundBtn.image.sprite == soundOn)
		{
			soundBtn.image.sprite = soundOff;
            GameData.Audio = false;
		}
		else
		{
			soundBtn.image.sprite = soundOn;
            GameData.Audio = true;
		}
	}

    void Start()
    {
        slideSound = Resources.Load<AudioClip> ("ClickSound");
        victorySound = Resources.Load<AudioClip> ("VictorySound");

        source = GetComponent<AudioSource>();
        if(GameData.Audio) soundBtn.image.sprite = soundOn;
        else soundBtn.image.sprite = soundOff;
    }

    public static void playSound (string audio)
    {
        if (audio == "ClickSound")
        {
            source.PlayOneShot(slideSound);
        }
        else if (audio == "VictorySound")
        {
            source.PlayOneShot(victorySound);
        }
    }
}
