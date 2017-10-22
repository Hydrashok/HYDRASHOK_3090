using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerLife : MonoBehaviour
{
  
    public float playerHealth = 10;
    public GameObject playerExplode;
    public GameObject LevelManager;

    


    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        playerHealth--;

        if (playerHealth<= 0)
        {
            Instantiate(playerExplode, gameObject.transform.position, Quaternion.identity);
            
          //  FindObjectOfType<MusicManager>().Play("Explode");

            Die();            
                     
        }
    }

    public void Die()
    {
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        man.LoadLevel("Lose");
        Destroy(gameObject);
    }










}
