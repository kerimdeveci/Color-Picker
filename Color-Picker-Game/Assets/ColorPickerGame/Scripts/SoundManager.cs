using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Experimental.UIElements;
using Image = UnityEngine.UI.Image;

public class SoundManager : MonoBehaviour
{
	public GameObject audioSource;

	public int audioEnabled;
	public Sprite audioOn;
	public Sprite audioOff;
	private Image mainSoudObjectSprite;

	void Awake()
	{
		//PlayerPrefs.DeleteAll();
	}


    void Start()
    {
	    audioEnabled = PlayerPrefs.GetInt("audio");
	    mainSoudObjectSprite = GameObject.FindGameObjectWithTag("Sound").GetComponent<Image>();
	    if (audioEnabled == 1)
	    {
		    mainSoudObjectSprite.sprite = audioOff;
	    }
	    else if (audioEnabled==0)
	    {
		    mainSoudObjectSprite.sprite = audioOn;
	    }
    }


    void Update()
    {
		
	}

	public void AudioButton()
    {
	    if (audioEnabled == 0)
	    {
		    audioEnabled = 1;
		    PlayerPrefs.SetInt("audio", audioEnabled);
		    mainSoudObjectSprite.sprite = audioOff;

	    }
	    else
	    {
		    audioEnabled = 0;
		    PlayerPrefs.SetInt("audio", audioEnabled);
		    mainSoudObjectSprite.sprite = audioOn;
	    }
    }
}
