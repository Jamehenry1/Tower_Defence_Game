using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    [SerializeField]

    private float camSpeed = 0;
    private float xMax;
    private float yMin;

    Vector3 maxTile = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * camSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * camSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * camSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * camSpeed * Time.deltaTime);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, xMax), Mathf.Clamp(transform.position.y, yMin, 0),-3);
    }
    
    public void SetLim(Vector3 maxTile) 
    {
        
        Vector3 wp = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));
        
        xMax = maxTile.x - wp.x;
        yMin = maxTile.y - wp.y;
        
    }
    
}
