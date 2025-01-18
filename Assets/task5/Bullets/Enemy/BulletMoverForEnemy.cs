using UnityEngine;

public class BulletMoverForEnemy : Bullets
{
    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
