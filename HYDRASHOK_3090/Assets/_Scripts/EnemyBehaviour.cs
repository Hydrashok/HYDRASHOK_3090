using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    
    public GameObject enemyExplosion;
    public GameObject enemyLaser1;
    public float projectileSpeed = 1f;
    public float shotsPerSecond;
    public float health ;
    public int scoreValue;

    private ScoreKeeper scorekeeper;

    //NEW CODE---------------------------------------
    public static int breakableCount = 0;
    private int timesHit;
    private int maxHits;
    private LevelManager levelManager;
    private bool isBreakable;
    //-------------------------------------------------





    void Start()
    {
        scorekeeper =  GameObject.Find("Score").GetComponent<ScoreKeeper>();

        //NEW CODE__________________________________________


        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;

            Debug.Log("Enemies Left " + breakableCount);
        }

        timesHit = 0;
        

        //________________________________________________________
        

    }






    void Update()
    {
        float probabilitly = Time.deltaTime * shotsPerSecond;
        if (Random.value < probabilitly)
        {
            EnemyFire();
        }
                      
    }


    void EnemyFire()
    {
        Vector3 startPosition = transform.position + new Vector3(0, -0.5f , 0);
        GameObject laser = Instantiate(enemyLaser1, startPosition, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);
        // AudioSource.PlayClipAtPoint(enemyLaserSound, transform.position);
       //  FindObjectOfType<MusicManager>().Play("EnemyLaser");
    }



    void OnTriggerEnter2D (Collider2D collider2D)
    {
        Projectile laser = collider2D.gameObject.GetComponent<Projectile>();

        if (laser)
        {
            health -= laser.GetDamage();
            laser.Hit();

            if (health <= 0)
            {
                
                Instantiate (enemyExplosion, gameObject.transform.position, Quaternion.identity);

                // Destroy(gameObject);
               

              //  FindObjectOfType<MusicManager>().Play("Explode");
                scorekeeper.Score(scoreValue);
                HandleHits();
            }

        }

        

        



    }

//NEW CODE______________________________________________________

    void HandleHits()
    {
        timesHit++;
       
        if (timesHit >= health)
        {

            breakableCount--;
            Debug.Log("Enemies Left " + breakableCount);

            Destroy(gameObject);

        }


    }


   //_____________________________________________________________















}
