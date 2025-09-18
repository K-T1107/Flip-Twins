using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;

    void Start()
    {
        pauseCanvas.SetActive(false); // 開始時は非表示
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                Pause();
            else
                Resume();
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f; // ゲーム内時間を停止
        pauseCanvas.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f; // 再開
        pauseCanvas.SetActive(false);
    }
}