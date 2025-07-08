using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public BoardController boardController;

    // タイルのサイズと個数
    private const int gridSize = 4;
    private const float tileSize = 1f;
    private const float tileGroupWidth = tileSize * gridSize; // 1.0f

    void Start()
    {
        boardController.leftTiles = new Tile[gridSize, gridSize];
        boardController.rightTiles = new Tile[gridSize, gridSize];

        CreateTiles();
    }

    void CreateTiles()
    {
        // 左側
        Vector3 leftOrigin = new Vector3(-4.5f, -2f, 0);
        int id = 1;
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 pos = leftOrigin + new Vector3(x * tileSize, y * tileSize, 0);
                GameObject obj = Instantiate(tilePrefab, pos, Quaternion.identity);
                Tile tile = obj.GetComponent<Tile>();
                boardController.leftTiles[x, y] = tile;
                tile.id = id;
                id++;
            }
        }

        // 右側
        Vector3 rightOrigin = new Vector3(0.5f, -2f, 0);
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 pos = rightOrigin + new Vector3(x * tileSize, y * tileSize, 0);
                GameObject obj = Instantiate(tilePrefab, pos, Quaternion.identity);
                Tile tile = obj.GetComponent<Tile>();
                boardController.rightTiles[x, y] = tile;
                tile.id = id;
                id++;
            }
        }
    }

}