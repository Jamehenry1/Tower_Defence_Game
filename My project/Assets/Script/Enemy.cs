using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;
    public int moneyHold;
    public bool proTrue = false;

    private Transform target;
    private int wavepointIndex = 0;
    private float oldPos = 0.0f;
    //public GameObject gm;
    public Image HealthBar;
    private float MaxHealth;
    private float healthChecker;

    void Start()
    {
        target = WayPoint.wayPoints[0];
        MaxHealth = health;
        if(proTrue)
        {
            health = health + 120;
        }
    }

    public void TakeDamage(int ammount)
    {
        health -= ammount;
        healthChecker = health / MaxHealth;
        HealthBar.fillAmount = healthChecker;
        if(health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        GameManager money = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        money.AddMoney(moneyHold);
        Destroy(gameObject);
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= .2f)
        {
            NextWay();
        }
        //Debug.Log("Dis:" + dir);

        if (dir.x < oldPos)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (dir.x > oldPos)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        oldPos = dir.x;

    }

    void NextWay()
    {
        if (wavepointIndex >= WayPoint.wayPoints.Length - 1)
        {
            PathEnd();
            return;
        }
        wavepointIndex++;
        target = WayPoint.wayPoints[wavepointIndex];
    }

    void PathEnd()
    {
        GameManager.lives--;
        Destroy(gameObject);
    }

    public void difficultyPro()
    {
        proTrue = true;
    }
 
}
