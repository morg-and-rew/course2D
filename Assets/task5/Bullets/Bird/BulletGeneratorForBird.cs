using UnityEngine;

public class BulletGeneratorForBird : BulletGenerator
{
    private KeyCode _shotKey = KeyCode.E;

    private void Update()
    {
        if (Input.GetKeyDown(_shotKey))
            SpawnBullet();
    }
}
