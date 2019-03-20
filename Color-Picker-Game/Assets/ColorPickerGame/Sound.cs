using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
	private AudioSource audio;
	public static Sound _instance;
	private int mainAudio = 1;

    void Awake()
    {
	    if (_instance == null)
	    {
		    _instance = this;
		    DontDestroyOnLoad(gameObject);
	    }
	    else if (_instance != this)
	    {
		    Destroy(gameObject);
	    }

	    audio = gameObject.GetComponent<AudioSource>();
    }

    void Start()
    {
	    
    }

    void Update()
    {
		CheckIfMainAudioEnabled();
    }

    void CheckIfMainAudioEnabled()
    {
	    var mainAudioEnabled = PlayerPrefs.GetInt("audio");
	    audio.volume = mainAudioEnabled == 0 ? 0.2f : 0;
    }
}
