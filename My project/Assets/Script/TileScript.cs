using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Point GridPosition { get; private set; }

    public bool IsEmpty { get; set; }

    private Color32 fullColor = new Color32(255, 118, 118, 255);
    private Color32 emptyColor = new Color32(96, 255, 90, 255);

    private SpriteRenderer spriteRenderer;

    //public SpriteRenderer SpriteRenderer { get; set; }

    public Vector2 WorldPosition
    {
        get 
        {
            return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2), transform.position.y);

        }
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Point gridPos, Vector3 worldPos, Transform parent)
    {
        IsEmpty = true;
        this.GridPosition = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
        LevelMan.Instance.Tiles.Add(gridPos, this);
    }

    private void OnMouseOver()
    {
        //ColorTile(fullColor);

        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedBtn != null)
        {
            //Where
            if ((IsEmpty && spriteRenderer.sprite.name == "grass") ||(IsEmpty && spriteRenderer.sprite.name == "grass_flowers1"))
            {
                ColorTile(emptyColor);
            }
            if(!IsEmpty)
            {
                ColorTile(fullColor);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                if (spriteRenderer.sprite.name == "grass")
                {
                    PlaceTower();
                }
                
            }
        }
        
    }

    private void OnMouseExit()
    {
        ColorTile(Color.white);
    }

    private void PlaceTower()
    {

        GameObject tower = (GameObject)Instantiate(GameManager.Instance.ClickedBtn.TowerPrefab, transform.position, Quaternion.identity);
        tower.GetComponent<SpriteRenderer>().sortingOrder = GridPosition.y;
        tower.transform.SetParent(transform);

        IsEmpty = false;

        ColorTile(Color.white);
        GameManager.Instance.BuyTower();
    }

    private void ColorTile(Color newColor)
    {
        spriteRenderer.color = newColor;
    }
}
