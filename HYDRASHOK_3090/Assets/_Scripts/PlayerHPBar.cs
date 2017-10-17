using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] private Stat health;


    private void Awake()
    {
        health.Initialize();  
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            health.CurrentVal += 10;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            health.CurrentVal -= 10;
        }
    }
}

