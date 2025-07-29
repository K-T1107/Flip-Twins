using UnityEngine;
using UnityEngine.UI;

public class PanelTextureChanger : MonoBehaviour
{
    public GameObject targetPanel; // �e�N�X�`����ς������p�l��
    public Sprite replacementSprite; // �����ւ���X�v���C�g

    public void ChangePanelTexture()
    {
        Image image = targetPanel.GetComponent<Image>();
        if (image != null && replacementSprite != null)
        {
            image.sprite = replacementSprite;
        }
    }
}