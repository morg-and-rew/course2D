using UnityEngine;

public class EnemyMover2 : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private Transform _player;
    [SerializeField] private float _followRadius = 10f;

    private float _speed = 2f;
    private int _currentPointIndex = 0;
    private bool _isFollowingPlayer = false;

    private void Update()
    {
        if (_targetPoints.Length == 0)
            return;

        if (IsPlayerInArea()==true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
            _isFollowingPlayer = true;
        }
        else
        {
            if (_isFollowingPlayer)
            {
                _currentPointIndex = 0;
                _isFollowingPlayer = false;
            }

            Transform target = _targetPoints[_currentPointIndex];
            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

            if (transform.position == target.position)
                _currentPointIndex = (++_currentPointIndex) % _targetPoints.Length;
        }
    }

    public bool IsPlayerInArea()
    {
        float distanceToPlayerSqr = (transform.position - _player.position).sqrMagnitude;
        float followRadiusSqr = _followRadius * _followRadius;

        return distanceToPlayerSqr <= followRadiusSqr;
    }
}