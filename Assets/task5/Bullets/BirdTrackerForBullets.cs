using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTrackerForBullets : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _xoffset;

    private void Update()
    {
        Vector3 position = transform.position;
        position.x = _bird.transform.position.x + _xoffset;
        position.y = _bird.transform.position.y + _xoffset;
        transform.position = position;
    }
}
