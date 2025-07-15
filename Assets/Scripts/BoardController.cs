using UnityEngine;

public class BoardController : MonoBehaviour
{
    public Tile[,] leftTiles = new Tile[4, 4];
    public Tile[,] rightTiles = new Tile[4, 4];

    private Vector2Int leftCursor = new Vector2Int(0, 0);
    private Vector2Int rightCursor = new Vector2Int(0, 0);

    public GameObject leftCursorObject;
    public GameObject rightCursorObject;

    private bool leftCleared = false;
    private bool rightCleared = false;

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

            if (!leftCleared && IsBoardMatched(leftTiles))
            {
                leftCleared = true;
                Debug.Log("🎉 左クリア！");
                // ここにクリア演出を追加
            }
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

            if (!rightCleared && IsBoardMatched(rightTiles))
            {
                rightCleared = true;
                Debug.Log("🎉 右クリア！");
                // ここにクリア演出を追加
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
                if (board[x, y].isOn != goal[x, y])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
