using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public BoardController boardController;
    public Tile tile;

    private const int gridSize = 4;
    private const float tileSize = 2f;

    void Start()
    {
        boardController.leftTiles = new Tile[gridSize, gridSize];
        boardController.rightTiles = new Tile[gridSize, gridSize];

        CreateTiles();
    }

    void CreateTiles()
    {
        bool[,] goal = StageController.Instance.GoalPattern;

        Vector3 leftOrigin = new Vector3(-14f, -4f, 0);
        Vector3 centerOrigin = new Vector3(-3.5f, -4f, 0);
        Vector3 rightOrigin = new Vector3(7f, -4f, 0);

        //ç∂
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 pos = leftOrigin + new Vector3(x * tileSize, y * tileSize, 0);
                GameObject obj = Instantiate(tilePrefab, pos, Quaternion.identity);
                obj.transform.localScale = new Vector3(2f, 2f, 1f);
                Tile tile = obj.GetComponent<Tile>();
                tile.Initialize();
                tile.isOn = false;
                tile.UpdateSprite();
                boardController.leftTiles[x, y] = tile;
            }
        }

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 pos = centerOrigin + new Vector3(x * tileSize, y * tileSize, 0);
                GameObject obj = Instantiate(tilePrefab, pos, Quaternion.identity);
                obj.transform.localScale = new Vector3(2f, 2f, 1f);
                Tile tile = obj.GetComponent<Tile>();
                tile.Initialize();
                tile.isOn = goal[x, y];
                tile.isLocked = true;
                tile.UpdateSprite();
            }
        }

        //âE
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 pos = rightOrigin + new Vector3(x * tileSize, y * tileSize, 0);
                GameObject obj = Instantiate(tilePrefab, pos, Quaternion.identity);
                obj.transform.localScale = new Vector3(2f, 2f, 1f);
                Tile tile = obj.GetComponent<Tile>();
                tile.isOn = false;
                tile.UpdateSprite();
                boardController.rightTiles[x, y] = tile;
            }
        }

        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                Debug.Log($"goal[{x},{y}] = {goal[x, y]}");
            }
        }
    }
}