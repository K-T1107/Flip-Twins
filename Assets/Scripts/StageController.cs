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
        // DontDestroyOnLoad は不要（シーンごとに別オブジェクト）
        LoadStage();
    }

    private void LoadStage()
    {
        bool[,] stage = new bool[4, 4]
        {
            { false, false, false, false },
            { false, true,  true,  true  },
            { false, true,  true,  true  },
            { false, true,  true,  true  }
        };
        CopyPattern(stage);
    }

    private void CopyPattern(bool[,] src)
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                GoalPattern[x, y] = src[x, y];
            }
        }
    }
}