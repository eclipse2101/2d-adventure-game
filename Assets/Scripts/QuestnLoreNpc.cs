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
        if (timerDisplay >= 0)
        {
        timerDisplay -= Time.deltaTime;
        if (timerDisplay < 0)
            {
            DialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        DialogBox.SetActive(true);
    }
}
