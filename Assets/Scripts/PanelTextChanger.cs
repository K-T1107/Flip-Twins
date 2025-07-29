using UnityEngine;
using UnityEngine.UI;

public class PanelTextureChanger : MonoBehaviour
{
    public GameObject targetPanel; // テクスチャを変えたいパネル
    public Sprite replacementSprite; // 差し替えるスプライト

    public void ChangePanelTexture()
    {
        Image image = targetPanel.GetComponent<Image>();
        if (image != null && replacementSprite != null)
        {
            image.sprite = replacementSprite;
        }
    }
}