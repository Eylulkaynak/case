using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    // Singleton referansı
    public static GameManager Instance;

    [Header("Skor Ayarları")]
    public int score = 0;
    public int highScore = 0; 
    
    public TextMeshProUGUI scoreText; 

    private void Awake()
    {
        // Singleton Yapısının Kurulumu
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Oyun başladığında eski rekoru cihazın hafızasından çek
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreUI();
    }

    private void Update()
    {
        // TEST İÇİN: R tuşuna basınca hem rekoru hem normal skoru sıfırlar
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetHighScore();
            ResetCurrentScore();
        }
    }

    // Skoru artıran metod
    public void AddScore(int points)
    {
        score += points;

        // Yeni rekor kırıldı mı kontrolü
        if (score > highScore)
        {
            highScore = score; 
            
            // Yeni rekoru cihaz hafızasına kaydet
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); 
        }

        UpdateScoreUI();
    }

    // Mevcut skoru sıfırlar (Karakter ölünce veya yeni bölüme geçince çağırılabilir)
    public void ResetCurrentScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    // Rekoru (High Score) tamamen sıfırlar ve hafızadan siler
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore"); 
        highScore = 0;                      
        UpdateScoreUI();
        Debug.Log("En yüksek skor hafızadan silindi!");
    }

    // UI Text'ini güncelleyen metod
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            // Artık ekranda hem skoru hem rekoru yan yana gösterecek
            scoreText.text = "Skor: " + score + " | Rekor: " + highScore;
        }
    }
}