using UnityEngine;

public class Collectible : MonoBehaviour
{
    public virtual void Collect(ICollectble collector)
    {
        Destroy(gameObject);
    }
}