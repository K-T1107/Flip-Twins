using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSelectStage()
    {
        //�X�e�[�W�Z���N�g
        UnityEngine.SceneManagement.SceneManager.LoadScene("SelectStageScene");
    }

    public void TitleScene()
    {
        //�I�v�V������ʂɑJ��
        SceneManager.LoadScene("TitleScene");
    }

    public void OptionScene()
    {
        //�I�v�V������ʂɑJ��
        SceneManager.LoadScene("OptionScene");
    }

    public void LoadStage1()
    {
        //�X�e�[�W�P�ɑJ��
        SceneManager.LoadScene("Stage1Scene");
    }

    public void LoadStage2()
    {
        //�X�e�[�W�P�ɑJ��
        SceneManager.LoadScene("Stage2Scene");
    }
}