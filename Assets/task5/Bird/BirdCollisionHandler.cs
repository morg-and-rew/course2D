using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Bird))]
public class BirdCollisionHandler : MonoBehaviour
{
    public event UnityAction GameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameOver?.Invoke();
    }
}
