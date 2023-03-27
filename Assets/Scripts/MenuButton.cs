using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
  // not that by default a bool statemnt will be false
    public GameObject DialogBox;
    public bool IsActive; 
    
    // Start is called before the first frame update
    void Start()
    {
        DialogBox.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       if (IsActive == false);
       {
        DialogBox.SetActive(true);
       }   
    }
}
