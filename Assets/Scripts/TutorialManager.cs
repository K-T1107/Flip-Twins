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
        "�����̃{�[�h�𑀍삵�܂��BWASD�L�[�ňړ��A�X�y�[�X�L�[�Ŕ��]�ł��܂��B",
        "�E���̃{�[�h�����l�ɁA���L�[�ňړ��AEnter�L�[�Ŕ��]���܂��B",
        "�����ɂ���̂��w����x�ł��B���E�̃{�[�h������Ɠ�����Ԃɑ����܂��傤�B",
        "�������ԓ��ɑ�����ꂽ��X�e�[�W�N���A�ł��I",
        "�������ł�����A�X�^�[�g�{�^���������ăQ�[�����n�߂܂��傤�B"
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
