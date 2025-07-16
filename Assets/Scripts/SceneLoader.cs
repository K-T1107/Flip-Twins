using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSelectStage()
    {
        //ステージセレクト
        UnityEngine.SceneManagement.SceneManager.LoadScene("SelectStageScene");
    }

    public void LoadStage1()
    {
        //ステージ１に遷移
        SceneManager.LoadScene("Stage1Scene");
    }
}