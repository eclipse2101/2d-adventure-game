using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubuHealth : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        RubuController controller = other.GetComponent<RubuController>();

        if (controller != null)
        {
            if(controller.health  < controller.maxHealth)
            {
                controller.ChangedHealth(1);
                Destroy(gameObject);
            }
        }
    }
}
