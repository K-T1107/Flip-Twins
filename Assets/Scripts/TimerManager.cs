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
        timerText.text = $"残り時間：{Mathf.CeilToInt(timeRemaining)}秒";

        if (timeRemaining <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        timerText.text = "時間切れ！";
        gameOverPanel.SetActive(true);
        // ここで音やエフェクト

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

        // タイマーのTextを非表示にする
        if (timerText != null)
        {
            timerText.gameObject.SetActive(false);
        }
    }
}