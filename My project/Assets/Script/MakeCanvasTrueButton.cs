using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCanvasTrueButton : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeCanvasTrue(GameObject canvasObject)
    {
        Canvas canvas = canvasObject.GetComponent<Canvas>();
        canvas.enabled = true;
    }

    public void MakeCanvasFalse(GameObject canvasObject)
    {
        Canvas canvas = canvasObject.GetComponent<Canvas>();
        canvas.enabled = false;
    }
}
