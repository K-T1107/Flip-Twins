using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;

    void Start()
    {
        pauseCanvas.SetActive(false); // �J�n���͔�\��
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
        Time.timeScale = 0f; // �Q�[�������Ԃ��~
        pauseCanvas.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f; // �ĊJ
        pauseCanvas.SetActive(false);
    }
}