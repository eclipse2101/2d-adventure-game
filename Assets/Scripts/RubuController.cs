using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubuController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float horizontal = Input.GetAxis("Horizontal"); //this will call on the input that is under the name horizontal
       Debug.Log(horizontal);

       float vertical = Input.GetAxis("Vertical"); 
       Debug.Log(vertical);

       Vector2 position = transform.position;
       position.x = position.x + 5.0f * horizontal * Time.deltaTime; // this function will change the speed of how fast your character moves
       position.y = position.y + 5.0f * vertical * Time.deltaTime;
       transform.position = position;

    }
}
