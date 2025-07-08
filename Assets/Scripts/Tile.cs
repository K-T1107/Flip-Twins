using UnityEngine;

public class Tile : MonoBehaviour
{
    public Sprite onSprite;   // 表パネル（ON状態）
    public Sprite offSprite;  // 裏パネル（OFF状態）
    public bool isOn = false; // 現在の状態（初期はOFF）

    private SpriteRenderer sr;

    public int id;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    public void Trigger()
    {
        Flip();
        FlipNeighbors();
    }

    public void Flip()
    {
        isOn = !isOn;
        UpdateSprite();
    }

    void UpdateSprite()
    {
        sr.sprite = isOn ? onSprite : offSprite;
    }

    void FlipNeighbors()
    {
        Vector2[] dirs = {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right,
        Vector2.up + Vector2.left,     // 左上
        Vector2.up + Vector2.right,    // 右上
        Vector2.down + Vector2.left,   // 左下
        Vector2.down + Vector2.right   // 右下
    };

        foreach (Vector2 dir in dirs)
        {
            Debug.Log(dir);
            RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)dir, Vector2.zero);
            if (hit.collider.CompareTag("Tile"))
            {
                Tile neighbor = hit.collider.GetComponent<Tile>();
                Debug.Log(neighbor.id);
                if (neighbor != null)
                {
                    neighbor.Flip();
                }
            }
        }
    }
}