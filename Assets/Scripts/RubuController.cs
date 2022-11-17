using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubuController : MonoBehaviour
{
    public int maxHealth = 3;
    int currentHealth; 
    public float timeInvincible = 2.0f;
    
    public int health { get { return currentHealth; }}
    
    
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
    }

    // Update is called once per frame
    void Update()
    {
       horizontal = Input.GetAxis("Horizontal"); //this will call on the input that is under the name horizontal
       

       vertical = Input.GetAxis("Vertical"); 
       

       if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

    }
    private void FixedUpdate()
    {
        Vector2 position = transform.position;
       position.x = position.x + 4.0f * horizontal * Time.deltaTime; // this function will change the speed of how fast your character moves
       position.y = position.y + 4.0f * vertical * Time.deltaTime;
       transform.position = position;
    }

    
     public void ChangedHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        
    }
}
