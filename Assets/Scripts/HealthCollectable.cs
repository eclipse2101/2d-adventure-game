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
                controller.ChangedHealth(1);
                Destroy(gameObject);
                UiHealth uiScript = GetComponent<UiHealth>();
                if (uiScript != null)
                {
                    uiScript.heartUpg = true;
                    Debug.Log(" ez health");
                }
            
                controller.PlaySound(collectedClip);
            }
        }

    }
}
