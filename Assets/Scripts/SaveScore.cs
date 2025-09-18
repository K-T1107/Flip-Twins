using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SaveScore : MonoBehaviour
{
    IEnumerator SaveScores(int userId, int stageId, int gameOverCount)
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", userId);
        form.AddField("stage_id", stageId);
        form.AddField("game_over_count", gameOverCount);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/api/save_score.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
                Debug.Log("Score Saved: " + www.downloadHandler.text);
            else
                Debug.LogError("Error: " + www.error);
        }
    }
}
