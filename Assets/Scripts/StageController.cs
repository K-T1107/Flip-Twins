using UnityEngine;

public class StageController : MonoBehaviour
{
    public static StageController Instance { get; private set; }

    public bool[,] GoalPattern { get; private set; } = new bool[4, 4];

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        LoadStage1();
    }

    private void LoadStage1()
    {
        bool[,] stage1 = new bool[4, 4]
        {
            { true, false, false, true },
            { false, true, true, false },
            { false, true, true, false },
            { true, false, false, true }
        };

        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                GoalPattern[x, y] = stage1[x, y];
            }
        }
    }
}