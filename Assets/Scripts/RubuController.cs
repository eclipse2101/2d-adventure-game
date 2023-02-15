using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubuController : MonoBehaviour
{
    // yes i did made my link sprite and called it stink and gived the script name rubu controller. Cry about it
    public int maxHealth = 3;
    int currentHealth; 
    public float timeInvincible = 2.0f;
    
    public int health { get { return currentHealth; }} // this is to show stinks current health

    Animator animationRunner;
    Vector2 lookdirection = new Vector2(1, 0); 

    public GameObject projectilePrefab; 
    
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
       
       // death script
        if (currentHealth == 0)
        {
            Destroy(gameObject);
            Debug.Log("You have died. Please restart the game and get good"); 
        }  
       
       
       // ok so all of this pretty much gets the functions to make stink move and get his animations
       horizontal = Input.GetAxis("Horizontal"); //this will call on the input that is under the name horizontal
       
       

       vertical = Input.GetAxis("Vertical"); 

       Vector2 move = new Vector2(horizontal, vertical); // this is to start the animation code
       if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)) // || also means or in coding
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

        if(Input.GetKeyDown(KeyCode.K))
        {
            Launch(); 
        }

        // dialog making /////////////////////
        if (Input.GetKeyDown(KeyCode.E))
      {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookdirection, 1.5f, LayerMask.GetMask("Npc/ lore tellers"));
        if (hit.collider != null)
        {
             QuestnLoreNpc character = hit.collider.GetComponent<QuestnLoreNpc>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
        }
      }
    }


    private void FixedUpdate()
    {
        // this part makes stink actually move 
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
        UiHealth.instance.SetValue(currentHealth);
        
    }

    // this is for the cog projectile
    void Launch()
    {
     GameObject CogProjectile = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

     CogProjectile CogAmmo = CogProjectile.GetComponent<CogProjectile>();
     CogAmmo.Launch(lookdirection, 300); 
     animationRunner.SetTrigger("Launch"); 
    }

    
}
