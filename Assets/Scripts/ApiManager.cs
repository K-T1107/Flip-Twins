using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// �f�[�^1��
[System.Serializable]
public class RankData
{
    public string name;
    public int score;
}

// �f�[�^���X�g�iJSON���b�v�p�j
[System.Serializable]
public class RankList
{
    public List<RankData> ranks;
}

public class RankingManager : MonoBehaviour
{
    [Header("PHP API URL")]
    public string url = "http://localhost:8000/ranking.php"; // �����̊��ɍ��킹��

    [Header("�����L���O�\���pText")]
    public Text rankingText; // Canvas��Text��Inspector�ŃA�T�C��

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
            RankList list = JsonUtility.FromJson<RankList>(json);

            // Text �ɕ\��
            rankingText.text = "�����L���O\n\n";
            int rank = 1;
            foreach (var r in list.ranks)
            {
                rankingText.text += $"{rank}. {r.name} : {r.score}\n";
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
