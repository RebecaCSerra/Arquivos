using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciaGrid : MonoBehaviour
{
    public List<Sprite> Sprites = new List<Sprite>();
    public GameObject TilePrefab;
    public int GridDimension = 6;
    public float Distance = 0.5f;
    private GameObject[,] Grid;
 
    //public int[,] grid = { { 1, 2, 3, 4 }, { 1, 2, 3, 4 } };
    // Start is called before the first frame update
    void InitGrid()
    {
        Vector3 positionOffset = transform.position - new Vector3(GridDimension * Distance / 2f, GridDimension * Distance / 2f, 0); // 1
        for (int row = 0; row < GridDimension; row++)
            for (int column = 0; column < GridDimension; column++) // 2
            {
                GameObject newTile = Instantiate(TilePrefab); // 3
                SpriteRenderer renderer = newTile.GetComponent<SpriteRenderer>(); // 4
                renderer.sprite = Sprites[Random.Range(0, Sprites.Count)]; // 5
                newTile.transform.parent = transform; // 6
                newTile.transform.position = new Vector3(column * Distance, row * Distance, 0) + positionOffset; // 7

                Grid[column, row] = newTile; // 8




                List<Sprite> possibleSprite = new List<Sprite>(); // 1

                //Choose what sprite to use for this cell
                Sprite Element0 = GetSpriteAt(column - 1, row); //2
                Sprite Element1 = GetSpriteAt(column - 2, row);
                if (Element1 != null && Element0 == Element1) // 3
                {
                    possibleSprite.Remove(Element0); // 4
                }
                Sprite Element2 = GetSpriteAt(column, row - 1); // 5
                Sprite Element3 = GetSpriteAt(column, row - 2);
                if (Element3 != null && Element2 == Element3)

                    possibleSprite.Remove(Element2);
            }
    }
    void Start()
    {
        Grid = new GameObject[GridDimension, GridDimension];
        print("chamou o start");
        InitGrid();
    }

    // Update is called once per frame
    void Update()
    {

    }
    Sprite GetSpriteAt(int column, int row)
    {
        if (column < 0 || column >= GridDimension
            || row < 0 || row >= GridDimension)
            return null;
        GameObject tile = Grid[column, row];
        SpriteRenderer renderer = tile.GetComponent<SpriteRenderer>();
        return renderer.sprite;
    }
}