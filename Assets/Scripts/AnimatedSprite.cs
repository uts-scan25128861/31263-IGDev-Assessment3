using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{

    public Sprite[] sprites = new Sprite[0];
    public float animationTime = 0.25f;
    public bool loop = true;

    private SpriteRenderer spriteRenderer;
    private int keyFrame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(Advance), animationTime, animationTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Advance()
    {
        if (!spriteRenderer.enabled) 
        { 
            return; 
        }

        keyFrame++;

        if (keyFrame >= sprites.Length && loop)
        {
            keyFrame = 0;
        }

        if (keyFrame >= 0 && keyFrame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[keyFrame];
        }

       
    }

    public void Restart()
    {
        keyFrame = -1;
        Advance();
    }
}
