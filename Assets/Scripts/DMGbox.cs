using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        RubuHealth controller = other.GetComponent<RubuHealth >();
        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
    }
}
// gotta fix the bug for controller.ChangeHealth. make sure to ask mr.shams bout it