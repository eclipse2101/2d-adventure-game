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
        RubuController controller = other.GetComponent<RubuController >();
        if (controller != null)
        {
            controller.ChangedHealth(-1);
        }
    }
}
// gotta fix the bug for controller.ChangeHealth. make sure to ask mr.shams bout it