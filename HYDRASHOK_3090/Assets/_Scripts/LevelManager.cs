using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LevelManager : MonoBehaviour
{
    

    int i;
    
    public void Start()
    {
       i = SceneManager.GetActiveScene().buildIndex;  // get scene by index
    }
    
    public void LoadLevel(string name)
    {
		Debug.Log ("New Level load: " + name);
        SceneManager.LoadSceneAsync(name);
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
