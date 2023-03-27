using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestnLoreNpc : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject DialogBox;
    float timerDisplay;
    
     // Start is called before the first frame update
    void Start()
    {
        DialogBox.SetActive(false);
       timerDisplay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        // once the timer hits zero the dialog will disappear
        if (timerDisplay >= 0)
        {
        timerDisplay -= Time.deltaTime;
        if (timerDisplay < 0)
            {
            DialogBox.SetActive(false);
            }
        }
    }

    
    // this is to display the dialog
    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        DialogBox.SetActive(true);
    }
}
