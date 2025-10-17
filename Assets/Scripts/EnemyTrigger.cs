using System;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject PlayerDeathEffectPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Zombie hit player!");

            GameManager gm = GameManager.FindFirstObjectByType<GameManager>();
            if (gm != null)
            {
                gm.GameOver();
            }
            Vector3 spawnPos = other.transform.position;
            if (PlayerDeathEffectPrefab != null)
            {
                Instantiate(PlayerDeathEffectPrefab, spawnPos, Quaternion.identity);
            }

            Destroy(other.gameObject); // Destroys player
        }
    }
}
