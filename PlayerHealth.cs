using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UIManager.Instance.UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UIManager.Instance.UpdateUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UIManager.Instance.UpdateUI();
    }

    public void Die()
    {
        Debug.Log("Game Over!");
        GameOverManager.Instance.ShowGameOver();
    }
}