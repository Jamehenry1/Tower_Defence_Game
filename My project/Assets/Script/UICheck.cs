using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICheck : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        
        //bSell = Sell.colors.normalColor;
    }

    // Update is called once per frame
    void Update()
    {
        
        //if(gameObject.transform.childCount > 0)
    }
   

    private void OnMouseDown()
    {
       
        if (gameObject.transform.childCount <= 0)
        {
            Debug.Log("grass selected");
            Transform UIHold = GameObject.Find("UI holder").transform;
            Transform TowerUI = GameObject.Find("Tower UI").transform;
            TowerUI.position = UIHold.transform.position;
        }
 
        

    }
}
