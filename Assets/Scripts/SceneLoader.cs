using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSelectStage()
    {
        //�X�e�[�W�Z���N�g
        UnityEngine.SceneManagement.SceneManager.LoadScene("SelectStageScene");
    }

    public void LoadStage1()
    {
        //�X�e�[�W�P�ɑJ��
        SceneManager.LoadScene("Stage1Scene");
    }
}