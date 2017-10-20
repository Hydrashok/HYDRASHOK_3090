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
        FindObjectOfType<MusicManager>().Play("Title");
        /* DontDestroyOnLoad(gameObject);

         if (instance == null)
             instance = this;

         else
         {
             Destroy(gameObject);


         }


         DontDestroyOnLoad(gameObject);
         */

        MusicCheck();


        foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
            s.source.volume = s.volume;
            //s.source.outputAudioMixerGroup = mixerGroup;
            
        }

    }

    


    
    public void Play(string name) 
	{
              
        Sound s = Array.Find(sounds, sound => sound.name == name);  // tied to sound.cs/ able to call by name // change to int 
        
        s.source.Play();

        if (s == null)
		{
            Debug.LogWarning("Sound: " + base.name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		  
        
	}


    public void MusicCheck()
    {

        if (SceneManager.GetActiveScene().name == "Start")
        {
            FindObjectOfType<MusicManager>().Play("Title");
        }

        if (SceneManager.GetActiveScene().name == "Level_01")
        {
            FindObjectOfType<MusicManager>().Play("BGM01");
        }
        if (SceneManager.GetActiveScene().name == "Level_02")
        {
            FindObjectOfType<MusicManager>().Play("BGM02");
        }
        if (SceneManager.GetActiveScene().name == "Level_03")
        {
            FindObjectOfType<MusicManager>().Play("BGM03");
        }
        if (SceneManager.GetActiveScene().name == "Level_04")
        {
            FindObjectOfType<MusicManager>().Play("BGM04");
        }
        if (SceneManager.GetActiveScene().name == "Level_05")
        {
            FindObjectOfType<MusicManager>().Play("BGM05");
        }
        if (SceneManager.GetActiveScene().name == "Level_06")
        {
            FindObjectOfType<MusicManager>().Play("BGM06");
        }
        if (SceneManager.GetActiveScene().name == "Level_07")
        {
            FindObjectOfType<MusicManager>().Play("BGM07");
        }
        if (SceneManager.GetActiveScene().name == "Level_08")
        {
            FindObjectOfType<MusicManager>().Play("BGM08");
        }
        if (SceneManager.GetActiveScene().name == "Level_09")
        {
            FindObjectOfType<MusicManager>().Play("BGM09");
        }
        if (SceneManager.GetActiveScene().name == "Level_10")
        {
            FindObjectOfType<MusicManager>().Play("BGM10");
        }

        if (SceneManager.GetActiveScene().name == "Win")
        {
            FindObjectOfType<MusicManager>().Play("Title");
        }

        if (SceneManager.GetActiveScene().name == "Lose")
        {
            FindObjectOfType<MusicManager>().Play("BGM03");
        }
    }
    
   

}
