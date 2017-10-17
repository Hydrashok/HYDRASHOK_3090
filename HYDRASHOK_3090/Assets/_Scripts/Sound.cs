using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]


// FindObjectOfType<MusicManager>().Play("");     - use to play sounds/music


public class Sound
{

	public string name;

	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume = .75f;
	[Range(0f, 1f)]
	public float volumeVariance = .1f;

	

	public bool loop = true;

	//public AudioMixerGroup mixerGroup;

	[HideInInspector]
	public AudioSource source;



   


}
