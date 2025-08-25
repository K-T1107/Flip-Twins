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
        "左側のボードを操作。WASDキーで移動、スペースキーで反転。",
        "右側のボードも同様、矢印キーで移動、Enterキーで反転。",
        "中央にあるのが『お題』。左右のボードをお題と同じ状態に揃えて。",
        "制限時間内に揃えられたらステージクリア。",
        "準備ができたなら、Startボタンを押して始めて。"
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
