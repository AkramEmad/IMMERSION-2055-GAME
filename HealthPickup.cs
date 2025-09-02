using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.Heal(healAmount);
            }
            Destroy(gameObject);
        }
    }
}