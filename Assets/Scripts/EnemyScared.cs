using UnityEngine;

public class EnemyScared : EnemyBehaviour
{

    public bool eaten { get; private set; }

    public override void Enable(float duration)
    {
        base.Enable(duration);
    }

    public override void Disable()
    {
        base.Disable();
    }

    private void OnEnable()
    {
        
    }
}
