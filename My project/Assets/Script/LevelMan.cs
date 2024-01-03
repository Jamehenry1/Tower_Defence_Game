using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelMan : Singleton<LevelMan>
{
    [SerializeField]
    private GameObject[] tilePrefabs;

    [SerializeField]
    private CamMove cameraMovement;

    [SerializeField]
    private Transform map;

    private Point portal, castle;

    [SerializeField]
    private GameObject portalPre;

    [SerializeField]
    private GameObject castlePre;

    public Dictionary<Point,TileScript> Tiles { get; set; }

    public float TileSize
    {
        get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }
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

        Tiles = new Dictionary<Point, TileScript>();
        string[] mapData = ReadText();


        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;

        Vector3 maxTile = Vector3.zero;

        Vector3 WSP = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for (int y = 0; y < mapY; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();

            for (int x = 0; x < mapX; x++)
            {
                PlaceTile(newTiles[x].ToString(),x, y, WSP);           
            }
        }

        maxTile = Tiles[new Point(mapX - 1, mapY - 1)].transform.position;

        cameraMovement.SetLim(new Vector3(maxTile.x + TileSize, maxTile.y - TileSize ));

        SpawnPortal();
    }

    private void PlaceTile(string tileType, int x, int y, Vector3 WSP)
    {
        int tileIndex = int.Parse(tileType);
        TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();

        newTile.Setup(new Point(x, y), new Vector3(WSP.x + TileSize * x, WSP.y - (TileSize * y), 0),map);

    }

    private string[] ReadText()
    {
        TextAsset bindData = Resources.Load("Level.txt") as TextAsset;
        string data = bindData.text.Replace(Environment.NewLine, string.Empty);

        return data.Split('-');
    }

    private void SpawnPortal()
    {
        portal = new Point(0, 3);
        castle = new Point(3, 14);
        //Instantiate(portalPre, Tiles[portal].transform.position, Quaternion.identity);
        Instantiate(portalPre, Tiles[portal].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
        Instantiate(castlePre, Tiles[castle].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
    }
}
