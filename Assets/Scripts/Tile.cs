using UnityEngine;

public class Tile : MonoBehaviour
{
    public Sprite onSprite;
    public Sprite offSprite;
    public bool isOn = false;
    public bool isLocked = false;

    private SpriteRenderer sr;

    void Start()
    {
        Initialize();
        UpdateSprite();
    }

    public void Initialize()
    {
        if (sr == null) sr = GetComponent<SpriteRenderer>();
    }

    public void Trigger()
    {
        if (isLocked) return;
        Flip();
        FlipNeighbors();

        BoardController board = FindObjectOfType<BoardController>();
        if (board != null)
            board.OnTileTriggered();
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
            Vector2.up + Vector2.left,
            Vector2.up + Vector2.right,
            Vector2.down + Vector2.left,
            Vector2.down + Vector2.right
        };

        foreach (Vector2 dir in dirs)
        {
            RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + dir * 2f, Vector2.zero);
            if (hit.collider != null)
            {
                Tile neighbor = hit.collider.GetComponent<Tile>();
                if (neighbor != null && !neighbor.isLocked)
                    neighbor.Flip();
            }
        }
    }
}
