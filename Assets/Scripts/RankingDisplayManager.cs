using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class RankingEntry
{
    public string name;
    public int score;
}

public class RankingDisplayManager : MonoBehaviour
{
    public Text rankingText; // UI TextをInspectorで割り当てる

    void Start()
    {
        DisplayDummyRanking();
    }

    void DisplayDummyRanking()
    {
        // 疑似ランキングデータ
        RankingEntry[] rankings = new RankingEntry[]
        {
            new RankingEntry{ name="Alice", score=1 },
            new RankingEntry{ name="Bob", score=2 },
            new RankingEntry{ name="Carol", score=3 },
            new RankingEntry{ name="Dave", score=4 },
            new RankingEntry{ name="testuser", score=7 },
        };

        rankingText.text = "";
        for (int i = 0; i < rankings.Length; i++)
        {
            rankingText.text += $"{i + 1}. {rankings[i].name} - {rankings[i].score}\n";
        }
    }
}