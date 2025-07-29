using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public TextMeshProUGUI clearText;
    public Button toSelectButton;
    public Button toNextButton;

    void Start()
    {
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

    //左側の操作
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
                // ここにクリア演出を追加
            }
        }
    }

    //右側の操作
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
                // ここにクリア演出を追加
            }
        }
    }

    //カーソルの設定
    void UpdateCursorPosition()
    {
        Tile lt = leftTiles[leftCursor.x, leftCursor.y];
        if (lt != null) leftCursorObject.transform.position = lt.transform.position;

        Tile rt = rightTiles[rightCursor.x, rightCursor.y];
        if (rt != null) rightCursorObject.transform.position = rt.transform.position;
    }

    //もしお題と合っていたら
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

    //合ってるかどうかの判断
    public void CheckClear()
    {
        bool isCleared = true;
        bool[,] goal = StageController.Instance.GoalPattern;

        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                // 左右のタイルが goal と一致していなければクリアじゃない
                if (leftTiles[x, y].isOn != goal[x, y] || rightTiles[x, y].isOn != goal[x, y])
                {
                    isCleared = false;
                    break;
                }
            }
            if (!isCleared) break;
        }

        if (isCleared)
        {
            // タイマー停止
            TimerManager timerManager = FindObjectOfType<TimerManager>();
            if (timerManager != null)
            {
                timerManager.StopTimer();
            }

            Debug.Log("クリア！！！");
            clearText.gameObject.SetActive(true);
            toSelectButton.gameObject.SetActive(true);
            toNextButton.gameObject.SetActive(true);
            //ここで演出や次のステージ処理を追加
        }
    }
}
