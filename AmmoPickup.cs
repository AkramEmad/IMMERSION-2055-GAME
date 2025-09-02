using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShooting ps = other.GetComponent<PlayerShooting>();
            if (ps != null)
            {
                ps.AddAmmo(ammoAmount);
            }
            Destroy(gameObject);
        }
    }
}