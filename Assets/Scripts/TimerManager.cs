using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public float timeLimit = 20f;
    private float timeRemaining;

    public Text timerText;
    public GameObject gameOverPanel;

    private bool isGameOver = false;
    private bool isRunning = true;

    void Start()
    {
        timeRemaining = timeLimit;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (isGameOver || !isRunning) return;

        timeRemaining -= Time.deltaTime;
        timerText.text = $"�c�莞�ԁF{Mathf.CeilToInt(timeRemaining)}�b";

        if (timeRemaining <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        timerText.text = "���Ԑ؂�I";
        gameOverPanel.SetActive(true);
        // �����ŉ���G�t�F�N�g

        gameOverPanel.GetComponent<PanelTextureChanger>().ChangePanelTexture();
    }

    public void RetryStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void StopTimer()
    {
        isRunning = false;

        // �^�C�}�[��Text���\���ɂ���
        if (timerText != null)
        {
            timerText.gameObject.SetActive(false);
        }
    }
}