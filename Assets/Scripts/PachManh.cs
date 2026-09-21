using UnityEngine;

public class PachManh : MonoBehaviour
{

    [SerializeField]
    private AnimatedSprite death;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private Vector2 position;
    private Movement movement;
    private float speed = 5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = 0f;
        float yDir = 0f;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            xDir = -1f;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            xDir = 1f;
        }

        // Check for Vertical movement (W/S or Up/Down arrows)
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            yDir = -1f;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            yDir = 1f;
        }

        Vector3 moveDir = new Vector3(xDir, yDir, 0);

        transform.position += moveDir * speed * Time.deltaTime;
    }

    public void ResetState()
    {
        enabled = true;
        spriteRenderer.enabled = true;
        boxCollider.enabled = true;
        death.enabled = false;
        movement.ResetState();
        gameObject.SetActive(true);
    }

    public void DeathState()
    {
        enabled = false;
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        movement.enabled = false;
        death.enabled = true;
        death.Restart();
    }
}
