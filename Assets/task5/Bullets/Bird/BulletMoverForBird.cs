using UnityEngine;

public class BulletMoverForBird : Bullets
{
    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}