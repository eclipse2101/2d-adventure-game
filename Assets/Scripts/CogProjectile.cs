using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogProjectile : MonoBehaviour
{
    Rigidbody2D rigibody2D;
    
    // Start is called before the first frame update
    void Awake()
    {
        rigibody2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Launch(Vector2 direction, float force) // this is to show where the cog is gonna go and how much force is gonna be applied to it
    {
        rigibody2D.AddForce(direction * force); 
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyAI e = other.collider.GetComponent<EnemyAI>();
        if (e != null)
        {
            e.Fix(); 
        }
        
        Debug.Log("The cog has touched with" + other.gameObject);
        Destroy(gameObject);
    }
}
