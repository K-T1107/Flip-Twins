using UnityEngine;

public class Tile : MonoBehaviour
{
    public Sprite onSprite;    // �\�p�l���iON��ԁj
    public Sprite offSprite;   // ���p�l���iOFF��ԁj
    public bool isOn = false;  // ���݂�ON/OFF���
    public bool isLocked = false; // �����̌��{�p�ȂǑ���s�ɂ������ꍇ

    private SpriteRenderer sr;

    void Start()
    {
        Initialize();
        UpdateSprite(); // �O�̂��߁A������Ԃ𔽉f
    }

    public void Initialize()
    {
        // SpriteRenderer ���܂��Ȃ�擾����
        if (sr == null)
        {
            sr = GetComponent<SpriteRenderer>();
        }
    }

    public void Trigger()
    {
        if (isLocked) return; // ���b�N����Ă���Ζ���
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
            Vector2.up + Vector2.left,     // ����
            Vector2.up + Vector2.right,    // �E��
            Vector2.down + Vector2.left,   // ����
            Vector2.down + Vector2.right   // �E��
        };

        foreach (Vector2 dir in dirs)
        {
            // ����2.0f �~ dir�����Ƀ��C�L���X�g
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