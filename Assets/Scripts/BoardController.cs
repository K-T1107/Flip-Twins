using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoardController : MonoBehaviour
{
    public GameObject tilePrefab;

    public Tile[,] leftTiles = new Tile[4, 4];
    public Tile[,] rightTiles = new Tile[4, 4];

    private Vector2Int leftCursor = new Vector2Int(0, 0);
    private Vector2Int rightCursor = new Vector2Int(0, 0);

    public GameObject leftCursorObject;
    public GameObject rightCursorObject;

    private bool leftCleared = false;
    private bool rightCleared = false;

    public TextMeshProUGUI clearText;
    public Button toSelectButton;
    public Button toNextButton;

    void Start()
    {
        clearText.gameObject.SetActive(false);
        toSelectButton.gameObject.SetActive(false);
        toNextButton.gameObject.SetActive(false);

        CreateTiles();
    }

    void CreateTiles()
    {
        Vector3 leftOrigin = new Vector3(-14f, -4f, 0);
        Vector3 centerOrigin = new Vector3(-3.5f, -4f, 0);
        Vector3 rightOrigin = new Vector3(7f, -4f, 0);

        TileManager tm = TileManager.Instance;

        // 左
        for (int x = 0; x < 4; x++)
            for (int y = 0; y < 4; y++)
            {
                Vector3 pos = leftOrigin + new Vector3(x * 2f, y * 2f, 0);
                GameObject obj = Instantiate(tilePrefab, pos, Quaternion.identity);
                Tile tile = obj.GetComponent<Tile>();
                tile.Initialize();
                tile.isOn = tm.LeftPattern[x, y];
                tile.UpdateSprite();
                leftTiles[x, y] = tile;
            }

        // 中央（お題）
        for (int x = 0; x < 4; x++)
            for (int y = 0; y < 4; y++)
            {
                Vector3 pos = centerOrigin + new Vector3(x * 2f, y * 2f, 0);
                GameObject obj = Instantiate(tilePrefab, pos, Quaternion.identity);
                Tile tile = obj.GetComponent<Tile>();
                tile.Initialize();
                tile.isOn = tm.GoalPattern[x, y];
                tile.isLocked = true;
                tile.UpdateSprite();
            }

        // 右
        for (int x = 0; x < 4; x++)
            for (int y = 0; y < 4; y++)
            {
                Vector3 pos = rightOrigin + new Vector3(x * 2f, y * 2f, 0);
                GameObject obj = Instantiate(tilePrefab, pos, Quaternion.identity);
                Tile tile = obj.GetComponent<Tile>();
                tile.Initialize();
                tile.isOn = tm.RightPattern[x, y];
                tile.UpdateSprite();
                rightTiles[x, y] = tile;
            }
    }

    void Update()
    {
        HandleLeftInput();
        HandleRightInput();
        UpdateCursorPosition();
    }

    void HandleLeftInput()
    {
        if (Input.GetKeyDown(KeyCode.W)) leftCursor.y = Mathf.Clamp(leftCursor.y + 1, 0, 3);
        if (Input.GetKeyDown(KeyCode.S)) leftCursor.y = Mathf.Clamp(leftCursor.y - 1, 0, 3);
        if (Input.GetKeyDown(KeyCode.A)) leftCursor.x = Mathf.Clamp(leftCursor.x - 1, 0, 3);
        if (Input.GetKeyDown(KeyCode.D)) leftCursor.x = Mathf.Clamp(leftCursor.x + 1, 0, 3);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tile selected = leftTiles[leftCursor.x, leftCursor.y];
            if (selected != null) selected.Trigger();
        }
    }

    void HandleRightInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) rightCursor.y = Mathf.Clamp(rightCursor.y + 1, 0, 3);
        if (Input.GetKeyDown(KeyCode.DownArrow)) rightCursor.y = Mathf.Clamp(rightCursor.y - 1, 0, 3);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) rightCursor.x = Mathf.Clamp(rightCursor.x - 1, 0, 3);
        if (Input.GetKeyDown(KeyCode.RightArrow)) rightCursor.x = Mathf.Clamp(rightCursor.x + 1, 0, 3);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Tile selected = rightTiles[rightCursor.x, rightCursor.y];
            if (selected != null) selected.Trigger();
        }
    }

    void UpdateCursorPosition()
    {
        leftCursorObject.transform.position = leftTiles[leftCursor.x, leftCursor.y].transform.position;
        rightCursorObject.transform.position = rightTiles[rightCursor.x, rightCursor.y].transform.position;
    }

    public void OnTileTriggered()
    {
        TileManager tm = TileManager.Instance;
        leftCleared = IsBoardMatched(leftTiles, tm.GoalPattern);
        rightCleared = IsBoardMatched(rightTiles, tm.GoalPattern);

        CheckClear();
    }

    bool IsBoardMatched(Tile[,] board, bool[,] goal)
    {
        for (int x = 0; x < 4; x++)
            for (int y = 0; y < 4; y++)
                if (board[x, y].isOn != goal[x, y])
                    return false;
        return true;
    }

    void CheckClear()
    {
        if (leftCleared && rightCleared)
        {
            TimerManager timer = FindObjectOfType<TimerManager>();
            if (timer != null) timer.StopTimer();

            clearText.gameObject.SetActive(true);
            toSelectButton.gameObject.SetActive(true);
            toNextButton.gameObject.SetActive(true);
            Debug.Log("クリア！");
        }
    }
}
