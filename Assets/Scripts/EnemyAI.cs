using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    Animator AnimationRunner; 
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        AnimationRunner = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime; 
        }
    }

    void FixedUpdate() // this is for the robot to move 
    {
        Vector2 position = rigidbody2D.position;
        
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;;
            AnimationRunner.SetFloat("x funni", 0); // this will run the left and right animations 
            AnimationRunner.SetFloat("y funni", direction); // same thing but for up and down 
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;;
            AnimationRunner.SetFloat("y funni", 0);
            AnimationRunner.SetFloat("x funni", direction);
        }
        
        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other) // if the player collides with this they will lose health
    {
       RubuController player = other.gameObject.GetComponent<RubuController>();

    if (player != null)
     {
        player.ChangedHealth(-1);
     }
    }

    
}

