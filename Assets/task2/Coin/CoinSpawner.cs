using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private void Start()
    {
        Instantiate(_coinPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}
