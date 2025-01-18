using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    public int _score { get; private set; } = 0;
    public event UnityAction<int> ScoreChanged;

    private static ScoreCounter _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static ScoreCounter Instance => _instance;

    public void Add()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void ZeroingOut()
    {
        _score = 0; 
        ScoreChanged?.Invoke(_score);
    }
}