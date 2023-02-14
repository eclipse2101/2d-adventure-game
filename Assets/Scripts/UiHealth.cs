using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UiHealth : MonoBehaviour
{
    public static UiHealth instance { get; private set; }
    
    public Image lastHeart;
    public Image middleHeart;
    public Image firstHeart;
    

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    public void SetValue(float value)
    {
        Debug.Log(value);				      
        if(value < 3)
        {
            Debug.Log("Ouch");
            //lastHeart.enabled = false;
        }
    }
}
