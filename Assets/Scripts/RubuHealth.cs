using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubuHealth : MonoBehaviour
{
    public int Maxhealth = 3;
    int currenthealth; 
    
    // Start is called before the first frame update
    void Start()
    {
      currenthealth = Maxhealth;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangedHealth(int amount)
    {
        currenthealth = Mathf.Clamp(currenthealth + amount, 0, Maxhealth);
        Debug.Log(currenthealth + "/" + Maxhealth);
        
    }
}
