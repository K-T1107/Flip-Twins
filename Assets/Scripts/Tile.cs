using UnityEngine;

public class Tile : MonoBehaviour
{
    public Sprite onSprite;   // �\�p�l���iON��ԁj
    public Sprite offSprite;  // ���p�l���iOFF��ԁj
    public bool isOn = false; // ���݂̏�ԁi������OFF�j

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
        Vector2.up + Vector2.left,     // ����
        Vector2.up + Vector2.right,    // �E��
        Vector2.down + Vector2.left,   // ����
        Vector2.down + Vector2.right   // �E��
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