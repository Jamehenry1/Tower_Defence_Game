using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Towers : MonoBehaviour
{
    public Transform target = null;
    public float range = 10f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;


    public float turnSpeed = 10;
    public int sellAmount = 5;
    public int upGradeAmount = 10;
    public int upgradeTime = 0;

    public string enemyTag = "Enemy";
    public GameObject bulletPre;
    public Transform[] firePoint;
    public Transform Rotator;
    bool towerClick = false;
    public Sprite[] upgradeSprite;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void OnMouseDown()
    {
        
        Debug.Log("tower selected");
        Transform TowerUI = GameObject.Find("Tower UI").transform;
        TowerUI.position = gameObject.transform.position;

    }

  

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            
            target = nearestEnemy.transform;
        }
        else if (target != null)
        {     
            target = null;           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(Rotator.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        Rotator.rotation = Quaternion.Euler(0f, 0f , rotation.z);
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;

    }



    void Shoot()
    {
        if (gameObject.tag == "Trap")
        {
            Debug.Log("trap");
            gameObject.GetComponentInParent<TileScript>().IsEmpty = true;
            Destroy(gameObject);
            
            int i = 0;
            while (i < 10)
            {
                GameObject test = Instantiate(bulletPre, firePoint[Random.Range(0,firePoint.Length)].position, Rotator.rotation);
                Bullet trap = test.GetComponent<Bullet>();
                if (trap != null)
                {
                    trap.Seek(target);
                    i++;

                }
                else
                {
                    break;
                }
                
            }

        }
        else
        {
            Debug.Log("shoot");

            GameObject bulletGo = Instantiate(bulletPre, firePoint[Random.Range(0, firePoint.Length)].position, Rotator.rotation);
            Bullet bullet = bulletGo.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.Seek(target);
            }
        }
        
    }

    public void Upgrading()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = upgradeSprite[upgradeTime];
        upgradeTime++;
        fireRate = fireRate * (float)1.3;
        range = range * (float)1.3;
        Bullet bulUP = bulletPre.GetComponent<Bullet>();
        bulUP.BullUpgrade();

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
