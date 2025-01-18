using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private int _damage = 15;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITakingDamage getDamage) && collision.TryGetComponent(out Enemy enemy))
            getDamage.TakeDamage(_damage);
    }
}
