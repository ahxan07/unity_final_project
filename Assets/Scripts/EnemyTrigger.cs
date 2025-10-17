using System;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
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

            Destroy(other.gameObject); // Destroys player
        }
    }
}
