using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("ゲームを終了します");
        Application.Quit();
    }
}
