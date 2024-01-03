using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellAndUpgrade : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float range = 1;

    public Text SellText;
    public Text UpgradeText;
    void Start()
    {
        InvokeRepeating("FindTower", 0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        
    }

    void FindTower()
    {
        //towers = GameObject.FindGameObjectWithTag("Tower");
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestTower = null;
        foreach (GameObject t in towers)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, t.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestTower = t;
            }
        }

        if (nearestTower != null && shortestDistance <= range)
        {
            
            target = nearestTower;
            SellText.text = "Sell\n" + "$" + (target.GetComponent<Towers>().sellAmount);
            UpgradeText.text = "Upgrade\n" + "$" + (target.GetComponent<Towers>().upGradeAmount);
        }
        else if (target != null)
        {
            target = null;
        }

    }

    public void Sell()
    {

        Debug.Log("sold");
        GameManager money = GameObject.Find("GameManager").GetComponent<GameManager>();
        int sellPoint = target.GetComponent<Towers>().sellAmount;
        money.AddMoney(sellPoint);
        target.GetComponentInParent<TileScript>().IsEmpty = true;
        Destroy(target.gameObject);
        UIMover();
    }

    public void Upgrade()
    {
        Towers Up = target.GetComponent<Towers>();
        GameManager money = GameObject.Find("GameManager").GetComponent<GameManager>();
        int upgradeAmount = Up.upGradeAmount;
        if (Up.upgradeTime < 2 && money.Currency >= upgradeAmount)
        {
            money.ReduceMoney(upgradeAmount);
            Debug.Log("Upgrade");
            Up.Upgrading();
            //Up.GetComponent<Towers>().upgradeTime++;

        }
        else if (Up.upgradeTime >= 2)
        {
            Debug.Log("NO more upgrades");
        }
        else 
        {
            Debug.Log("Not Enough Money");
        }
        UIMover();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void UIMover()
    {
        
        Transform UIHold = GameObject.Find("UI holder").transform;
        Transform TowerUI = GameObject.Find("Tower UI").transform;
        TowerUI.position = UIHold.transform.position;
    }
}
