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
        "�����̃{�[�h�𑀍�BWASD�L�[�ňړ��A�X�y�[�X�L�[�Ŕ��]�B",
        "�E���̃{�[�h�����l�A���L�[�ňړ��AEnter�L�[�Ŕ��]�B",
        "�����ɂ���̂��w����x�B���E�̃{�[�h������Ɠ�����Ԃɑ����āB",
        "�������ԓ��ɑ�����ꂽ��X�e�[�W�N���A�B",
        "�������ł����Ȃ�AStart�{�^���������Ďn�߂āB"
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
