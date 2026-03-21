using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    [SerializeField]
    int width, height, xPos, yPos;
    [SerializeField] GameObject unitPrefab;
    Plant[,] plants;
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }
    void Start()
    {
        plants = new Plant[width, height];
        // InstantiateGrid();   
    }

    void InstantiateGrid()
    {
        for(int y = -height/2; y < height/2; y++)
        {
            for(int x = -width/2; x < width/2; x++)
            {
                Instantiate(unitPrefab, new Vector3(x + xPos/2, y + yPos/2, 0f), Quaternion.identity, transform).GetComponent<Transform>();
                
            }
        }
    }

    public bool IsInGrid(Vector2 pos)
    {
        Vector2 centeredPos = new(pos.x - xPos, pos.y - yPos);
        if(centeredPos.x >= width/2 || centeredPos.x < -width/2) return false;
        if(centeredPos.y >= height/2 || centeredPos.y < -height/2) return false;
        return true;
    }

    public Plant GetPlant(Vector2Int pos)
    {
        Vector2Int index = WorldToArrayPos(pos);
        
        return plants[index.x, index.y];
    }

    public void AddPlant(Vector2Int pos, Plant plant)
    {
        Vector2Int index = WorldToArrayPos(pos);
        plants[index.x, index.y] = plant;
    }

    public Vector2Int WorldToArrayPos(Vector2Int worldPos)
    {
        Vector2Int output = new(worldPos.x + width/2 - xPos, worldPos.y +height/2 - yPos);
        return output;
    }


}
