using UnityEngine;

public class Enemy : MonoBehaviour, IResetble
{
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    public void Reset()
    {
        gameObject.SetActive(false);
    }
}