using UnityEngine;

public class BulletGenerator : ObjectPool<Bullets>
{
    [SerializeField] protected Bullets BulletPrefab; 
    private float _deactivateTime = 3f;

    private void Start()
    {
        Create(BulletPrefab); 
    }

    protected void SpawnBullet()
    {
        if (TryGetObject(out Bullets bullet))
        {
            SetObject(bullet);
            StartCoroutine(UpdateDeactivateTimer(bullet, _deactivateTime));
        }
    }
}