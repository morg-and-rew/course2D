using UnityEngine;

public class FirstAidKitSpawner : MonoBehaviour
{
    [SerializeField] private FirstAidKit _firstAidKit;

    private void Start()
    {
        Instantiate(_firstAidKit, gameObject.transform.position, gameObject.transform.rotation);
    }
}