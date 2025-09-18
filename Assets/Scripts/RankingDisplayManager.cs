using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// 1人分のランキングデータ（クラス名をユニーク化）
[System.Serializable]
public class RankingEntry
{
    public string playerName;
    public int gameOverCount;
}

// ランキングリスト（JSONラップ用、クラス名をユニーク化）
[System.Serializable]
public class RankingCollection
{
    public List<RankingEntry> ranks;
}

public class RankingDisplayManager : MonoBehaviour
{
    [Header("PHP API URL")]
    public string url = "http://localhost:8080/ranking.php?stage_id=1"; // 必要に応じて変更

    [Header("ランキング表示用Text")]
    public Text rankingText; // Canvas上のTextをInspectorでアサイン

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
            RankingCollection list = JsonUtility.FromJson<RankingCollection>(json);

            // Text に表示
            rankingText.text = "ランキング\n\n";
            int rank = 1;
            foreach (var r in list.ranks)
            {
                rankingText.text += $"{rank}. {r.playerName} : {r.gameOverCount}\n";
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