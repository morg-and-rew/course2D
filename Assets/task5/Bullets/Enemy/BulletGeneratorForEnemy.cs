using System.Collections;
using UnityEngine;

public class BulletGeneratorForEnemy : BulletGenerator
{
    private float _spawnInterval = 2;

    private void Start()
    {
        Create(BulletPrefab);
        StartCoroutine(SpawnBulletCoroutine());
    }

    private IEnumerator SpawnBulletCoroutine()
    {
        WaitForSeconds spawnInterval = new WaitForSeconds(_spawnInterval);

        while (true)
        {
            yield return spawnInterval;
            SpawnBullet();
        }
    }
}
