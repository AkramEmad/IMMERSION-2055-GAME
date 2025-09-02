using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public int ammo = 10;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * bulletSpeed;

        ammo--;
        UIManager.Instance.UpdateUI();
    }

    public void AddAmmo(int amount)
    {
        ammo += amount;
        UIManager.Instance.UpdateUI();
    }
}