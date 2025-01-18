using System.Collections;
using UnityEngine;

public class EnemyGenerator : ObjectPool<Enemy>
{
    [SerializeField] private Enemy _enemyPrefab; 

    private float _timeBetweenSpawn = 3f;
    private float _deactivateTime = 20f;
    private WaitForSeconds _waitBetweenSpawn;

    private void Start()
    {
        Create(_enemyPrefab); 
        _waitBetweenSpawn = new WaitForSeconds(_timeBetweenSpawn);
        StartCoroutine(SpawnEnemiesRepeatedly());
    }

    public IEnumerator SpawnEnemiesRepeatedly()
    {
        while (true)
        {
            yield return _waitBetweenSpawn;

            if (TryGetObject(out Enemy enemy))
            {
                SetObject(enemy); 
                StartCoroutine(UpdateDeactivateTimer(enemy, _deactivateTime));
            }
        }
    }
}