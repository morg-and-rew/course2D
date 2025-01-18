using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private float speed = 1f;

    private void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
