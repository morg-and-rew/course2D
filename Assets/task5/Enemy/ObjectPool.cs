using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected List<Transform> Containers;

    private int _capacity = 30;
    private float _objectProbability = 0.5f;

    private List<T> _pool = new List<T>();

    public void Create(T prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            float randomValue = Random.value;

            if (randomValue < _objectProbability)
            {
                T obj = Instantiate(prefab);
                obj.gameObject.SetActive(false);
                _pool.Add(obj);
            }
        }
    }

    public IEnumerator UpdateDeactivateTimer(T obj, float deactivateTime)
    {
        WaitForSeconds waitTime = new WaitForSeconds(deactivateTime);

        yield return waitTime;

        obj.gameObject.SetActive(false);
    }

    protected bool TryGetObject(out T result)
    {
        result = _pool.FirstOrDefault(p => !p.gameObject.activeSelf);

        return result != null;
    }

    protected void SetObject(T prefab)
    {
        Transform spawnPoint = GetRandomContainer();

        if (spawnPoint != null)
        {
            prefab.transform.position = spawnPoint.position;
            prefab.gameObject.SetActive(true);
        }
    }

    private Transform GetRandomContainer()
    {
        if (Containers == null || Containers.Count == 0)
        {
            return null;
        }

        return Containers[Random.Range(0, Containers.Count)];
    }

    public void ResetPool()
    {
        foreach (T item in _pool)
        {
            item.gameObject.SetActive(false);
        }
    }
}