using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    private int _damage = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITakingDamage getDamage) && collision.TryGetComponent(out Player player))
            getDamage.TakeDamage(_damage);
    }
}