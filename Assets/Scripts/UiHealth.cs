using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UiHealth : MonoBehaviour
{
    public static UiHealth instance { get; private set; }
    
    public bool heartUpg;
    public Image healthBar; 
    public float originalSize;
    public float healthBarSize;

    

    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
      RubuController stinkHealthScript = GetComponent<RubuController>();

      originalSize = healthBar.rectTransform.rect.width;

    }

    public void SetValue(float value)
    {			        
        healthBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * .67f);
    }
}
