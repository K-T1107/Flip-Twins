using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetRanking : MonoBehaviour
{
    IEnumerator GetRankings()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/api/get_ranking.php"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Ranking: " + www.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error: " + www.error);
            }
        }
    }
}
