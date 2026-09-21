using UnityEngine;

public class PachManh : MonoBehaviour
{

    [SerializeField]
    private AnimatedSprite death;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private Movement movement;

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
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movement.SetDirection(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.LeftDown))
        {
            movement.SetDirection(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            movement.SetDirection(Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            movement.SetDirection(Vector2.up);
        }
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
