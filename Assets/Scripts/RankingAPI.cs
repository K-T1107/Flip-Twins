using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class RankingAPI : MonoBehaviour
{
    private string apiUrl = "http://localhost/api/ranking"; // LaravelのURL

    public void SendRanking(string playerName, int gameOverCount, int retryCount)
    {
        StartCoroutine(PostRanking(playerName, gameOverCount, retryCount));
    }

    IEnumerator PostRanking(string playerName, int gameOverCount, int retryCount)
    {
        // JSONデータを作成
        string json = JsonUtility.ToJson(new RankingData(playerName, gameOverCount, retryCount));
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("送信成功: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("送信失敗: " + request.error);
        }
    }
    public void GetRanking()
    {
        StartCoroutine(GetRankingCoroutine());
    }

    IEnumerator GetRankingCoroutine()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("取得成功: " + request.downloadHandler.text);
            // ここで JSON をパースしてランキングに反映させる
        }
        else
        {
            Debug.LogError("取得失敗: " + request.error);
        }
    }

}

[System.Serializable]
public class RankingData
{
    public string name;
    public int game_over_count;
    public int retry_count;

    public RankingData(string name, int gameOver, int retry)
    {
        this.name = string.IsNullOrEmpty(name) ? "user_" + Random.Range(1000, 9999) : name;
        this.game_over_count = gameOver;
        this.retry_count = retry;
    }
}