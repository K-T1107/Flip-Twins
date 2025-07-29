using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSelectStage()
    {
        //ステージセレクト
        UnityEngine.SceneManagement.SceneManager.LoadScene("SelectStageScene");
    }

    public void TitleScene()
    {
        //オプション画面に遷移
        SceneManager.LoadScene("TitleScene");
    }

    public void OptionScene()
    {
        //オプション画面に遷移
        SceneManager.LoadScene("OptionScene");
    }

    public void LoadStage1()
    {
        //ステージ１に遷移
        SceneManager.LoadScene("Stage1Scene");
    }

    public void LoadStage2()
    {
        //ステージ１に遷移
        SceneManager.LoadScene("Stage2Scene");
    }
}