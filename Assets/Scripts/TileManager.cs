using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public BoardController boardController;
    public int stageNumber = 1;

    private const int gridSize = 4;
    private const float tileSize = 2f;

    void Start()
    {
        boardController.leftTiles = new Tile[gridSize, gridSize];
        boardController.rightTiles = new Tile[gridSize, gridSize];

        // ゴールパターンを生成
        bool[,] goal = GetGoalPattern(stageNumber);
        // BoardControllerに渡す
        boardController.SetGoalPattern(goal);

        CreateTiles(goal);
    }

    void CreateTiles(bool[,] goal)
    {
        Vector3 leftOrigin = new Vector3(-14f, -4f, 0);
        Vector3 centerOrigin = new Vector3(-3.5f, -4f, 0);
        Vector3 rightOrigin = new Vector3(7f, -4f, 0);

        // 左側
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

        // 真ん中（お題）
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

        // 右側
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 pos = rightOrigin + new Vector3(x * tileSize, y * tileSize, 0);
                GameObject obj = Instantiate(tilePrefab, pos, Quaternion.identity);
                obj.transform.localScale = new Vector3(2f, 2f, 1f);
                Tile tile = obj.GetComponent<Tile>();
                tile.Initialize();
                tile.isOn = false;
                tile.UpdateSprite();
                boardController.rightTiles[x, y] = tile;
            }
        }
    }

    bool[,] GetGoalPattern(int stage)
    {
        switch (stage)
        {
            case 1:
                return new bool[gridSize, gridSize]
                {
                    { false, true, true, true },
                    { false, true, true, true },
                    { false, true, true, true },
                    { false, false, false, false }
                };
            case 2:
                return new bool[gridSize, gridSize]
                {
            { false, false, false, false },
            { true, true, true, true },
            { true, true, true, true },
            { true, true, true, true }
                };
            case 3:
                return new bool[gridSize, gridSize]
                {
            { true, true, true, true },
            { false, false, false, false },
            { false, false, false, false },
            { false, false, false, false }
                };
            case 4:
                return new bool[gridSize, gridSize]
                {
            { true, true, false, false },
            { true, true, false, false },
            { true, false, true, true },
            { true, false, true, true }
                };
            case 5:
                return new bool[gridSize, gridSize]
                {
            { false, false, false, false },
            { false, true, false, true },
            { false, true, false, true },
            { false, true, false, true }
                };
            case 6:
                return new bool[gridSize, gridSize]
                {
            { true, true, false, true },
            { false, false, false, false },
            { false, false, false, false },
            { false, false, false, false }
                };
            case 7:
                return new bool[gridSize, gridSize]
                {
            { false, true, false, true },
            { false, false, true, false },
            { false, false, true, false },
            { false, true, false, true }
                };
            case 8:
                return new bool[gridSize, gridSize]
                {
            { false, false, false, false },
            { true, true, true, true },
            { false, false, false, false },
            { true, true, true, true }
                };
            case 9:
                return new bool[gridSize, gridSize]
                {
            { true, true, false, true },
            { false, true, true, false },
            { false, true, true, false },
            { true, false, true, true }
                };
            case 10:
                return new bool[gridSize, gridSize]
                {
            { false, true, true, false },
            { true, true, true, true },
            { true, true, true, true },
            { false, true, true, false }
                };
            default:
                return new bool[gridSize, gridSize];
        }
    }
}
