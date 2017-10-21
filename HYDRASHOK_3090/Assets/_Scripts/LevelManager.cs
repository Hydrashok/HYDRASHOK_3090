using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LevelManager : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
  
=======
   public MusicManager musicmanager;
>>>>>>> c60eed0cc8641a1052e8cf8e8936b90038b3c709
=======
    
>>>>>>> parent of b0af5df... working

    int i;
    
    public void Start()
    {
       i = SceneManager.GetActiveScene().buildIndex;  // get scene by index
<<<<<<< HEAD
<<<<<<< HEAD
        
=======
        FindObjectOfType<MusicManager>().Play("Title");
>>>>>>> c60eed0cc8641a1052e8cf8e8936b90038b3c709
=======
>>>>>>> parent of b0af5df... working
    }
    
    public void LoadLevel(string name)
    {
		Debug.Log ("New Level load: " + name);
        SceneManager.LoadSceneAsync(name);
<<<<<<< HEAD
        Debug.Log("New Level load: " + name);
<<<<<<< HEAD
        
=======
        musicmanager.MusicCheck();
>>>>>>> c60eed0cc8641a1052e8cf8e8936b90038b3c709
    }
=======
	}
>>>>>>> parent of b0af5df... working

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
