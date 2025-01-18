using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour, ICollectble
{
    [SerializeField]private float _wallet = 0f;

    [SerializeField]private Health _health;

    public void CollectCoin(int coin)
    {
        if (coin > 0)
            _wallet += coin;
    }

    public void CollectFirstAidKit(int recoveryHealth)
    {
        _health.TakeHeal(recoveryHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Collectible collectible))
            collectible.Collect(this);
    }
}
