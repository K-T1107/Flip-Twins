using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// データ1件
[System.Serializable]
public class RankData
{
    public string name;
    public int score;
}

// データリスト（JSONラップ用）
[System.Serializable]
public class RankList
{
    public List<RankData> ranks;
}

public class RankingManager : MonoBehaviour
{
    [Header("PHP API URL")]
    public string url = "http://localhost:8000/ranking.php"; // 自分の環境に合わせて

    [Header("ランキング表示用Text")]
    public Text rankingText; // CanvasのTextをInspectorでアサイン

    void Start()
    {
        StartCoroutine(GetRanking());
    }

    IEnumerator GetRanking()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // JSON配列をラップしてパース
            string json = "{\"ranks\":" + request.downloadHandler.text + "}";
            RankList list = JsonUtility.FromJson<RankList>(json);

            // Text に表示
            rankingText.text = "ランキング\n\n";
            int rank = 1;
            foreach (var r in list.ranks)
            {
                rankingText.text += $"{rank}. {r.name} : {r.score}\n";
                rank++;
            }
        }
        else
        {
            rankingText.text = "ランキング取得エラー";
            Debug.LogError(request.error);
        }
    }
}
