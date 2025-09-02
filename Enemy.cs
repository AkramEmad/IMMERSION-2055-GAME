using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50;
    public int scoreValue = 20;
    public float moveSpeed = 3f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            ScoreManager.Instance.AddScore(scoreValue);

            DropItemOnDeath drop = GetComponent<DropItemOnDeath>();
            if (drop != null)
            {
                drop.DropItem();
            }

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.Die();
            }
        }
    }
}