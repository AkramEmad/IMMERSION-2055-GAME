using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text healthText;
    public Text ammoText;
    public Text scoreText;

    private PlayerHealth playerHealth;
    private PlayerShooting playerShooting;
    private ScoreManager scoreManager;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerShooting = FindObjectOfType<PlayerShooting>();
        scoreManager = ScoreManager.Instance;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (playerHealth != null && healthText != null)
            healthText.text = "Health: " + playerHealth.currentHealth;

        if (playerShooting != null && ammoText != null)
            ammoText.text = "Ammo: " + playerShooting.ammo;

        if (scoreManager != null && scoreText != null)
            scoreText.text = "Score: " + scoreManager.score;
    }
}