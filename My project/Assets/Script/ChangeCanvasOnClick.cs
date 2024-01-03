using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvasOnClick : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentCanvasFalse(GameObject CurrentCanvasObject)
    {
        Canvas CurrentCanvas = CurrentCanvasObject.GetComponent<Canvas>();

        if(CurrentCanvas.enabled == true)
        {
            CurrentCanvas.enabled = false;
        }
    }

    public void SetNextCanvasTrue(GameObject NextCanvasObject)
    {
        Canvas NextCanvas = NextCanvasObject.GetComponent<Canvas>();

        if (NextCanvas.enabled == false)
        {
            NextCanvas.enabled = true;
        }
    }
}
