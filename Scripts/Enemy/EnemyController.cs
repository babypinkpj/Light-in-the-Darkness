using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
     public float speed = 4f; 
         private bool canMove = true; 

    void Update()
    {
        if (canMove)
        {
            
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

   
    public void StopMovement()
    {
        canMove = false;
    }

   
    public void ResumeMovement()
    {
        canMove = true;
    }
}
