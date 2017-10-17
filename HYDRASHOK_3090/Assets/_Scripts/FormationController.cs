using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FormationController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float width = 10f;
    public float heigth = 5f;
    public float Speed = 5f;
    public float spawnDelay = 1f;

    private bool movingRight = true;
    private float xmax;
    private float xmin;

    

    // Use this for initialization
    void Start ()
    {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmax = rightEdge.x;
        xmin = leftEdge.x;
        SpawnUntilFull();


        
    }


    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }


    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }
        
        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }
        
    }



    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, heigth));
    }


     void Update()
    {
       if (movingRight)
        {
            transform.position += Vector3.right * Speed * Time.deltaTime;
        } 

       else
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f*width);
        float leftEdgeOfFormation = transform.position.x - (0.5f*width);

        if (leftEdgeOfFormation < xmin)  
        {
            movingRight = true;
        }

        else if (rightEdgeOfFormation > xmax)
        {
            movingRight = false;
        }

                

        

        if (AllMembersDead())
        {
            Debug.Log("Empty Formation");

           // SpawnUntilFull();
            LoadNextLevel();
        
        }       
        
        

     }

    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }

        }

        return null;
    }



    public bool AllMembersDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }

        }

        return true;
    }


    void LoadNextLevel()
    {
        
        int i = SceneManager.GetActiveScene().buildIndex;  // get scene by index

        SceneManager.LoadSceneAsync(i + 1);

    }

}
