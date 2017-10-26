using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

   // private LevelManager levelManager;
    public GameObject projectile;
    public float speed = 15.0f;
    public float padding = 0f;
    public float projectileSpeed;
    float xmin = -7;
    float xmax = 7;
    public float fireRate = 0.2f;

    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;

        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }


    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0, 0.7f, 0);
        GameObject beam = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        // AudioSource.PlayClipAtPoint(playerLaser, transform.position);
       // FindObjectOfType<MusicManager>().Play("PlayerLaser");

    }

    
    void Update()

    {
        if (Input.GetMouseButtonDown(0))
        {
            InvokeRepeating("Fire", 0.00001f, fireRate);
        }

        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("Fire");
        }

        if (Input.GetKey(KeyCode.A))
        {
           transform.position += Vector3.left * speed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        // This restricts player to the play space
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        //if (EnemyBehaviour.breakableCount <= 0)
        //    {
         //   levelManager.LoadNextLevel();
        //     }




    }


    void OnTriggerEnter2D(Collider2D collider2D)

    {
        Destroy(collider2D.gameObject);

        

    }







}
