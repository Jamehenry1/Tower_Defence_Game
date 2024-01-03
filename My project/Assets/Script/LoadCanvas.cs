using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasObject;
    private Canvas innerCanvas;


    // Start is called before the first frame update
    void Start()
    {
        innerCanvas = GetComponent<Canvas>();
        innerCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Canvas outerCanvas = canvasObject.GetComponent<Canvas>();

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            outerCanvas.enabled = false;
            innerCanvas.enabled = true;
        }
    }
}
