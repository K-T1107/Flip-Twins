using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// 1�l���̃����L���O�f�[�^�i�N���X�������j�[�N���j
[System.Serializable]
public class RankingEntry
{
    public string playerName;
    public int gameOverCount;
}

// �����L���O���X�g�iJSON���b�v�p�A�N���X�������j�[�N���j
[System.Serializable]
public class RankingCollection
{
    public List<RankingEntry> ranks;
}

public class RankingDisplayManager : MonoBehaviour
{
    [Header("PHP API URL")]
    public string url = "http://localhost:8080/ranking.php?stage_id=1"; // �K�v�ɉ����ĕύX

    [Header("�����L���O�\���pText")]
    public Text rankingText; // Canvas���Text��Inspector�ŃA�T�C��

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
            // JSON�z������b�v���ăp�[�X
            string json = "{\"ranks\":" + request.downloadHandler.text + "}";
            RankingCollection list = JsonUtility.FromJson<RankingCollection>(json);

            // Text �ɕ\��
            rankingText.text = "�����L���O\n\n";
            int rank = 1;
            foreach (var r in list.ranks)
            {
                rankingText.text += $"{rank}. {r.playerName} : {r.gameOverCount}\n";
                rank++;
            }
        }
        else
        {
            rankingText.text = "�����L���O�擾�G���[";
            Debug.LogError(request.error);
        }
    }
}