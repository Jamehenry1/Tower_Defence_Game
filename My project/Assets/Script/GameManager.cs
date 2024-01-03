using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{
    public TowerBtn ClickedBtn { get; set; }
   

    private int currency;
    
    
    public static int lives;
    public Text livesText;
    [SerializeField]
    private Text currencyText;
    private bool gameEnd = false;

    //public Text sellText;

    public string losingScene;

    public int Currency
    {
        get
        {
            return currency;
        }

        set
        {
            this.currency = value;
            this.currencyText.text = value.ToString() + "<color=lime>$</color>";
        }
    }

    void Start()
    {
        //This is where we set the curency
        lives = 3;
        Currency = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd)
        {
            return;
        }
        livesText.text = "Health: " + lives;
        if (lives <= 0)
        {
            EndGame();
        }
        HandleEscape();
    }

    public void PickTower(TowerBtn towerBtn)
    {
        if (Currency >= towerBtn.Price)
        {
            this.ClickedBtn = towerBtn;
            Hover.Instance.Activate(towerBtn.Sprite);
        }
        
    }

    public void BuyTower()
    {
        if (Currency >= ClickedBtn.Price)
        {
            Currency -= ClickedBtn.Price;
            Hover.Instance.Deactivate();
        }
    }

    private void HandleEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hover.Instance.Deactivate();
        }
    }

    void EndGame()
    {
        gameEnd = true;
        SceneManager.LoadScene(losingScene);
        Debug.Log("End Game");
    }

    public void AddMoney(int money)
    {
        Currency += money;
        
    }

    public void ReduceMoney(int money)
    {
        if (Currency > money)
        {
            Currency -= money;
        }
        
    }
}
