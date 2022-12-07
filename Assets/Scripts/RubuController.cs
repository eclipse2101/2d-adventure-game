using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubuController : MonoBehaviour
{
    public int maxHealth = 3;
    int currentHealth; 
    public float timeInvincible = 2.0f;
    
    public int health { get { return currentHealth; }}

    Animator animationRunner;
    Vector2 lookdirection = new Vector2(1, 0); 
    
    bool isInvincible;
    float invincibleTimer;
    
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; 
        animationRunner = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       horizontal = Input.GetAxis("Horizontal"); //this will call on the input that is under the name horizontal
       

       vertical = Input.GetAxis("Vertical"); 

       Vector2 move = new Vector2(horizontal, vertical); // this is to start the animation code
       if(!Mathf.Approximately(move.x, move.y) || !Mathf.Approximately(move.y, 0.0f)) // || also means or in coding
       {
        lookdirection.Set(move.x, move.y);
        lookdirection.Normalize(); 
       }
       
       animationRunner.SetFloat("x stink", lookdirection.x);
       animationRunner.SetFloat("y stink", lookdirection.y);
       animationRunner.SetFloat("Speed", move.magnitude);

       if (isInvincible) // a timer for if ruby gets hit she will be unhitable for awhile 
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

    }
    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
       position.x = position.x + 3.0f * horizontal * Time.deltaTime; // this function will change the speed of how fast your character moves
       position.y = position.y + 3.0f * vertical * Time.deltaTime;
       rigidbody2d.MovePosition(position);
    }

    
     public void ChangedHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible; // this will be make ruby invincible for awhile if the players health is not zero 
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); // this is to show how many health the player has
        Debug.Log(currentHealth + "/" + maxHealth); // this will show how much health you have in the debug log
        
    }
}
