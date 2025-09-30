using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI (drag here)")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;

    [Header("Game rules")]
    [SerializeField] private int winScore = 10;      // đạt bao nhiêu thì win (có thể đổi trong Inspector)
    [SerializeField] private bool useMaxCap = false; // nếu muốn khoá max điểm
    [SerializeField] private int maxScoreCap = 7;    // Max nếu bật useMaxCap

    private int score = 0;
    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }
    }

    void Start()
    {
        score = 0;
        UpdateScoreUI();
        if (winUI) winUI.SetActive(false);
        if (loseUI) loseUI.SetActive(false);
        // đảm bảo Time.timeScale = 1 khi start (tránh còn bị 0 từ lần thử trước)
        Time.timeScale = 1f;
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        if (useMaxCap && score > maxScoreCap) score = maxScoreCap;

        UpdateScoreUI();

        if (score >= winScore)
        {
            WinGame();
        }
        else if (score < 0)
        {
            LoseGame();
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
    }

    private void WinGame()
    {
        isGameOver = true;
        if (winUI) winUI.SetActive(true);
        Time.timeScale = 0f; // dừng game
    }

    private void LoseGame()
    {
        isGameOver = true;
        if (loseUI) loseUI.SetActive(true);
        Time.timeScale = 0f; // dừng game
    }

    public int GetScore() => score;
}
