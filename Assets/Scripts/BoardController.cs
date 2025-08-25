using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoardController : MonoBehaviour
{
    public Tile[,] leftTiles = new Tile[4, 4];
    public Tile[,] rightTiles = new Tile[4, 4];

    public Transform leftParent;   // 左のタイルをまとめる親
    public Transform rightParent;  // 右のタイルをまとめる親

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
        // 親オブジェクトからタイルを自動登録
        AutoAssignTiles(leftParent, leftTiles);
        AutoAssignTiles(rightParent, rightTiles);

        clearText.gameObject.SetActive(false);
        toSelectButton.gameObject.SetActive(false);
        toNextButton.gameObject.SetActive(false);
    }

    void Update()
    {
        HandleLeftInput();
        HandleRightInput();
        UpdateCursorPosition();
    }

    void AutoAssignTiles(Transform parent, Tile[,] tiles)
    {
        Tile[] found = parent.GetComponentsInChildren<Tile>();
        if (found.Length != 16)
            Debug.LogWarning("タイル数が16枚ではありません！");

        foreach (Tile tile in found)
        {
            Vector2 pos = tile.transform.localPosition;
            int x = Mathf.RoundToInt((pos.x + 3f) / 2f); // 座標を0-3に変換
            int y = Mathf.RoundToInt((pos.y + 3f) / 2f);
            if (x >= 0 && x < 4 && y >= 0 && y < 4)
            {
                tiles[x, y] = tile;
            }
            else
            {
                Debug.LogWarning($"{tile.name} がグリッド範囲外です");
            }
        }
    }

    // 左操作
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

            if (!leftCleared && IsBoardMatched(leftTiles))
            {
                leftCleared = true;
                Debug.Log("左クリア！");
                CheckClear();
            }
        }
    }

    // 右操作
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

            if (!rightCleared && IsBoardMatched(rightTiles))
            {
                rightCleared = true;
                Debug.Log("右クリア！");
                CheckClear();
            }
        }
    }

    void UpdateCursorPosition()
    {
        Tile lt = leftTiles[leftCursor.x, leftCursor.y];
        if (lt != null) leftCursorObject.transform.position = lt.transform.position;

        Tile rt = rightTiles[rightCursor.x, rightCursor.y];
        if (rt != null) rightCursorObject.transform.position = rt.transform.position;
    }

    public bool IsBoardMatched(Tile[,] board)
    {
        bool[,] goal = StageController.Instance.GoalPattern;

        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                if (board[x, y] == null || board[x, y].isOn != goal[x, y])
                    return false;
            }
        }
        return true;
    }

    public void CheckClear()
    {
        bool isCleared = leftCleared && rightCleared;
        if (isCleared)
        {
            TimerManager timerManager = FindObjectOfType<TimerManager>();
            if (timerManager != null)
                timerManager.StopTimer();

            Debug.Log("クリア！！！");

            clearText.gameObject.SetActive(true);
            toSelectButton.gameObject.SetActive(true);
            toNextButton.gameObject.SetActive(true);
        }
    }
}