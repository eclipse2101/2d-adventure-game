using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    public AudioClip collectedClip;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        RubuController controller = other.GetComponent<RubuController>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                
                Destroy(gameObject);
                controller.ChangedHealth(1);
                controller.PlaySound(collectedClip);
                UiHealth uiScript = GetComponent<UiHealth>();
                
            
                
            }
        }

    }
}
