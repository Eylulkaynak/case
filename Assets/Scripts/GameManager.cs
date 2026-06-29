using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public TMP_Text scoreText;

    [Header("Enemy Spawn Settings")]
    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;
    public float respawnDelay = 2f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        score = PlayerPrefs.GetInt("SavedScore", 0);
        UpdateScoreUI();
    }
    public void EnemyDied()
    {
        AddScore(1);
        StartCoroutine(RespawnEnemy());
    }

    private IEnumerator RespawnEnemy()
    {
        yield return new WaitForSeconds(respawnDelay);

        Instantiate(enemyPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
    }

    public void AddScore(int amount)
    {
        score += amount;
        PlayerPrefs.SetInt("SavedScore", score);
        PlayerPrefs.Save();
        UpdateScoreUI();
    }

    public void ResetScore()
{
    score = 0;
    PlayerPrefs.SetInt("SavedScore", score);
    PlayerPrefs.Save();
    UpdateScoreUI();
}

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}