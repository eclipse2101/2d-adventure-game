using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubuController : MonoBehaviour
{
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       horizontal = Input.GetAxis("Horizontal"); //this will call on the input that is under the name horizontal
       Debug.Log(horizontal);

       vertical = Input.GetAxis("Vertical"); 
       Debug.Log(vertical);

       

    }
    private void FixedUpdate()
    {
        Vector2 position = transform.position;
       position.x = position.x + 4.0f * horizontal * Time.deltaTime; // this function will change the speed of how fast your character moves
       position.y = position.y + 4.0f * vertical * Time.deltaTime;
       transform.position = position;
    }
}
