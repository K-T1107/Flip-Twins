using UnityEngine;

public class Tile : MonoBehaviour
{
    public Sprite onSprite;    // 表パネル（ON状態）
    public Sprite offSprite;   // 裏パネル（OFF状態）
    public bool isOn = false;  // 現在のON/OFF状態
    public bool isLocked = false; // 中央の見本用など操作不可にしたい場合

    private SpriteRenderer sr;

    void Start()
    {
        Initialize();
        UpdateSprite(); // 念のため、初期状態を反映
    }

    public void Initialize()
    {
        // SpriteRenderer がまだなら取得する
        if (sr == null)
        {
            sr = GetComponent<SpriteRenderer>();
        }
    }

    public void Trigger()
    {
        if (isLocked) return; // ロックされていれば無視
        Flip();
        FlipNeighbors();

        FindObjectOfType<BoardController>().CheckClear();
    }

    public void Flip()
    {
        isOn = !isOn;
        UpdateSprite();
    }

    public void UpdateSprite()
    {
        if (sr == null) sr = GetComponent<SpriteRenderer>();

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
            // 距離2.0f × dir方向にレイキャスト
            RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)dir * 2f, Vector2.zero);
            if (hit.collider != null)
            {
                Tile neighbor = hit.collider.GetComponent<Tile>();
                if (neighbor != null && !neighbor.isLocked)
                {
                    neighbor.Flip();
                }
            }
        }
    }
}