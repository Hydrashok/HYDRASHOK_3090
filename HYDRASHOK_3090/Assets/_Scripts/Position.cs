using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public float frameSize = 1;



     void OnDrawGizmos()
     {
        Gizmos.DrawWireSphere(transform.position, frameSize); 
     }

    
}
