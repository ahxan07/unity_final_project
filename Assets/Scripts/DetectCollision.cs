using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject deathEffectPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Bullet") && other.CompareTag("Enemy"))
        {
            Vector3 spawnPos = other.transform.position;

            // Spawn particle effect instantly
            if (deathEffectPrefab != null)
            {
                Instantiate(deathEffectPrefab, spawnPos, Quaternion.identity);
            }
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.AddScore(1);
        }
    }
}
