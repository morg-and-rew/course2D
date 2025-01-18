using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable()
    {
        ScoreCounter.Instance.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        ScoreCounter.Instance.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreText.text = score.ToString();
    }
}
