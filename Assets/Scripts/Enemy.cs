using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform target;
    public EnemyScared scared;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.scared.Disable();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PachManh"))
        {
            if (this.scared.enabled)
            {
                FindAnyObjectByType<GameManager>().EnemyEaten(this);
            }
            else
            {
                FindAnyObjectByType<GameManager>().PlayerHit();
            }
        }
    }
}
