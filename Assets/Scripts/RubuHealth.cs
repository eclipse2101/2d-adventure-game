using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubuHealth : MonoBehaviour
{
    public int Maxhealth = 3;
    int currenthealth; 
    public float timeInvincible = 2.0f;
    
    public int health { get { return currentHealth; }}
    int currentHealth;
    
    bool isInvincible;
    float invincibleTimer;
    
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
      rigidbody2d = GetComponent<Rigidbody2D>();
      currenthealth = Maxhealth;   
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    void ChangedHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        
        currenthealth = Mathf.Clamp(currenthealth + amount, 0, Maxhealth);
        Debug.Log(currenthealth + "/" + Maxhealth);
        
    }
}
