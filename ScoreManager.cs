using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score = 0;

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UIManager.Instance.UpdateUI();
    }

    public void ResetScore()
    {
        score = 0;
        UIManager.Instance.UpdateUI();
    }
}