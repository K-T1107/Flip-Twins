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

    public void TutorialScene()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void LoadStage1()
    {
        //ステージ１に遷移
        SceneManager.LoadScene("Stage1Scene");
    }

    public void LoadStage2()
    {
        //ステージ2に遷移
        SceneManager.LoadScene("Stage2Scene");
    }

    public void LoadStage3()
    {
        //ステージ2に遷移
        SceneManager.LoadScene("Stage3Scene");
    }

    public void LoadStage4()
    {
        //ステージ2に遷移
        SceneManager.LoadScene("Stage4Scene");
    }

    public void LoadStage5()
    {
        //ステージ2に遷移
        SceneManager.LoadScene("Stage5Scene");
    }

    public void LoadStage6()
    {
        //ステージ2に遷移
        SceneManager.LoadScene("Stage6Scene");
    }

    public void LoadStage7()
    {
        //ステージ2に遷移
        SceneManager.LoadScene("Stage7Scene");
    }

    public void LoadStage8()
    {
        //ステージ2に遷移
        SceneManager.LoadScene("Stage8Scene");
    }

    public void LoadStage9()
    {
        //ステージ2に遷移
        SceneManager.LoadScene("Stage9Scene");
    }

    public void LoadStage10()
    {
        //ステージ2に遷移
        SceneManager.LoadScene("Stage10Scene");
    }
}