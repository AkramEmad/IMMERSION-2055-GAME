using UnityEngine;

public class DropItemOnDeath : MonoBehaviour
{
    public GameObject[] dropItems;
    [Range(0f, 1f)] public float dropChance = 0.5f;

    public void DropItem()
    {
        if (dropItems.Length == 0) return;

        float rand = Random.value;
        if (rand <= dropChance)
        {
            int index = Random.Range(0, dropItems.Length);
            Instantiate(dropItems[index], transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }
    }
}