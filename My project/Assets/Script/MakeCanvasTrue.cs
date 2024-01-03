using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCanvasTrue : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasObject;
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = canvasObject.GetComponent<Canvas>();
        canvas.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
