using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager Instance { get; private set; }

    public int CurrentStage = 1;

    public bool[,] LeftPattern { get; private set; } = new bool[4, 4];
    public bool[,] RightPattern { get; private set; } = new bool[4, 4];
    public bool[,] GoalPattern { get; private set; } = new bool[4, 4];

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        LoadStage(CurrentStage);
    }

    public void LoadStage(int stage)
    {
        // 全部表で初期化
        for (int x = 0; x < 4; x++)
            for (int y = 0; y < 4; y++)
                LeftPattern[x, y] = RightPattern[x, y] = GoalPattern[x, y] = false;

        switch (stage)
        {
            case 1: // かなり簡単
                GoalPattern = new bool[4, 4] {
                    { false, false, false, false },
                    { false, true,  false, false },
                    { false, false, false, false },
                    { false, false, false, false }
                };
                LeftPattern[0, 0] = true; // 左1枚だけ裏
                break;

            case 2:
                GoalPattern = new bool[4, 4] {
                    { false, false, false, false },
                    { false, true, true, false },
                    { false, false, false, false },
                    { false, false, false, false }
                };
                LeftPattern[0, 0] = true;
                RightPattern[3, 3] = true;
                break;

            case 3:
                GoalPattern = new bool[4, 4] {
                    { false, true, false, false },
                    { false, true, true, false },
                    { false, false, true, false },
                    { false, false, false, false }
                };
                LeftPattern[0, 0] = LeftPattern[1, 1] = true;
                RightPattern[3, 3] = true;
                break;

            case 4:
                GoalPattern = new bool[4, 4] {
                    { false, true, false, true },
                    { true, false, true, false },
                    { false, true, false, true },
                    { true, false, true, false }
                };
                LeftPattern[0, 0] = LeftPattern[2, 1] = true;
                RightPattern[1, 2] = RightPattern[3, 0] = true;
                break;

            case 5:
                GoalPattern = new bool[4, 4] {
                    { true, false, true, false },
                    { false, true, false, true },
                    { true, false, true, false },
                    { false, true, false, true }
                };
                LeftPattern[0, 0] = LeftPattern[1, 1] = LeftPattern[2, 2] = true;
                RightPattern[0, 3] = RightPattern[3, 0] = true;
                break;

            case 6:
                GoalPattern = new bool[4, 4] {
                    { true, false, true, false },
                    { true, true, false, false },
                    { false, true, true, false },
                    { false, false, true, true }
                };
                LeftPattern[0, 0] = LeftPattern[1, 1] = LeftPattern[2, 2] = true;
                RightPattern[0, 2] = RightPattern[3, 1] = true;
                break;

            case 7:
                GoalPattern = new bool[4, 4] {
                    { true, true, false, false },
                    { false, true, true, false },
                    { false, false, true, true },
                    { true, false, false, true }
                };
                LeftPattern[0, 0] = LeftPattern[1, 1] = LeftPattern[2, 2] = LeftPattern[3, 3] = true;
                RightPattern[0, 3] = RightPattern[1, 2] = RightPattern[2, 1] = RightPattern[3, 0] = true;
                break;

            case 8:
                GoalPattern = new bool[4, 4] {
                    { true, false, true, false },
                    { false, true, false, true },
                    { true, false, true, false },
                    { false, true, false, true }
                };
                LeftPattern[0, 0] = LeftPattern[0, 1] = LeftPattern[1, 0] = LeftPattern[1, 1] = true;
                RightPattern[2, 2] = RightPattern[2, 3] = RightPattern[3, 2] = RightPattern[3, 3] = true;
                break;

            case 9:
                GoalPattern = new bool[4, 4] {
                    { false, true, true, false },
                    { true, false, false, true },
                    { false, true, true, false },
                    { true, false, false, true }
                };
                LeftPattern[0, 0] = LeftPattern[1, 0] = LeftPattern[2, 1] = true;
                RightPattern[1, 2] = RightPattern[2, 3] = RightPattern[3, 0] = true;
                break;

            case 10:
                GoalPattern = new bool[4, 4] {
                    { true, false, false, true },
                    { true, true, false, false },
                    { false, true, true, false },
                    { false, false, true, true }
                };
                LeftPattern[0, 0] = LeftPattern[1, 1] = LeftPattern[2, 2] = true;
                RightPattern[0, 3] = RightPattern[1, 2] = RightPattern[2, 1] = RightPattern[3, 0] = true;
                break;

            case 11:
                GoalPattern = new bool[4, 4] {
                    { false, true, false, true },
                    { true, false, true, false },
                    { false, true, false, true },
                    { true, false, true, false }
                };
                LeftPattern[0, 0] = LeftPattern[1, 1] = LeftPattern[2, 2] = LeftPattern[3, 3] = true;
                RightPattern[0, 1] = RightPattern[1, 2] = RightPattern[2, 3] = RightPattern[3, 0] = true;
                break;

            case 12:
                GoalPattern = new bool[4, 4] {
                    { true, true, false, false },
                    { false, true, true, false },
                    { false, false, true, true },
                    { true, false, false, true }
                };
                LeftPattern[0, 0] = LeftPattern[1, 0] = LeftPattern[2, 1] = LeftPattern[3, 2] = true;
                RightPattern[0, 3] = RightPattern[1, 2] = RightPattern[2, 1] = RightPattern[3, 0] = true;
                break;

            case 13:
                GoalPattern = new bool[4, 4] {
                    { true, false, true, false },
                    { false, true, false, true },
                    { true, false, true, false },
                    { false, true, false, true }
                };
                LeftPattern[0, 0] = LeftPattern[0, 1] = LeftPattern[1, 0] = LeftPattern[1, 1] = true;
                RightPattern[2, 2] = RightPattern[2, 3] = RightPattern[3, 2] = RightPattern[3, 3] = true;
                break;

            case 14:
                GoalPattern = new bool[4, 4] {
                    { false, true, false, true },
                    { true, false, true, false },
                    { false, true, false, true },
                    { true, false, true, false }
                };
                LeftPattern[0, 0] = LeftPattern[1, 1] = LeftPattern[2, 2] = LeftPattern[3, 3] = true;
                RightPattern[0, 3] = RightPattern[1, 2] = RightPattern[2, 1] = RightPattern[3, 0] = true;
                break;

            case 15:
                GoalPattern = new bool[4, 4] {
                    { true, false, true, false },
                    { true, true, false, false },
                    { false, true, true, false },
                    { false, false, true, true }
                };
                LeftPattern[0, 0] = LeftPattern[0, 1] = LeftPattern[1, 0] = LeftPattern[1, 1] = true;
                RightPattern[2, 2] = RightPattern[2, 3] = RightPattern[3, 2] = RightPattern[3, 3] = true;
                break;

            default:
                break;
        }

        Debug.Log($"Stage {stage} の初期パターンをロードしました");
    }
}