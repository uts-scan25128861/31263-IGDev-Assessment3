using UnityEngine;

public class Pellet : MonoBehaviour
{
    protected virtual void Eat()
    {
        FindAnyObjectByType<GameManager>().PelletEaten(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PachManh"))
        {
            Eat();
        }
    }
}
