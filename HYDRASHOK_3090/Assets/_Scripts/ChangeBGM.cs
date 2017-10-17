using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ChangeBGM : MonoBehaviour
{
    
    // Use this for initialization
    void Start ()
       
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
