using UnityEngine;

public class Bullets : MonoBehaviour
{
    protected float _speed = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IResetble reset))
        {
            gameObject.SetActive(false);
            reset.Reset();
            ScoreCounter.Instance.Add();
        }
    }
}