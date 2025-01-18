using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour, IResetble
{
    [SerializeField] ScoreCounter _scoreCounter;

    private BirdMover _birdMover;

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
    }

    public void Reset()
    {
        if (_scoreCounter != null)
        {
            _birdMover.Reset();
            _scoreCounter.ZeroingOut();
        }
    }
}