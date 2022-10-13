using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float horizontal = Input.GetAxis("Horizontal"); //this will call on the input that is under the name horizontal
       Debug.Log(horizontal)

    }
}
