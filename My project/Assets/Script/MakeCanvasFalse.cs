using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCanvasFalse : MonoBehaviour
{
    public GameObject canvasObject;
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = canvasObject.GetComponent<Canvas>();

        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            canvas.enabled = false; 
        }
    }

    public void MakeFalse()
    {
        canvas.enabled = false;
    }
}
