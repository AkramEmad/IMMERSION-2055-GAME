using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem; // New Input System

public class PCInteraction : MonoBehaviour
{
    private bool isPlayerNear = false;
    private bool isDownloading = false;

    [Header("UI Elements")]
    public Slider progressBar;
    public TMP_Text statusText;

    [Header("Settings")]
    public float downloadTime = 3f;

    [Header("Bot Settings")]
    public AICharacterControl enemyAI;
    public Transform player;

    void Update()
    {
        if (isPlayerNear && !isDownloading && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("E pressed - starting download...");
            StartCoroutine(DownloadRoutine());
        }
    }

    private IEnumerator DownloadRoutine()
    {
        isDownloading = true;

        if (progressBar) { progressBar.value = 0; progressBar.gameObject.SetActive(true); }
        if (statusText) { statusText.text = "Downloading..."; statusText.gameObject.SetActive(true); }

        float t = 0f;

        while (t < downloadTime)
        {
            t += Time.deltaTime;
            float progress = Mathf.Clamp01(t / downloadTime);
            if (progressBar) progressBar.value = progress;
            yield return null;
        }

        if (progressBar) progressBar.gameObject.SetActive(false);

        if (statusText)
        {
            statusText.text = "Download Completed!";
            yield return new WaitForSeconds(2f);
            statusText.gameObject.SetActive(false);
        }

        Debug.Log("Download finished - Data Retrieved!");

        // ✅ Activate bot
        if (enemyAI != null && player != null)
        {
            enemyAI.SetTarget(player);
            Debug.Log("Bot has been activated to hunt the player!");
        }
        if (enemyAI != null && player != null)
        {
            enemyAI.SetTarget(player);
            Debug.Log("✅ Bot target set to player: " + player.name);
        }

        isDownloading = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Player entered PC trigger - can press E");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Player left PC trigger");
        }
    }
}
