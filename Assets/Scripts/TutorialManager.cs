using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text tutorialText;
    public Button nextButton;
    public GameObject startButton;

    private int currentStep = 0;

    private string[] tutorialMessages = new string[]
    {
        "左側のボードを操作します。WASDキーで移動、スペースキーで反転できます。",
        "右側のボードも同様に、矢印キーで移動、Enterキーで反転します。",
        "中央にあるのが『お題』です。左右のボードをお題と同じ状態に揃えましょう。",
        "制限時間内に揃えられたらステージクリアです！",
        "準備ができたら、スタートボタンを押してゲームを始めましょう。"
    };

    void Start()
    {
        ShowStep();
    }

    public void NextStep()
    {
        currentStep++;
        if (currentStep < tutorialMessages.Length)
        {
            ShowStep();
        }
        else
        {
            nextButton.gameObject.SetActive(false);
            startButton.SetActive(true);
        }
    }

    void ShowStep()
    {
        tutorialText.text = tutorialMessages[currentStep];
    }
}
