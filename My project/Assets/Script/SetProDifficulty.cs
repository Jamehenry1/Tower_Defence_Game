using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetProDifficulty : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetProHealth()
    {
        Enemy1.GetComponent<Enemy>().proTrue = true;
        Enemy2.GetComponent<Enemy>().proTrue = true;
        Enemy3.GetComponent<Enemy>().proTrue = true;
        Enemy4.GetComponent<Enemy>().proTrue = true;
    
    }

    public void SetNoobHeath()
    {
        Enemy1.GetComponent<Enemy>().proTrue=false;
        Enemy2.GetComponent<Enemy>().proTrue=false;
        Enemy3.GetComponent<Enemy>().proTrue=false;
        Enemy4.GetComponent<Enemy>().proTrue=false;
    }
}
