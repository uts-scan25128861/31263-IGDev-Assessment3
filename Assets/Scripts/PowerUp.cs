using UnityEngine;

public class PowerUp : Pellet
{
    protected override void Eat()
    {
        FindAnyObjectByType<GameManager>().PowerUpEaten(this);
    }
}
