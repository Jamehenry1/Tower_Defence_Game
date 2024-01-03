using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;

    public float TileSize
    {
        get { return tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;  } 
    }

    // Start is called before the first frame update 
    void Start()
    {
        CreateLevel();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateLevel()
    {

        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for (int y = 0; y < 20; y++)
        {
            for (int x = 0; x < 30; x++)
            {
                PlaceTile(x, y, worldStart);
            }
        }
    }

    private void PlaceTile(int x, int y, Vector3 worldStartPosition)
    {
        GameObject newTile = Instantiate(tile);

        newTile.transform.position = new Vector3(worldStartPosition.x + (TileSize * x), worldStartPosition.y - (TileSize * y), 0);
        Vector3 vector3 = Vector3.one * 5;
        newTile.transform.localScale = vector3;
    }
}
