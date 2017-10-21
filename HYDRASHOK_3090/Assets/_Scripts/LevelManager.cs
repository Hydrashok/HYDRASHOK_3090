using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LevelManager : MonoBehaviour
{
   public MusicManager musicmanager;

    int i;
    
    public void Start()
    {
       i = SceneManager.GetActiveScene().buildIndex;  // get scene by index
        FindObjectOfType<MusicManager>().Play("Title");
    }
    
    public void LoadLevel(string name)
    {
		
        SceneManager.LoadSceneAsync(name);
        Debug.Log("New Level load: " + name);
        musicmanager.MusicCheck();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(i + 1);
    }
    
	public void QuitRequest()
    {
		Debug.Log ("Quit requested");
		Application.Quit();
	}


   




}
