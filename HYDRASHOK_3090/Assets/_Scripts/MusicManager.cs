using UnityEngine.Audio;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // not sure if to change music here or levelmanager

public class MusicManager : MonoBehaviour
{
    private MusicManager instance;
    public Sound[] sounds;
     AudioSource audioSource;

        // FindObjectOfType<MusicManager>().Play("");    - use to play music through Sounds .cs


    void Awake()
    {
        /*
        DontDestroyOnLoad(gameObject);

        if (instance == null)
            instance = this;
                
        else
        {
            Destroy(gameObject);
            
            
        }


        DontDestroyOnLoad(gameObject);
        */


        foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
            s.source.volume = s.volume;
           // s.source.outputAudioMixerGroup = mixerGroup;
            
        }

    }

    


    
    public void Play(string name)  // was string changed to int
	{
      //  Sound s = Array.FindIndex(sounds, ); 

        
        Sound s = Array.Find(sounds, sound => sound.name == name);  // tied to sound.cs/ able to call by name // change to int 
        

        s.source.Play();

        if (s == null)
		{
            Debug.LogWarning("Sound: " + base.name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		  
        
	}
    

    
   

}
