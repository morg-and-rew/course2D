using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private BirdCollisionHandler _birdCollisionHandler;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private BulletGeneratorForBird _bulletGeneratorForBird;

    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    
    [SerializeField]private BulletGeneratorForEnemy _bulletGeneratorForEnemy;
    [SerializeField] private Bird _bird;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _birdCollisionHandler.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _birdCollisionHandler.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _bulletGeneratorForBird.ResetPool();
        _bulletGeneratorForEnemy.ResetPool();
        _enemyGenerator.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.Reset();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
}
